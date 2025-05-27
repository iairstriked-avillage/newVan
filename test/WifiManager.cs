using ManagedNativeWifi;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test.Form1;

namespace test
{
    public class WifiManager
    {
        public async Task<bool> ConnectAsync(string ssid, string password = null)
        {
            var availableNetwork = NativeWifi.EnumerateAvailableNetworks()
                .FirstOrDefault(x => x.Ssid.ToString() == ssid);

            if (availableNetwork == null)
                return false;

            try
            {
                if (!string.IsNullOrWhiteSpace(availableNetwork.ProfileName))
                {
                    // The network profile already exists, try connecting
                    return await NativeWifi.ConnectNetworkAsync(
                        interfaceId: availableNetwork.Interface.Id,
                        profileName: availableNetwork.ProfileName,
                        bssType: availableNetwork.BssType,
                        timeout: TimeSpan.FromSeconds(10));
                }
                else
                {
                    // The network is not configured, create a new profile if a password is provided
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        bool success = CreateNetworkProfile(
                            availableNetwork.Interface.Id,
                            availableNetwork.Ssid.ToString(),
                            password);

                        if (success)
                        {
                            return await NativeWifi.ConnectNetworkAsync(
                                interfaceId: availableNetwork.Interface.Id,
                                profileName: availableNetwork.Ssid.ToString(),
                                bssType: availableNetwork.BssType,
                                timeout: TimeSpan.FromSeconds(10));
                        }
                        else
                        {
                            return false; // Failed to create network profile
                        }
                    }
                    else
                    {
                        return false; // Password is required for new network configuration
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect to network: {ssid}\nError: {ex.Message}");
                return false;
            }
        }

        public string ToHex(string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                sb.Append($"{(int)c:X2}");
            }
            return sb.ToString();
        }

        public bool CreateNetworkProfile(Guid interfaceId, string ssid, string password)
        {
            const string profileTemplate = @"<?xml version=""1.0""?>
        < WLANProfile xmlns = ""http://www.microsoft.com/networking/WLAN/profile/v1"">
             < name > {0} < / name >
             < SSIDConfig >
                 < SSID >
                     < hex > {1} < / hex >
                     < name > {0} < / name >
                 < / SSID >
             < / SSIDConfig >
             < connectionType > IBSS < / connectionType >
             < connectionMode > auto < / connectionMode >
             < MSM >
                 < security >
                      < sharedKey >
                          < keyMaterial > {2} < / keyMaterial >
                      < / sharedKey >
                 < / security >
             < / MSM >
        < / WLANProfile > ";

            var profileXml = string.Format(profileTemplate, ssid, ToHex(ssid), password);

            var result = WifiInterop.WlanOpenHandle(2, IntPtr.Zero, out _, out var clientHandle);
            if (result != 0)
            {
                return false;
            }

            result = WifiInterop.WlanSetProfile(clientHandle, interfaceId, WifiInterop.WlanProfileFlags.User, profileXml, null, true, IntPtr.Zero, out _);

            WifiInterop.WlanCloseHandle(clientHandle, IntPtr.Zero);

            return result == 0;
        }
    }
}
