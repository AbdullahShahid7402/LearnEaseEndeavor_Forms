
namespace LearnEaseEndeavor_Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.EmailPrompt = new System.Windows.Forms.Label();
            this.PasswordPrompt = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.Validate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ErrorLable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailPrompt
            // 
            this.EmailPrompt.AutoSize = true;
            this.EmailPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailPrompt.Location = new System.Drawing.Point(276, 272);
            this.EmailPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailPrompt.Name = "EmailPrompt";
            this.EmailPrompt.Size = new System.Drawing.Size(131, 46);
            this.EmailPrompt.TabIndex = 0;
            this.EmailPrompt.Text = "Email:";
            this.EmailPrompt.Click += new System.EventHandler(this.label1_Click);
            // 
            // PasswordPrompt
            // 
            this.PasswordPrompt.AutoSize = true;
            this.PasswordPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordPrompt.Location = new System.Drawing.Point(196, 397);
            this.PasswordPrompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordPrompt.Name = "PasswordPrompt";
            this.PasswordPrompt.Size = new System.Drawing.Size(207, 46);
            this.PasswordPrompt.TabIndex = 1;
            this.PasswordPrompt.Text = "Password:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.Location = new System.Drawing.Point(418, 262);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(553, 53);
            this.EmailTextBox.TabIndex = 2;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(418, 386);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(553, 53);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // Validate
            // 
            this.Validate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Validate.Location = new System.Drawing.Point(831, 517);
            this.Validate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Validate.Name = "Validate";
            this.Validate.Size = new System.Drawing.Size(140, 60);
            this.Validate.TabIndex = 4;
            this.Validate.Text = "Login";
            this.Validate.UseVisualStyleBackColor = true;
            this.Validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(540, 77);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // ErrorLable
            // 
            this.ErrorLable.AutoSize = true;
            this.ErrorLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLable.ForeColor = System.Drawing.Color.Red;
            this.ErrorLable.Location = new System.Drawing.Point(540, 548);
            this.ErrorLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorLable.Name = "ErrorLable";
            this.ErrorLable.Size = new System.Drawing.Size(0, 29);
            this.ErrorLable.TabIndex = 6;
            this.ErrorLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 517);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 60);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ErrorLable);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Validate);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PasswordPrompt);
            this.Controls.Add(this.EmailPrompt);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.Text = "L E E";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EmailPrompt;
        private System.Windows.Forms.Label PasswordPrompt;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button Validate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ErrorLable;
        private System.Windows.Forms.Button button1;
    }
}

