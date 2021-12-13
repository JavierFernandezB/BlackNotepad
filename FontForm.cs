using System;
using System.Collections.Generic;
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

        private readonly List<string> fontFamily = new List<string>();
        private readonly int[] FontSize = new int[16] { 8, 9, 19, 11, 12, 14, 16, 20, 22, 24, 26, 28, 36, 48, 72, 100 };
        private readonly List<string> fontStyles = new List<string>() { "BoldAndItalic", "Bold", "Italic", "Normal" };
        private static string FontFamilyString = "Arial";
        private static string FontStyleString = "Normal";
        private static int FontSizeString = 14;



        public FontForm()
        {
            InitializeComponent();

            TextExample.Font = new Font(new FontFamily(FontFamilyString), FontSizeString, BlackNotepad.getFont(FontStyleString));
            setFontFamilyDefault();
            foreach (int size in FontSize)
            {
                listBoxFontSize.Items.Add(size.ToString());
            }
            foreach (string styles in fontStyles)
            {
                listBoxFontStyle.Items.Add(styles);
            }

        }

        private void setFontFamilyDefault()
        {

            fontFamily.Clear();
            using (InstalledFontCollection col = new InstalledFontCollection())
            {
                foreach (FontFamily fa in col.Families)
                {
                    listBoxFontFamily.Items.Add(fa.Name);
                    fontFamily.Add(fa.Name);

                }

            }
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
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
                           DisplayRectangle);
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

        private void Button1_Click_1(object sender, EventArgs e)
        {
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

        private void TextBoxFontFamily_TextChanged(object sender, EventArgs e)
        {
            listBoxFontFamily.Items.Clear();

            foreach (string str in fontFamily)
            {
                if (str.StartsWith(TextBoxFontFamily.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBoxFontFamily.Items.Add(str);
                }
                if (str.Equals(TextBoxFontFamily.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBoxFontFamily.SelectedItem = str;
                }
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listBoxFontSize.Items.Clear();

            foreach (int str in FontSize)
            {
                if (str.ToString().StartsWith(TextBoxFontSize.Text))
                {
                    listBoxFontSize.Items.Add(str);
                }
                if (str.ToString().Equals(TextBoxFontSize.Text))
                {
                    listBoxFontSize.SelectedItem = str;
                }
            }
        }

        private void listBoxFontFamily_SelectedValueChanged(object sender, EventArgs e)
        {

            string font = (string)listBoxFontFamily.SelectedItem;
            FontFamilyString = font;
            TextExample.Font = new Font(new FontFamily(FontFamilyString), FontSizeString, BlackNotepad.getFont(FontStyleString));
        }

        private void OkeyButton_Click(object sender, EventArgs e)
        {
            if (listBoxFontFamily.SelectedItem != null)
            {
                BlackNotepad.FontFamily = listBoxFontFamily.SelectedItem.ToString();

            }
            if (listBoxFontSize.SelectedItem != null)
            {
                BlackNotepad.FontSize = int.Parse(listBoxFontSize.SelectedItem.ToString());
            }
            if (listBoxFontStyle.SelectedItem != null)
            {
                BlackNotepad.FontStyles = listBoxFontStyle.SelectedItem.ToString();
            }

            Close();

        }



        private void listBoxFontFamily_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(e.Graphics, listBoxFontFamily.Items[e.Index].ToString(), new Font(listBoxFontFamily.Items[e.Index].ToString(), 8, FontStyle.Regular), e.Bounds, Color.Black, flags);
            e.DrawFocusRectangle();
        }

        private void listBoxFontStyle_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(e.Graphics, listBoxFontStyle.Items[e.Index].ToString(), new Font("Arial", 8, BlackNotepad.getFont(listBoxFontStyle.Items[e.Index].ToString())), e.Bounds, Color.Black, flags);
            e.DrawFocusRectangle();
        }

        private void listBoxFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string style = (string)listBoxFontStyle.SelectedItem;
            FontStyleString = style;
            TextExample.Font = new Font(new FontFamily(FontFamilyString), FontSizeString, BlackNotepad.getFont(FontStyleString));
        }

        private void listBoxFontSize_SelectedValueChanged(object sender, EventArgs e)
        {
            string size = (string)listBoxFontSize.SelectedItem;
            FontSizeString = int.Parse(size);
            TextExample.Font = new Font(new FontFamily(FontFamilyString), FontSizeString, BlackNotepad.getFont(FontStyleString));
        }


        private void Cancelfont_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
