using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackNotepad
{
    public partial class BlackNotepad : Form
    {
        readonly Font BoldAndItalic = new Font(Control.DefaultFont, FontStyle.Bold | FontStyle.Italic);
        readonly Font Bold = new Font(Control.DefaultFont, FontStyle.Bold);
        readonly Font Italic = new Font(Control.DefaultFont, FontStyle.Italic);
        readonly Font Normal = new Font(Control.DefaultFont, FontStyle.Regular);

        public BlackNotepad()
        {
           
            InitializeComponent();
            menuStrip1.Renderer = new MyRender();
            Icon = Properties.Resources.final;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2) 
            {
                string result=FileHandler.OpenFileText(args[1]);
                InputText.Text = result;
            }
            
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        private void MinimizeButton_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = FileHandler.OpenFileText();
            InputText.Text = texto;
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                flowLayoutPanel1.Focus();
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                flowLayoutPanel1.Focus();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHandler.SaveFileText(InputText.Text);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                FileHandler.SaveFileText(InputText.Text);
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InputText.WordWrap)
            {
                InputText.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
                
            }
            else
            {
                InputText.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontForm f = new FontForm();
            f.ShowDialog();
        }
    }
}
