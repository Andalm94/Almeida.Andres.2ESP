namespace Sigedu_UTN
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblSigedu = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnProfesor = new System.Windows.Forms.Button();
            this.btnAlumno = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.imgLogin = new System.Windows.Forms.PictureBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSigedu
            // 
            this.lblSigedu.AllowDrop = true;
            this.lblSigedu.AutoSize = true;
            this.lblSigedu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSigedu.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSigedu.Location = new System.Drawing.Point(0, 21);
            this.lblSigedu.Name = "lblSigedu";
            this.lblSigedu.Size = new System.Drawing.Size(217, 25);
            this.lblSigedu.TabIndex = 0;
            this.lblSigedu.Text = "Sistema de Gestión";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(40, 78);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(254, 23);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(40, 146);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(254, 23);
            this.txtPassword.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUser.Location = new System.Drawing.Point(40, 54);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 20);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "Usuario";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPass.Location = new System.Drawing.Point(40, 122);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(92, 20);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Contraseña";
            // 
            // btnProfesor
            // 
            this.btnProfesor.FlatAppearance.BorderSize = 0;
            this.btnProfesor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(175)))));
            this.btnProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnProfesor.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProfesor.Location = new System.Drawing.Point(65, 219);
            this.btnProfesor.Name = "btnProfesor";
            this.btnProfesor.Size = new System.Drawing.Size(83, 57);
            this.btnProfesor.TabIndex = 7;
            this.btnProfesor.Text = "Profesor";
            this.btnProfesor.UseVisualStyleBackColor = true;
            this.btnProfesor.Click += new System.EventHandler(this.btnProfesor_Click);
            // 
            // btnAlumno
            // 
            this.btnAlumno.FlatAppearance.BorderSize = 0;
            this.btnAlumno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(175)))));
            this.btnAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnAlumno.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAlumno.Location = new System.Drawing.Point(147, 219);
            this.btnAlumno.Name = "btnAlumno";
            this.btnAlumno.Size = new System.Drawing.Size(72, 57);
            this.btnAlumno.TabIndex = 8;
            this.btnAlumno.Text = "Alumno";
            this.btnAlumno.UseVisualStyleBackColor = true;
            this.btnAlumno.Click += new System.EventHandler(this.btnAlumno_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(175)))));
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnAdmin.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdmin.Location = new System.Drawing.Point(0, 219);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(70, 57);
            this.btnAdmin.TabIndex = 9;
            this.btnAdmin.Text = "ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // imgLogin
            // 
            this.imgLogin.BackgroundImage = global::Sigedu_UTN.Properties.Resources.logo;
            this.imgLogin.Image = ((System.Drawing.Image)(resources.GetObject("imgLogin.Image")));
            this.imgLogin.Location = new System.Drawing.Point(9, 90);
            this.imgLogin.Name = "imgLogin";
            this.imgLogin.Size = new System.Drawing.Size(178, 93);
            this.imgLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogin.TabIndex = 10;
            this.imgLogin.TabStop = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(175)))));
            this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(175)))));
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIngresar.Location = new System.Drawing.Point(40, 199);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(254, 45);
            this.btnIngresar.TabIndex = 12;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlRight.Controls.Add(this.lblUser);
            this.pnlRight.Controls.Add(this.txtUser);
            this.pnlRight.Controls.Add(this.lblPass);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.btnIngresar);
            this.pnlRight.Location = new System.Drawing.Point(219, 35);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(337, 276);
            this.pnlRight.TabIndex = 15;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(54)))), ((int)(((byte)(74)))));
            this.pnlLeft.Controls.Add(this.btnProfesor);
            this.pnlLeft.Controls.Add(this.btnAlumno);
            this.pnlLeft.Controls.Add(this.btnAdmin);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Controls.Add(this.lblSigedu);
            this.pnlLeft.Controls.Add(this.imgLogin);
            this.pnlLeft.Location = new System.Drawing.Point(0, 35);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(222, 276);
            this.pnlLeft.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(9, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ingresar como:";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Educativa";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(97)))), ((int)(((byte)(175)))));
            this.pnlTop.Controls.Add(this.picSalir);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(556, 35);
            this.pnlTop.TabIndex = 15;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Image = global::Sigedu_UTN.Properties.Resources.btnCerrar2;
            this.picSalir.Location = new System.Drawing.Point(523, 2);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(30, 30);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSalir.TabIndex = 19;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "SIGEDU - Login";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(556, 311);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGEDU - Login";
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblSigedu;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Label lblUser;
        private Label lblPass;
        private Button btnProfesor;
        private Button btnAlumno;
        private Button btnAdmin;
        private PictureBox imgLogin;
        private Button btnIngresar;
        private Panel pnlRight;
        private Panel pnlLeft;
        private Label label1;
        private Panel pnlTop;
        private Label label2;
        private Label label3;
        private PictureBox picSalir;
    }
}