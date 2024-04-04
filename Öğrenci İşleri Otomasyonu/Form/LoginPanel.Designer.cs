namespace Öğrenci_İşleri_Otomasyonu.Form
{
    partial class LoginPanel
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPanel));
            materialCard7 = new MaterialSkin.Controls.MaterialCard();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            userPasswordTxt = new MaterialSkin.Controls.MaterialTextBox();
            userCitionTxt = new MaterialSkin.Controls.MaterialTextBox();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            pictureBox1 = new PictureBox();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            pictureBox2 = new PictureBox();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            pictureBox3 = new PictureBox();
            ımageList1 = new ImageList(components);
            materialCard7.SuspendLayout();
            materialCard1.SuspendLayout();
            materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            materialCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            materialCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // materialCard7
            // 
            materialCard7.BackColor = Color.FromArgb(255, 255, 255);
            materialCard7.Controls.Add(materialButton1);
            materialCard7.Controls.Add(userPasswordTxt);
            materialCard7.Controls.Add(userCitionTxt);
            materialCard7.Depth = 0;
            materialCard7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard7.Location = new Point(41, 111);
            materialCard7.Margin = new Padding(14);
            materialCard7.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard7.Name = "materialCard7";
            materialCard7.Padding = new Padding(14);
            materialCard7.Size = new Size(329, 250);
            materialCard7.TabIndex = 14;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(78, 194);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(165, 36);
            materialButton1.TabIndex = 3;
            materialButton1.Text = "Giriş Yap";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // userPasswordTxt
            // 
            userPasswordTxt.AnimateReadOnly = false;
            userPasswordTxt.BorderStyle = BorderStyle.None;
            userPasswordTxt.Depth = 0;
            userPasswordTxt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            userPasswordTxt.Hint = "Şifre";
            userPasswordTxt.LeadingIcon = null;
            userPasswordTxt.Location = new Point(17, 117);
            userPasswordTxt.MaxLength = 50;
            userPasswordTxt.MouseState = MaterialSkin.MouseState.OUT;
            userPasswordTxt.Multiline = false;
            userPasswordTxt.Name = "userPasswordTxt";
            userPasswordTxt.Password = true;
            userPasswordTxt.Size = new Size(295, 50);
            userPasswordTxt.TabIndex = 2;
            userPasswordTxt.Text = "";
            userPasswordTxt.TrailingIcon = null;
            // 
            // userCitionTxt
            // 
            userCitionTxt.AnimateReadOnly = false;
            userCitionTxt.BorderStyle = BorderStyle.None;
            userCitionTxt.Depth = 0;
            userCitionTxt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            userCitionTxt.Hint = "Tc Kimlik No";
            userCitionTxt.LeadingIcon = null;
            userCitionTxt.Location = new Point(17, 43);
            userCitionTxt.MaxLength = 50;
            userCitionTxt.MouseState = MaterialSkin.MouseState.OUT;
            userCitionTxt.Multiline = false;
            userCitionTxt.Name = "userCitionTxt";
            userCitionTxt.Size = new Size(295, 50);
            userCitionTxt.TabIndex = 1;
            userCitionTxt.Text = "";
            userCitionTxt.TrailingIcon = null;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialCard7);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 64);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(411, 500);
            materialCard1.TabIndex = 15;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.BackgroundImage = (Image)resources.GetObject("materialCard2.BackgroundImage");
            materialCard2.Controls.Add(pictureBox1);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(433, 87);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(368, 134);
            materialCard2.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(340, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(pictureBox2);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(433, 249);
            materialCard3.Margin = new Padding(14);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14);
            materialCard3.Size = new Size(368, 134);
            materialCard3.TabIndex = 17;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 14);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(340, 106);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(pictureBox3);
            materialCard4.Depth = 0;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(433, 411);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(368, 134);
            materialCard4.TabIndex = 17;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(14, 14);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(340, 106);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // ımageList1
            // 
            ımageList1.ColorDepth = ColorDepth.Depth32Bit;
            ımageList1.ImageSize = new Size(16, 16);
            ımageList1.TransparentColor = Color.Transparent;
            // 
            // LoginPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 562);
            Controls.Add(materialCard4);
            Controls.Add(materialCard3);
            Controls.Add(materialCard2);
            Controls.Add(materialCard1);
            Name = "LoginPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Öğrenci İşleri Giriş Alanı";
            materialCard7.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            materialCard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            materialCard4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard7;
        public MaterialSkin.Controls.MaterialTextBox userPasswordTxt;
        public MaterialSkin.Controls.MaterialTextBox userCitionTxt;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private ImageList ımageList1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}