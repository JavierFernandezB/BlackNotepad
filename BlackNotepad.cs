using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackNotepad
{
    public partial class BlackNotepad : Form
    {

        public static string FontFamily { get; set; }
        public static string FontStyles { get; set; }
        public static int FontSize { get; set; }
        public static FontStyle getFont(string name)
        {
            switch (name)
            {
                case "BoldAndItalic":
                    return FontStyle.Bold | FontStyle.Italic;
                case "Bold":
                    return FontStyle.Bold;
                case "Italic":
                    return FontStyle.Italic;
                case "Normal":
                    return FontStyle.Regular;
                default:
                    return FontStyle.Regular;
            }
        }

        public BlackNotepad()
        {

            InitializeComponent();

            FontFamily = Properties.Settings.Default.FontFamily;
            FontStyles = Properties.Settings.Default.FontStyle;
            FontSize = Properties.Settings.Default.FontSize;
            InputText.Font = new Font(new FontFamily(FontFamily), FontSize, getFont(FontStyles));
            menuStrip1.Renderer = new MyRender();
            Icon = Properties.Resources.final;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                string result = FileHandler.OpenFileText(args[1]);
                InputText.Text = result;

            }
            SetTitleName();



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
            WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = FileHandler.OpenFileText();
            InputText.Text = texto;
            SetTitleName();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                flowLayoutPanel1.Focus();
            }
            else
            {
                WindowState = FormWindowState.Maximized;
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

        private void BlackNotepad_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.FontFamily = FontFamily;
            Properties.Settings.Default.FontSize = FontSize;
            Properties.Settings.Default.FontStyle = FontStyles;
            Properties.Settings.Default.Save();

        }

        private void BlackNotepad_Activated(object sender, EventArgs e)
        {
            InputText.Font = new Font(new FontFamily(FontFamily), FontSize, getFont(FontStyles));

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHandler.NewFileText();
            InputText.Text = "";
        }

        public void SetTitleName(string changed = " ")
        {
            NotepadTitle.Text = $"         {changed}{FileHandler.filename} - Notepad";

        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BlackNotepad().Show();
        }

        private void InputText_TextChanged(object sender, EventArgs e)
        {

            if (FileHandler.changed == false)
            {
                SetTitleName("*");
                FileHandler.changed = true;
            }
            if (FileHandler.changed == true && FileHandler.filePath == string.Empty && InputText.Text == string.Empty)
            {
                SetTitleName();
                FileHandler.changed = false;
            }
        }
    }
}
