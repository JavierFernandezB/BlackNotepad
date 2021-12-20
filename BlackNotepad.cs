using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackNotepad
{
    public partial class BlackNotepad : Form
    {
        private const int cGrip = 16;


        public static string FontFamily { get; set; }
        public static string FontStyles { get; set; }
        public static int FontSize { get; set; }
        public static Color BorderColor { get; set; }

        private readonly Stack<string> undoList = new Stack<string>();
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
            Icon = Properties.Resources.notepad16;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2)
            {
                string result = FileHandler.OpenFileText(args[1]);
                InputText.Text = result;

            }
            SetTitleName();
            zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + Plus";
            zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + Minus";
            SetStyle(ControlStyles.ResizeRedraw, true);

            Bitmap image = new Bitmap(Properties.Resources.notepad16.ToBitmap(), new Size(24, 24));
            NotepadTitle.Image = image;
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

        //Start resizing settings
        private const int _ = 10;
        private const int
                    HTLEFT = 10,
                    HTRIGHT = 11,
                    HTTOP = 12,
                    HTTOPLEFT = 13,
                    HTTOPRIGHT = 14,
                    HTBOTTOM = 15,
                    HTBOTTOMLEFT = 16,
                    HTBOTTOMRIGHT = 17;

        private Rectangle TopLeft => new Rectangle(0, 0, _, _);

        private Rectangle TopRight => new Rectangle(ClientSize.Width - _, 0, _, _);

        private Rectangle BottomLeft => new Rectangle(0, ClientSize.Height - _, _, _);

        private Rectangle BottomRight => new Rectangle(ClientSize.Width - _, ClientSize.Height - _, _, _);

        private new Rectangle Top => new Rectangle(0, 0, ClientSize.Width, _);

        private new Rectangle Left => new Rectangle(0, 0, _, ClientSize.Height);

        private new Rectangle Bottom => new Rectangle(0, ClientSize.Height - _, ClientSize.Width, _);

        private new Rectangle Right => new Rectangle(ClientSize.Width - _, 0, _, ClientSize.Height);

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                Point cursor = PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOPLEFT;
                }
                else if (TopRight.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOPRIGHT;
                }
                else if (BottomLeft.Contains(cursor))
                {
                    message.Result = (IntPtr)HTBOTTOMLEFT;
                }
                else if (BottomRight.Contains(cursor))
                {
                    message.Result = (IntPtr)HTBOTTOMRIGHT;
                }
                else if (Top.Contains(cursor))
                {
                    message.Result = (IntPtr)HTTOP;
                }
                else if (Left.Contains(cursor))
                {
                    message.Result = (IntPtr)HTLEFT;
                }
                else if (Right.Contains(cursor))
                {
                    message.Result = (IntPtr)HTRIGHT;
                }
                else if (Bottom.Contains(cursor))
                {
                    message.Result = (IntPtr)HTBOTTOM;
                }
            }
        }

        //End Resize


        private void MinimizeButton_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {

            if (FileHandler.changed)
            {
                using (MessageBoxCustom form = new MessageBoxCustom(InputText.Text))
                {
                    form.ShowDialog();
                    if (form.ReturnValue)
                    {
                        Close();
                    }
                }
            }
            else
            {
                Close();
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileHandler.changed)
            {
                new MessageBoxCustom(InputText.Text).ShowDialog();
            }

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
            undoList.Push(InputText.Text);
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

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputText.ZoomFactor += .1f;
            FontZoom.Text = (int.Parse(FontZoom.Text.ToString().Split('%')[0]) + 10).ToString() + "%";

        }


        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputText.ZoomFactor -= .1f;
            FontZoom.Text = (int.Parse(FontZoom.Text.ToString().Split('%')[0]) - 10).ToString() + "%";
        }



        private void restoreZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputText.ZoomFactor = 1;
            FontZoom.Text = "100%";
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {

            ControlPaint.DrawBorder(e.Graphics, labelCount.DisplayRectangle, Color.Gray, ButtonBorderStyle.Solid);

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, flowLayoutPanel2.DisplayRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void InputText_SelectionChanged(object sender, EventArgs e)
        {
            int line = InputText.GetLineFromCharIndex(InputText.SelectionStart);
            int column = InputText.SelectionStart - InputText.GetFirstCharIndexFromLine(line);

            labelCount.Text = $"Ln {line}, Col {column}";

        }


        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int position = InputText.SelectionStart;
            string value = InputText.Text.Insert(InputText.SelectionStart, Clipboard.GetText());
            InputText.Text = value;
            InputText.SelectionStart = position + Clipboard.GetText().Length;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputText.Text = undoList.Pop();
        }



        private void BlackNotepad_DragDrop(object sender, DragEventArgs e)
        {

            foreach (string format in e.Data.GetFormats())
            {
                MessageBox.Show(format);
            }

        }

    }


}


