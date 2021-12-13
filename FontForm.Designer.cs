namespace BlackNotepad
{
    partial class FontForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxFontFamily = new System.Windows.Forms.ListBox();
            this.listBoxFontStyle = new System.Windows.Forms.ListBox();
            this.listBoxFontSize = new System.Windows.Forms.ListBox();
            this.TextBoxFontFamily = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.TextBoxFontSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextExample = new System.Windows.Forms.Label();
            this.OkeyButton = new System.Windows.Forms.Button();
            this.Cancelfont = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxFontFamily
            // 
            this.listBoxFontFamily.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxFontFamily.FormattingEnabled = true;
            this.listBoxFontFamily.Location = new System.Drawing.Point(12, 111);
            this.listBoxFontFamily.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.listBoxFontFamily.Name = "listBoxFontFamily";
            this.listBoxFontFamily.Size = new System.Drawing.Size(139, 125);
            this.listBoxFontFamily.TabIndex = 0;
            this.listBoxFontFamily.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFontFamily_DrawItem);
            this.listBoxFontFamily.SelectedValueChanged += new System.EventHandler(this.listBoxFontFamily_SelectedValueChanged);
            // 
            // listBoxFontStyle
            // 
            this.listBoxFontStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxFontStyle.FormattingEnabled = true;
            this.listBoxFontStyle.Location = new System.Drawing.Point(177, 115);
            this.listBoxFontStyle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.listBoxFontStyle.Name = "listBoxFontStyle";
            this.listBoxFontStyle.Size = new System.Drawing.Size(129, 121);
            this.listBoxFontStyle.TabIndex = 1;
            this.listBoxFontStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFontStyle_DrawItem);
            this.listBoxFontStyle.SelectedIndexChanged += new System.EventHandler(this.listBoxFontStyle_SelectedIndexChanged);
            // 
            // listBoxFontSize
            // 
            this.listBoxFontSize.FormattingEnabled = true;
            this.listBoxFontSize.Location = new System.Drawing.Point(338, 115);
            this.listBoxFontSize.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.listBoxFontSize.Name = "listBoxFontSize";
            this.listBoxFontSize.Size = new System.Drawing.Size(60, 95);
            this.listBoxFontSize.TabIndex = 2;
            this.listBoxFontSize.SelectedValueChanged += new System.EventHandler(this.listBoxFontSize_SelectedValueChanged);
            // 
            // TextBoxFontFamily
            // 
            this.TextBoxFontFamily.Location = new System.Drawing.Point(12, 91);
            this.TextBoxFontFamily.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.TextBoxFontFamily.Name = "TextBoxFontFamily";
            this.TextBoxFontFamily.Size = new System.Drawing.Size(139, 20);
            this.TextBoxFontFamily.TabIndex = 4;
            this.TextBoxFontFamily.TextChanged += new System.EventHandler(this.TextBoxFontFamily_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(177, 95);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 20);
            this.textBox2.TabIndex = 5;
            // 
            // TextBoxFontSize
            // 
            this.TextBoxFontSize.Location = new System.Drawing.Point(338, 95);
            this.TextBoxFontSize.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.TextBoxFontSize.Name = "TextBoxFontSize";
            this.TextBoxFontSize.Size = new System.Drawing.Size(60, 20);
            this.TextBoxFontSize.TabIndex = 6;
            this.TextBoxFontSize.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Font";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(398, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "✕";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(1, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(430, 2);
            this.label2.TabIndex = 12;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 28);
            this.panel1.TabIndex = 13;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Font:";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(174, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Font Style:";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(335, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Size:";
            // 
            // TextExample
            // 
            this.TextExample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TextExample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TextExample.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TextExample.Location = new System.Drawing.Point(274, 275);
            this.TextExample.Name = "TextExample";
            this.TextExample.Padding = new System.Windows.Forms.Padding(5);
            this.TextExample.Size = new System.Drawing.Size(114, 59);
            this.TextExample.TabIndex = 17;
            this.TextExample.Text = "AbCdEfG";
            // 
            // OkeyButton
            // 
            this.OkeyButton.Location = new System.Drawing.Point(242, 415);
            this.OkeyButton.Name = "OkeyButton";
            this.OkeyButton.Size = new System.Drawing.Size(75, 23);
            this.OkeyButton.TabIndex = 18;
            this.OkeyButton.Text = "Ok";
            this.OkeyButton.UseVisualStyleBackColor = true;
            this.OkeyButton.Click += new System.EventHandler(this.OkeyButton_Click);
            // 
            // Cancelfont
            // 
            this.Cancelfont.Location = new System.Drawing.Point(338, 415);
            this.Cancelfont.Name = "Cancelfont";
            this.Cancelfont.Size = new System.Drawing.Size(75, 23);
            this.Cancelfont.TabIndex = 19;
            this.Cancelfont.Text = "Cancel";
            this.Cancelfont.UseVisualStyleBackColor = true;
            this.Cancelfont.Click += new System.EventHandler(this.Cancelfont_Click);
            // 
            // FontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(430, 470);
            this.Controls.Add(this.Cancelfont);
            this.Controls.Add(this.OkeyButton);
            this.Controls.Add(this.TextExample);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TextBoxFontSize);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.TextBoxFontFamily);
            this.Controls.Add(this.listBoxFontSize);
            this.Controls.Add(this.listBoxFontStyle);
            this.Controls.Add(this.listBoxFontFamily);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FontForm";
            this.Text = "FontForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FontForm_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFontFamily;
        private System.Windows.Forms.ListBox listBoxFontStyle;
        private System.Windows.Forms.ListBox listBoxFontSize;
        private System.Windows.Forms.TextBox TextBoxFontFamily;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox TextBoxFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TextExample;
        private System.Windows.Forms.Button OkeyButton;
        private System.Windows.Forms.Button Cancelfont;
    }
}