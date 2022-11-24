namespace Sigedu_UTN
{
    partial class frmProfesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfesor));
            this.listMaterias = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.imgAvatar = new System.Windows.Forms.PictureBox();
            this.grpCrearExamen = new System.Windows.Forms.GroupBox();
            this.txtNombreExamen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearExamen = new System.Windows.Forms.Button();
            this.lblMateria = new System.Windows.Forms.Label();
            this.dttFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.grpCorregirExamen = new System.Windows.Forms.GroupBox();
            this.lblSeleccionarMateriaCorregirExamen = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblUltimaNota = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUltimoCalificado = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numNota = new System.Windows.Forms.NumericUpDown();
            this.cmbAlumnosEvaluados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblExamenFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbExamenes = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabOpciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.picSalir = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgAvatar)).BeginInit();
            this.grpCrearExamen.SuspendLayout();
            this.grpCorregirExamen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNota)).BeginInit();
            this.tabOpciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // listMaterias
            // 
            this.listMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listMaterias.FormattingEnabled = true;
            this.listMaterias.ItemHeight = 16;
            this.listMaterias.Location = new System.Drawing.Point(6, 74);
            this.listMaterias.Name = "listMaterias";
            this.listMaterias.Size = new System.Drawing.Size(149, 292);
            this.listMaterias.Sorted = true;
            this.listMaterias.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(184)))), ((int)(((byte)(16)))));
            this.label7.Location = new System.Drawing.Point(52, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 24);
            this.label7.TabIndex = 9;
            this.label7.Text = "Profesor";
            // 
            // txtMail
            // 
            this.txtMail.AutoEllipsis = true;
            this.txtMail.AutoSize = true;
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(184)))), ((int)(((byte)(16)))));
            this.txtMail.Location = new System.Drawing.Point(12, 245);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(36, 16);
            this.txtMail.TabIndex = 3;
            this.txtMail.Text = "Mail";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoEllipsis = true;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(184)))), ((int)(((byte)(16)))));
            this.lblNombre.Location = new System.Drawing.Point(12, 188);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(66, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // imgAvatar
            // 
            this.imgAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgAvatar.Image = global::Sigedu_UTN.Properties.Resources.avatarProfesor;
            this.imgAvatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgAvatar.InitialImage")));
            this.imgAvatar.Location = new System.Drawing.Point(26, 12);
            this.imgAvatar.Name = "imgAvatar";
            this.imgAvatar.Size = new System.Drawing.Size(132, 122);
            this.imgAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgAvatar.TabIndex = 0;
            this.imgAvatar.TabStop = false;
            // 
            // grpCrearExamen
            // 
            this.grpCrearExamen.Controls.Add(this.txtNombreExamen);
            this.grpCrearExamen.Controls.Add(this.label1);
            this.grpCrearExamen.Controls.Add(this.btnCrearExamen);
            this.grpCrearExamen.Controls.Add(this.lblMateria);
            this.grpCrearExamen.Controls.Add(this.dttFecha);
            this.grpCrearExamen.Controls.Add(this.listMaterias);
            this.grpCrearExamen.Controls.Add(this.lblFecha);
            this.grpCrearExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpCrearExamen.Location = new System.Drawing.Point(6, 6);
            this.grpCrearExamen.Name = "grpCrearExamen";
            this.grpCrearExamen.Size = new System.Drawing.Size(363, 382);
            this.grpCrearExamen.TabIndex = 2;
            this.grpCrearExamen.TabStop = false;
            this.grpCrearExamen.Text = "Crear examen";
            // 
            // txtNombreExamen
            // 
            this.txtNombreExamen.Location = new System.Drawing.Point(196, 74);
            this.txtNombreExamen.Name = "txtNombreExamen";
            this.txtNombreExamen.Size = new System.Drawing.Size(144, 24);
            this.txtNombreExamen.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(196, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre del examen";
            // 
            // btnCrearExamen
            // 
            this.btnCrearExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCrearExamen.Location = new System.Drawing.Point(196, 306);
            this.btnCrearExamen.Name = "btnCrearExamen";
            this.btnCrearExamen.Size = new System.Drawing.Size(144, 61);
            this.btnCrearExamen.TabIndex = 1;
            this.btnCrearExamen.Text = "Crear exámen";
            this.btnCrearExamen.UseVisualStyleBackColor = true;
            this.btnCrearExamen.Click += new System.EventHandler(this.btnCrearExamen_Click);
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMateria.Location = new System.Drawing.Point(6, 48);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(130, 16);
            this.lblMateria.TabIndex = 9;
            this.lblMateria.Text = "Seleccionar materia:";
            // 
            // dttFecha
            // 
            this.dttFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dttFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttFecha.Location = new System.Drawing.Point(196, 203);
            this.dttFecha.Name = "dttFecha";
            this.dttFecha.Size = new System.Drawing.Size(144, 22);
            this.dttFecha.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFecha.Location = new System.Drawing.Point(196, 172);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 16);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha";
            // 
            // btnCalificar
            // 
            this.btnCalificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalificar.Location = new System.Drawing.Point(11, 322);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(342, 48);
            this.btnCalificar.TabIndex = 2;
            this.btnCalificar.Text = "Cargar nota";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click);
            // 
            // grpCorregirExamen
            // 
            this.grpCorregirExamen.Controls.Add(this.lblSeleccionarMateriaCorregirExamen);
            this.grpCorregirExamen.Controls.Add(this.cmbMateria);
            this.grpCorregirExamen.Controls.Add(this.lblUltimaNota);
            this.grpCorregirExamen.Controls.Add(this.label8);
            this.grpCorregirExamen.Controls.Add(this.label3);
            this.grpCorregirExamen.Controls.Add(this.lblUltimoCalificado);
            this.grpCorregirExamen.Controls.Add(this.label6);
            this.grpCorregirExamen.Controls.Add(this.numNota);
            this.grpCorregirExamen.Controls.Add(this.cmbAlumnosEvaluados);
            this.grpCorregirExamen.Controls.Add(this.label4);
            this.grpCorregirExamen.Controls.Add(this.lblExamenFecha);
            this.grpCorregirExamen.Controls.Add(this.label2);
            this.grpCorregirExamen.Controls.Add(this.btnCalificar);
            this.grpCorregirExamen.Controls.Add(this.cmbExamenes);
            this.grpCorregirExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpCorregirExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpCorregirExamen.Location = new System.Drawing.Point(6, 6);
            this.grpCorregirExamen.Name = "grpCorregirExamen";
            this.grpCorregirExamen.Size = new System.Drawing.Size(363, 376);
            this.grpCorregirExamen.TabIndex = 4;
            this.grpCorregirExamen.TabStop = false;
            this.grpCorregirExamen.Text = "Corregir exámen";
            // 
            // lblSeleccionarMateriaCorregirExamen
            // 
            this.lblSeleccionarMateriaCorregirExamen.AutoSize = true;
            this.lblSeleccionarMateriaCorregirExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionarMateriaCorregirExamen.Location = new System.Drawing.Point(17, 41);
            this.lblSeleccionarMateriaCorregirExamen.Name = "lblSeleccionarMateriaCorregirExamen";
            this.lblSeleccionarMateriaCorregirExamen.Size = new System.Drawing.Size(127, 16);
            this.lblSeleccionarMateriaCorregirExamen.TabIndex = 28;
            this.lblSeleccionarMateriaCorregirExamen.Text = "Seleccionar materia";
            // 
            // cmbMateria
            // 
            this.cmbMateria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(14, 67);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(136, 23);
            this.cmbMateria.TabIndex = 27;
            this.cmbMateria.TextChanged += new System.EventHandler(this.cmbMateria_TextChanged);
            // 
            // lblUltimaNota
            // 
            this.lblUltimaNota.AutoSize = true;
            this.lblUltimaNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUltimaNota.Location = new System.Drawing.Point(11, 202);
            this.lblUltimaNota.Name = "lblUltimaNota";
            this.lblUltimaNota.Size = new System.Drawing.Size(61, 16);
            this.lblUltimaNota.TabIndex = 26;
            this.lblUltimaNota.Text = "                  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(7, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(347, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "--------------------------------------------------------------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "--------------------------------------------------------------------";
            // 
            // lblUltimoCalificado
            // 
            this.lblUltimoCalificado.AutoSize = true;
            this.lblUltimoCalificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUltimoCalificado.Location = new System.Drawing.Point(11, 171);
            this.lblUltimoCalificado.Name = "lblUltimoCalificado";
            this.lblUltimoCalificado.Size = new System.Drawing.Size(61, 16);
            this.lblUltimoCalificado.TabIndex = 23;
            this.lblUltimoCalificado.Text = "                  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(186, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Calificacion:";
            // 
            // numNota
            // 
            this.numNota.DecimalPlaces = 1;
            this.numNota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numNota.Location = new System.Drawing.Point(277, 284);
            this.numNota.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numNota.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNota.Name = "numNota";
            this.numNota.Size = new System.Drawing.Size(45, 23);
            this.numNota.TabIndex = 3;
            this.numNota.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbAlumnosEvaluados
            // 
            this.cmbAlumnosEvaluados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbAlumnosEvaluados.FormattingEnabled = true;
            this.cmbAlumnosEvaluados.Location = new System.Drawing.Point(11, 283);
            this.cmbAlumnosEvaluados.Name = "cmbAlumnosEvaluados";
            this.cmbAlumnosEvaluados.Size = new System.Drawing.Size(141, 23);
            this.cmbAlumnosEvaluados.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(11, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Seleccione un alumno";
            // 
            // lblExamenFecha
            // 
            this.lblExamenFecha.AutoSize = true;
            this.lblExamenFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExamenFecha.Location = new System.Drawing.Point(11, 108);
            this.lblExamenFecha.Name = "lblExamenFecha";
            this.lblExamenFecha.Size = new System.Drawing.Size(48, 16);
            this.lblExamenFecha.TabIndex = 14;
            this.lblExamenFecha.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(189, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Seleccionar examen:";
            // 
            // cmbExamenes
            // 
            this.cmbExamenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbExamenes.FormattingEnabled = true;
            this.cmbExamenes.Location = new System.Drawing.Point(186, 67);
            this.cmbExamenes.Name = "cmbExamenes";
            this.cmbExamenes.Size = new System.Drawing.Size(136, 23);
            this.cmbExamenes.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(155)))), ((int)(((byte)(219)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(184)))), ((int)(((byte)(16)))));
            this.btnExit.Location = new System.Drawing.Point(2, 372);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(168, 53);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Cerrar sesión";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabOpciones
            // 
            this.tabOpciones.Controls.Add(this.tabPage1);
            this.tabOpciones.Controls.Add(this.tabPage2);
            this.tabOpciones.Location = new System.Drawing.Point(7, 12);
            this.tabOpciones.Name = "tabOpciones";
            this.tabOpciones.SelectedIndex = 0;
            this.tabOpciones.Size = new System.Drawing.Size(379, 422);
            this.tabOpciones.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpCrearExamen);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear examen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpCorregirExamen);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(371, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Corregir examen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(42)))), ((int)(((byte)(66)))));
            this.pnlRight.Controls.Add(this.label7);
            this.pnlRight.Controls.Add(this.btnExit);
            this.pnlRight.Controls.Add(this.imgAvatar);
            this.pnlRight.Controls.Add(this.lblNombre);
            this.pnlRight.Controls.Add(this.txtMail);
            this.pnlRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pnlRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(110)))), ((int)(((byte)(63)))));
            this.pnlRight.Location = new System.Drawing.Point(392, 30);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(170, 453);
            this.pnlRight.TabIndex = 7;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(155)))), ((int)(((byte)(219)))));
            this.pnlLeft.Controls.Add(this.tabOpciones);
            this.pnlLeft.Location = new System.Drawing.Point(0, 30);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(395, 453);
            this.pnlLeft.TabIndex = 8;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(95)))), ((int)(((byte)(143)))));
            this.pnlTop.Controls.Add(this.picSalir);
            this.pnlTop.Controls.Add(this.label9);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(562, 35);
            this.pnlTop.TabIndex = 7;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // picSalir
            // 
            this.picSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSalir.Image = global::Sigedu_UTN.Properties.Resources.btnCerrar2;
            this.picSalir.Location = new System.Drawing.Point(529, 2);
            this.picSalir.Name = "picSalir";
            this.picSalir.Size = new System.Drawing.Size(30, 30);
            this.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSalir.TabIndex = 18;
            this.picSalir.TabStop = false;
            this.picSalir.Click += new System.EventHandler(this.picSalir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(7, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "SIGEDU - Profesores";
            // 
            // frmProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 467);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGEDU - Profesor";
            ((System.ComponentModel.ISupportInitialize)(this.imgAvatar)).EndInit();
            this.grpCrearExamen.ResumeLayout(false);
            this.grpCrearExamen.PerformLayout();
            this.grpCorregirExamen.ResumeLayout(false);
            this.grpCorregirExamen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNota)).EndInit();
            this.tabOpciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listMaterias;
        private GroupBox grpCrearExamen;
        private Button btnCalificar;
        private Label lblNombre;
        private PictureBox imgAvatar;
        private GroupBox grpCorregirExamen;
        private Button btnExit;
        private Label lblMateria;
        public DateTimePicker dttFecha;
        private Label lblFecha;
        public ComboBox cmbExamenes;
        private TextBox txtNombreExamen;
        private Label label1;
        private Label lblExamenFecha;
        private Label label2;
        private Label label4;
        private Label label6;
        private NumericUpDown numNota;
        public ComboBox cmbAlumnosEvaluados;
        private Label txtMail;
        private Label label7;
        private Label lblUltimoCalificado;
        private Label lblUltimaNota;
        private Label label8;
        private Label label3;
        private TabControl tabOpciones;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel pnlRight;
        private Panel pnlLeft;
        private Panel pnlTop;
        private Label label9;
        private Button btnCrearExamen;
        private PictureBox picSalir;
        private Label lblSeleccionarMateriaCorregirExamen;
        public ComboBox cmbMateria;
    }
}