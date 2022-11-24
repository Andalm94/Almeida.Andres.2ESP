namespace Sigedu_UTN
{
    partial class frmAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlumno));
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.btnDarAsistencia = new System.Windows.Forms.Button();
            this.lblMateria = new System.Windows.Forms.Label();
            this.imgAvatar = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabPabel = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgvAprobadas = new System.Windows.Forms.DataGridView();
            this.nombreMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Promedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgvCursando = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnInscripcionMateria = new System.Windows.Forms.Button();
            this.cmbMateriasInscripcion = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarMateriaInscripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgAvatar)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.tabPabel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAprobadas)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCursando)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(6, 281);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(150, 24);
            this.cmbMaterias.TabIndex = 4;
            // 
            // btnDarAsistencia
            // 
            this.btnDarAsistencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(186)))), ((int)(((byte)(255)))));
            this.btnDarAsistencia.FlatAppearance.BorderSize = 0;
            this.btnDarAsistencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDarAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnDarAsistencia.Location = new System.Drawing.Point(6, 311);
            this.btnDarAsistencia.Name = "btnDarAsistencia";
            this.btnDarAsistencia.Size = new System.Drawing.Size(150, 47);
            this.btnDarAsistencia.TabIndex = 1;
            this.btnDarAsistencia.Text = "Dar asistencia";
            this.btnDarAsistencia.UseVisualStyleBackColor = false;
            this.btnDarAsistencia.Click += new System.EventHandler(this.btnDarAsistencia_Click);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMateria.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMateria.Location = new System.Drawing.Point(6, 262);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(150, 16);
            this.lblMateria.TabIndex = 9;
            this.lblMateria.Text = "Seleccionar materia:";
            // 
            // imgAvatar
            // 
            this.imgAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgAvatar.Image = ((System.Drawing.Image)(resources.GetObject("imgAvatar.Image")));
            this.imgAvatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgAvatar.InitialImage")));
            this.imgAvatar.Location = new System.Drawing.Point(12, 6);
            this.imgAvatar.Name = "imgAvatar";
            this.imgAvatar.Size = new System.Drawing.Size(112, 111);
            this.imgAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAvatar.TabIndex = 5;
            this.imgAvatar.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(12, 131);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 16);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "¡Hola --!";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.picSalir);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(591, 35);
            this.pnlTop.TabIndex = 5;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "SIGEDU - Alumnos";
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Image = global::Sigedu_UTN.Properties.Resources.btnCerrar2;
            this.picSalir.Location = new System.Drawing.Point(558, 3);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(30, 30);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSalir.TabIndex = 17;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.pnlLeft.Controls.Add(this.btnCerrarSesion);
            this.pnlLeft.Controls.Add(this.cmbMaterias);
            this.pnlLeft.Controls.Add(this.btnDarAsistencia);
            this.pnlLeft.Controls.Add(this.imgAvatar);
            this.pnlLeft.Controls.Add(this.lblMateria);
            this.pnlLeft.Controls.Add(this.lblNombre);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 35);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(162, 409);
            this.pnlLeft.TabIndex = 6;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 362);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(162, 47);
            this.btnCerrarSesion.TabIndex = 11;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(186)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.tabPabel);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(162, 35);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(429, 409);
            this.pnlRight.TabIndex = 7;
            // 
            // tabPabel
            // 
            this.tabPabel.Controls.Add(this.tabPage2);
            this.tabPabel.Controls.Add(this.tabPage3);
            this.tabPabel.Controls.Add(this.tabPage4);
            this.tabPabel.Location = new System.Drawing.Point(6, 6);
            this.tabPabel.Name = "tabPabel";
            this.tabPabel.SelectedIndex = 0;
            this.tabPabel.Size = new System.Drawing.Size(411, 391);
            this.tabPabel.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgvAprobadas);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(403, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mat. aprobadas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgvAprobadas
            // 
            this.dtgvAprobadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAprobadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreMateria,
            this.nota1,
            this.nota2,
            this.Promedio});
            this.dtgvAprobadas.Location = new System.Drawing.Point(6, 6);
            this.dtgvAprobadas.Name = "dtgvAprobadas";
            this.dtgvAprobadas.RowTemplate.Height = 25;
            this.dtgvAprobadas.Size = new System.Drawing.Size(391, 351);
            this.dtgvAprobadas.TabIndex = 0;
            // 
            // nombreMateria
            // 
            this.nombreMateria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nombreMateria.Frozen = true;
            this.nombreMateria.HeaderText = "Nombre";
            this.nombreMateria.Name = "nombreMateria";
            this.nombreMateria.ReadOnly = true;
            this.nombreMateria.Width = 150;
            // 
            // nota1
            // 
            this.nota1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nota1.Frozen = true;
            this.nota1.HeaderText = "Nota 1";
            this.nota1.Name = "nota1";
            this.nota1.ReadOnly = true;
            this.nota1.Width = 50;
            // 
            // nota2
            // 
            this.nota2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nota2.Frozen = true;
            this.nota2.HeaderText = "Nota 2";
            this.nota2.Name = "nota2";
            this.nota2.ReadOnly = true;
            this.nota2.Width = 50;
            // 
            // Promedio
            // 
            this.Promedio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Promedio.Frozen = true;
            this.Promedio.HeaderText = "Promedio";
            this.Promedio.Name = "Promedio";
            this.Promedio.ReadOnly = true;
            this.Promedio.Width = 95;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgvCursando);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(403, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mat. cursando";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgvCursando
            // 
            this.dtgvCursando.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCursando.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dtgvCursando.Location = new System.Drawing.Point(6, 6);
            this.dtgvCursando.Name = "dtgvCursando";
            this.dtgvCursando.RowTemplate.Height = 25;
            this.dtgvCursando.Size = new System.Drawing.Size(397, 351);
            this.dtgvCursando.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nota 1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Nota 2";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnInscripcionMateria);
            this.tabPage4.Controls.Add(this.cmbMateriasInscripcion);
            this.tabPage4.Controls.Add(this.lblSeleccionarMateriaInscripcion);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(403, 363);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Inscripcion";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnInscripcionMateria
            // 
            this.btnInscripcionMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(186)))), ((int)(((byte)(255)))));
            this.btnInscripcionMateria.FlatAppearance.BorderSize = 0;
            this.btnInscripcionMateria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnInscripcionMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscripcionMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnInscripcionMateria.Location = new System.Drawing.Point(3, 86);
            this.btnInscripcionMateria.Name = "btnInscripcionMateria";
            this.btnInscripcionMateria.Size = new System.Drawing.Size(265, 47);
            this.btnInscripcionMateria.TabIndex = 12;
            this.btnInscripcionMateria.Text = "¡Inscribirme!";
            this.btnInscripcionMateria.UseVisualStyleBackColor = false;
            this.btnInscripcionMateria.Click += new System.EventHandler(this.btnInscripcionMateria_Click);
            // 
            // cmbMateriasInscripcion
            // 
            this.cmbMateriasInscripcion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbMateriasInscripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMateriasInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbMateriasInscripcion.FormattingEnabled = true;
            this.cmbMateriasInscripcion.Location = new System.Drawing.Point(3, 32);
            this.cmbMateriasInscripcion.Name = "cmbMateriasInscripcion";
            this.cmbMateriasInscripcion.Size = new System.Drawing.Size(265, 24);
            this.cmbMateriasInscripcion.TabIndex = 10;
            // 
            // lblSeleccionarMateriaInscripcion
            // 
            this.lblSeleccionarMateriaInscripcion.AutoSize = true;
            this.lblSeleccionarMateriaInscripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionarMateriaInscripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSeleccionarMateriaInscripcion.Location = new System.Drawing.Point(3, 13);
            this.lblSeleccionarMateriaInscripcion.Name = "lblSeleccionarMateriaInscripcion";
            this.lblSeleccionarMateriaInscripcion.Size = new System.Drawing.Size(265, 16);
            this.lblSeleccionarMateriaInscripcion.TabIndex = 11;
            this.lblSeleccionarMateriaInscripcion.Text = "Seleccionar materia para inscripcion:";
            // 
            // frmAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 444);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alumno";
            ((System.ComponentModel.ISupportInitialize)(this.imgAvatar)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.tabPabel.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAprobadas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCursando)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnDarAsistencia;
        private Label lblMateria;
        private ComboBox cmbMaterias;
        private Label lblNombre;
        private PictureBox imgAvatar;
        private Panel pnlTop;
        private Label label4;
        private Panel pnlLeft;
        private Panel pnlRight;
        private PictureBox picSalir;
        private Button btnCerrarSesion;
        private TabControl tabPabel;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dtgvAprobadas;
        private DataGridView dtgvCursando;
        private DataGridViewTextBoxColumn nombreMateria;
        private DataGridViewTextBoxColumn nota1;
        private DataGridViewTextBoxColumn nota2;
        private DataGridViewTextBoxColumn Promedio;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private ComboBox cmbMateriasInscripcion;
        private Label lblSeleccionarMateriaInscripcion;
        private Button btnInscripcionMateria;
    }
}