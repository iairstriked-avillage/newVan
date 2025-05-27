using System;
using System.Runtime.InteropServices;

namespace test
{
    public static class WifiInterop
    {
        [Flags]
        public enum WlanProfileFlags
        {
            AllUser = 0,
            GroupPolicy = 1,
            User = 2
        }

        [DllImport("wlanapi.dll", SetLastError = true)]
        public static extern int WlanOpenHandle(
            uint dwClientVersion,
            IntPtr pReserved,
            out uint pdwNegotiatedVersion,
            out IntPtr phClientHandle);

        [DllImport("wlanapi.dll", SetLastError = true)]
        public static extern int WlanSetProfile(
            IntPtr hClientHandle,
            Guid pInterfaceGuid,
            WlanProfileFlags dwFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string strProfileXml,
            [MarshalAs(UnmanagedType.LPWStr)] string strAllUserProfileSecurity,
            bool bOverwrite,
            IntPtr pReserved,
            out uint pdwReasonCode);

        [DllImport("wlanapi.dll", SetLastError = true)]
        public static extern int WlanCloseHandle(
            IntPtr hClientHandle,
            IntPtr pReserved);
    }
}
