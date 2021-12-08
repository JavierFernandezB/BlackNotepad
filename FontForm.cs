using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace BlackNotepad
{
    public partial class FontForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public FontForm()
        {
            int[] FontSize = new int[16] { 8, 9, 19, 11, 12, 14, 16, 20, 22, 24, 26, 28, 36, 48, 72, 100 };
            InitializeComponent();
            using (InstalledFontCollection col = new InstalledFontCollection())
            {
                foreach (FontFamily fa in col.Families)
                {
                    
                    listBoxFontFamily.Items.Add(fa.Name);

                }
                foreach (int size in FontSize)
                {
                    listBoxFontSize.Items.Add(size);
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FontForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.AliceBlue, 3),
                           this.DisplayRectangle);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            int BORDER_SIZE = 50;
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.White, BORDER_SIZE, ButtonBorderStyle.Outset
                );

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
