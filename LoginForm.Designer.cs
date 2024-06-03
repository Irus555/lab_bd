﻿namespace Authorization
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.AuthorizationText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.SignIn = new System.Windows.Forms.Button();
            this.RegistrationButton = new System.Windows.Forms.Label();
            this.Tests_button = new System.Windows.Forms.Button();
            this.PassShow = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PassHide = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PassShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassHide)).BeginInit();
            this.SuspendLayout();
            // 
            // AuthorizationText
            // 
            this.AuthorizationText.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AuthorizationText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AuthorizationText.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.AuthorizationText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthorizationText.Font = new System.Drawing.Font("Times New Roman", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthorizationText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AuthorizationText.Location = new System.Drawing.Point(0, 0);
            this.AuthorizationText.Name = "AuthorizationText";
            this.AuthorizationText.Size = new System.Drawing.Size(334, 100);
            this.AuthorizationText.TabIndex = 0;
            this.AuthorizationText.Text = "Authorization";
            this.AuthorizationText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AuthorizationText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AuthorizationText_MouseDown);
            this.AuthorizationText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AuthorizationText_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Controls.Add(this.AuthorizationText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 100);
            this.panel1.TabIndex = 5;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Exit.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.Exit.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(160)))), ((int)(((byte)(210)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ForeColor = System.Drawing.SystemColors.Control;
            this.Exit.Location = new System.Drawing.Point(301, 1);
            this.Exit.Margin = new System.Windows.Forms.Padding(1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(32, 34);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "x";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Times New Roman", 16.25F);
            this.Password.Location = new System.Drawing.Point(72, 180);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(216, 32);
            this.Password.TabIndex = 1;
            this.Password.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Times New Roman", 16.25F);
            this.Login.Location = new System.Drawing.Point(72, 140);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(216, 32);
            this.Login.TabIndex = 0;
            this.Login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            this.Login.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Login_KeyUp);
            // 
            // SignIn
            // 
            this.SignIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SignIn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.SignIn.FlatAppearance.BorderSize = 0;
            this.SignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SignIn.Font = new System.Drawing.Font("Times New Roman", 14.75F);
            this.SignIn.Location = new System.Drawing.Point(72, 280);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(80, 32);
            this.SignIn.TabIndex = 3;
            this.SignIn.Text = "Sign in";
            this.SignIn.UseVisualStyleBackColor = false;
            this.SignIn.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.AutoSize = true;
            this.RegistrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistrationButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RegistrationButton.Location = new System.Drawing.Point(124, 224);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(107, 22);
            this.RegistrationButton.TabIndex = 2;
            this.RegistrationButton.Text = "Registration";
            this.RegistrationButton.Click += new System.EventHandler(this.RegistrationButton_Click);
            // 
            // Tests_button
            // 
            this.Tests_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Tests_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tests_button.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.Tests_button.FlatAppearance.BorderSize = 0;
            this.Tests_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Tests_button.Font = new System.Drawing.Font("Times New Roman", 14.75F);
            this.Tests_button.Location = new System.Drawing.Point(208, 280);
            this.Tests_button.Name = "Tests_button";
            this.Tests_button.Size = new System.Drawing.Size(80, 32);
            this.Tests_button.TabIndex = 11;
            this.Tests_button.Text = "Tests";
            this.Tests_button.UseVisualStyleBackColor = false;
            this.Tests_button.Click += new System.EventHandler(this.Tests_button_Click);
            // 
            // PassShow
            // 
            this.PassShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PassShow.Image = global::Authorization.Properties.Resources.hide_view_gray;
            this.PassShow.Location = new System.Drawing.Point(292, 180);
            this.PassShow.Name = "PassShow";
            this.PassShow.Size = new System.Drawing.Size(32, 32);
            this.PassShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PassShow.TabIndex = 10;
            this.PassShow.TabStop = false;
            this.PassShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PassShow_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(32, 180);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PassHide
            // 
            this.PassHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PassHide.Image = ((System.Drawing.Image)(resources.GetObject("PassHide.Image")));
            this.PassHide.Location = new System.Drawing.Point(292, 180);
            this.PassHide.Name = "PassHide";
            this.PassHide.Size = new System.Drawing.Size(32, 32);
            this.PassHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PassHide.TabIndex = 12;
            this.PassHide.TabStop = false;
            this.PassHide.Click += new System.EventHandler(this.PassHide_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.Tests_button);
            this.Controls.Add(this.RegistrationButton);
            this.Controls.Add(this.SignIn);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PassShow);
            this.Controls.Add(this.PassHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PassShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AuthorizationText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SignIn;
        private System.Windows.Forms.Label RegistrationButton;
        private System.Windows.Forms.PictureBox PassShow;
        private System.Windows.Forms.Button Tests_button;
        private System.Windows.Forms.PictureBox PassHide;
    }
}

