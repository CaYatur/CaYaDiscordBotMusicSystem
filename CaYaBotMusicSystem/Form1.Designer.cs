namespace CaYaBotMusicSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtChannelId = new TextBox();
            txtMusicUrl = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            button6 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button7 = new Button();
            label4 = new Label();
            checkBox1 = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtChannelId
            // 
            txtChannelId.Location = new Point(23, 9);
            txtChannelId.Name = "txtChannelId";
            txtChannelId.Size = new Size(273, 23);
            txtChannelId.TabIndex = 0;
            txtChannelId.Text = "Lütfen Ses Kanalının ID sini Giriniz.";
            txtChannelId.Click += txtChannelId_Click;
            txtChannelId.TextChanged += txtChannelId_TextChanged;
            // 
            // txtMusicUrl
            // 
            txtMusicUrl.Location = new Point(23, 38);
            txtMusicUrl.Name = "txtMusicUrl";
            txtMusicUrl.Size = new Size(614, 23);
            txtMusicUrl.TabIndex = 1;
            txtMusicUrl.Text = "Lütfen Ses Dosyasının Yolunu Giriniz.";
            txtMusicUrl.Click += txtMusicUrl_Click;
            txtMusicUrl.TextChanged += txtMusicUrl_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(302, 8);
            button1.Name = "button1";
            button1.Size = new Size(165, 23);
            button1.TabIndex = 2;
            button1.Text = "Ses Kanalına Katıl";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnConnect_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(473, 8);
            button2.Name = "button2";
            button2.Size = new Size(164, 23);
            button2.TabIndex = 3;
            button2.Text = "Ses Kanalından Ayrıl";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDisconnect_Click;
            // 
            // button3
            // 
            button3.Location = new Point(643, 38);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Oynat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnPlay_Click;
            // 
            // button4
            // 
            button4.Location = new Point(724, 8);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += btnPause_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(724, 37);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 6;
            button5.Text = "Kapat";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnStop_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(634, 23);
            textBox1.TabIndex = 7;
            textBox1.UseSystemPasswordChar = true;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button6
            // 
            button6.Location = new Point(652, 82);
            button6.Name = "button6";
            button6.Size = new Size(136, 23);
            button6.TabIndex = 8;
            button6.Text = "Giriş yap";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(txtChannelId);
            panel1.Controls.Add(txtMusicUrl);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(-13, 101);
            panel1.Name = "panel1";
            panel1.Size = new Size(974, 68);
            panel1.TabIndex = 9;
            panel1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(12, 64);
            label1.Name = "label1";
            label1.Size = new Size(179, 15);
            label1.TabIndex = 10;
            label1.Text = "Lütfen Discord Bot Token Giriniz.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(406, 37);
            label2.TabIndex = 11;
            label2.Text = "CaYa Özel Müzik Bot Programı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(21, 46);
            label3.Name = "label3";
            label3.Size = new Size(220, 15);
            label3.TabIndex = 12;
            label3.Text = "Discord: https://discord.gg/ybRvvC4KTp";
            label3.Click += label3_Click;
            label3.MouseEnter += label3_MouseEnter;
            label3.MouseLeave += label3_MouseLeave;
            // 
            // button7
            // 
            button7.BackColor = Color.Brown;
            button7.ForeColor = Color.White;
            button7.Location = new Point(672, 9);
            button7.Name = "button7";
            button7.Size = new Size(116, 52);
            button7.TabIndex = 13;
            button7.Text = "Tüm Kullanıcı Verilerini Temizle";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(21, 61);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 14;
            label4.Text = "Bağlanılan Bot: NULL";
            label4.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(711, 8);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(88, 19);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Komik mod";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._102;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 168);
            Controls.Add(label4);
            Controls.Add(button7);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(button6);
            Controls.Add(textBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CaYa Komik Müzik Botu";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtChannelId;
        private TextBox txtMusicUrl;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBox1;
        private Button button6;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button7;
        private Label label4;
        private CheckBox checkBox1;
    }
}