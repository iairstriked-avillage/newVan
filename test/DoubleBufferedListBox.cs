using System.Windows.Forms;

namespace test
{
    public class DoubleBufferedListBox : ListBox
    {
        public DoubleBufferedListBox()
        {
            DoubleBuffered = true;
        }
    }
}