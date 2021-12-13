using System;
using System.Windows.Forms;

namespace BlackNotepad
{
    public partial class MessageBoxCustom : Form
    {
        string FileContent;
        public bool ReturnValue =false;
        public MessageBoxCustom(string filecontent)
        {
            InitializeComponent();
            FileContent= filecontent;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ReturnValue = true;
            FileHandler.SaveFileText(FileContent);
            Close();
        }

        private void DontSaveButton_Click(object sender, EventArgs e)
        {
            ReturnValue = true;
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
