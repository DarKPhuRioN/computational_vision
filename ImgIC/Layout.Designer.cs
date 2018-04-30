namespace ImgIC
{
    partial class Layout
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
            this.Parametter = new System.Windows.Forms.GroupBox();
            this.FactoresGroup = new System.Windows.Forms.GroupBox();
            this.Mutacion = new System.Windows.Forms.TextBox();
            this.Cruce = new System.Windows.Forms.TextBox();
            this.labelMutacion = new System.Windows.Forms.Label();
            this.labelCruce = new System.Windows.Forms.Label();
            this.Umbral_d = new System.Windows.Forms.TextBox();
            this.Umbral = new System.Windows.Forms.TextBox();
            this.numInd = new System.Windows.Forms.TextBox();
            this.LabelUmbralDistancia = new System.Windows.Forms.Label();
            this.LabelUmbralgrises = new System.Windows.Forms.Label();
            this.LabelNUmIndi = new System.Windows.Forms.Label();
            this.AccionesGroup = new System.Windows.Forms.GroupBox();
            this.Salida = new System.Windows.Forms.ListBox();
            this.BtnGroup = new System.Windows.Forms.GroupBox();
            this.CleanOut = new System.Windows.Forms.Button();
            this.cleanImg = new System.Windows.Forms.Button();
            this.IniciarAE = new System.Windows.Forms.Button();
            this.Examinar = new System.Windows.Forms.Button();
            this.IOgroup = new System.Windows.Forms.GroupBox();
            this.ImagenInicial = new System.Windows.Forms.PictureBox();
            this.imgfinalgroup = new System.Windows.Forms.GroupBox();
            this.ImagenFinal = new System.Windows.Forms.PictureBox();
            this.imagendecarga = new System.Windows.Forms.OpenFileDialog();
            this.Parametter.SuspendLayout();
            this.FactoresGroup.SuspendLayout();
            this.AccionesGroup.SuspendLayout();
            this.BtnGroup.SuspendLayout();
            this.IOgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenInicial)).BeginInit();
            this.imgfinalgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // Parametter
            // 
            this.Parametter.Controls.Add(this.FactoresGroup);
            this.Parametter.Controls.Add(this.Umbral_d);
            this.Parametter.Controls.Add(this.Umbral);
            this.Parametter.Controls.Add(this.numInd);
            this.Parametter.Controls.Add(this.LabelUmbralDistancia);
            this.Parametter.Controls.Add(this.LabelUmbralgrises);
            this.Parametter.Controls.Add(this.LabelNUmIndi);
            this.Parametter.Location = new System.Drawing.Point(27, 415);
            this.Parametter.Name = "Parametter";
            this.Parametter.Size = new System.Drawing.Size(259, 241);
            this.Parametter.TabIndex = 3;
            this.Parametter.TabStop = false;
            this.Parametter.Text = "Parametros del Algoritmo Evolutivo";
            // 
            // FactoresGroup
            // 
            this.FactoresGroup.Controls.Add(this.Mutacion);
            this.FactoresGroup.Controls.Add(this.Cruce);
            this.FactoresGroup.Controls.Add(this.labelMutacion);
            this.FactoresGroup.Controls.Add(this.labelCruce);
            this.FactoresGroup.Location = new System.Drawing.Point(11, 134);
            this.FactoresGroup.Name = "FactoresGroup";
            this.FactoresGroup.Size = new System.Drawing.Size(231, 100);
            this.FactoresGroup.TabIndex = 6;
            this.FactoresGroup.TabStop = false;
            this.FactoresGroup.Text = "Factores";
            // 
            // Mutacion
            // 
            this.Mutacion.Location = new System.Drawing.Point(82, 62);
            this.Mutacion.Name = "Mutacion";
            this.Mutacion.Size = new System.Drawing.Size(143, 22);
            this.Mutacion.TabIndex = 3;
            this.Mutacion.Text = "0.5";
            // 
            // Cruce
            // 
            this.Cruce.Location = new System.Drawing.Point(62, 34);
            this.Cruce.Name = "Cruce";
            this.Cruce.Size = new System.Drawing.Size(163, 22);
            this.Cruce.TabIndex = 2;
            this.Cruce.Text = "0.5";
            // 
            // labelMutacion
            // 
            this.labelMutacion.AutoSize = true;
            this.labelMutacion.Location = new System.Drawing.Point(7, 65);
            this.labelMutacion.Name = "labelMutacion";
            this.labelMutacion.Size = new System.Drawing.Size(69, 17);
            this.labelMutacion.TabIndex = 1;
            this.labelMutacion.Text = "Mutacion:";
            // 
            // labelCruce
            // 
            this.labelCruce.AutoSize = true;
            this.labelCruce.Location = new System.Drawing.Point(6, 34);
            this.labelCruce.Name = "labelCruce";
            this.labelCruce.Size = new System.Drawing.Size(49, 17);
            this.labelCruce.TabIndex = 0;
            this.labelCruce.Text = "Cruce:";
            // 
            // Umbral_d
            // 
            this.Umbral_d.Location = new System.Drawing.Point(131, 85);
            this.Umbral_d.Name = "Umbral_d";
            this.Umbral_d.Size = new System.Drawing.Size(111, 22);
            this.Umbral_d.TabIndex = 5;
            this.Umbral_d.Text = "15";
            // 
            // Umbral
            // 
            this.Umbral.Location = new System.Drawing.Point(116, 54);
            this.Umbral.Name = "Umbral";
            this.Umbral.Size = new System.Drawing.Size(127, 22);
            this.Umbral.TabIndex = 4;
            this.Umbral.Text = "100";
            // 
            // numInd
            // 
            this.numInd.Location = new System.Drawing.Point(118, 22);
            this.numInd.Name = "numInd";
            this.numInd.Size = new System.Drawing.Size(125, 22);
            this.numInd.TabIndex = 3;
            this.numInd.Text = "100";
            // 
            // LabelUmbralDistancia
            // 
            this.LabelUmbralDistancia.AutoSize = true;
            this.LabelUmbralDistancia.Location = new System.Drawing.Point(6, 90);
            this.LabelUmbralDistancia.Name = "LabelUmbralDistancia";
            this.LabelUmbralDistancia.Size = new System.Drawing.Size(119, 17);
            this.LabelUmbralDistancia.TabIndex = 2;
            this.LabelUmbralDistancia.Text = "Umbral Distancia:";
            // 
            // LabelUmbralgrises
            // 
            this.LabelUmbralgrises.AutoSize = true;
            this.LabelUmbralgrises.Location = new System.Drawing.Point(8, 53);
            this.LabelUmbralgrises.Name = "LabelUmbralgrises";
            this.LabelUmbralgrises.Size = new System.Drawing.Size(102, 17);
            this.LabelUmbralgrises.TabIndex = 1;
            this.LabelUmbralgrises.Text = "Umbral Grises:";
            // 
            // LabelNUmIndi
            // 
            this.LabelNUmIndi.AutoSize = true;
            this.LabelNUmIndi.Location = new System.Drawing.Point(7, 22);
            this.LabelNUmIndi.Name = "LabelNUmIndi";
            this.LabelNUmIndi.Size = new System.Drawing.Size(108, 17);
            this.LabelNUmIndi.TabIndex = 0;
            this.LabelNUmIndi.Text = "Num Individuos:";
            // 
            // AccionesGroup
            // 
            this.AccionesGroup.Controls.Add(this.Salida);
            this.AccionesGroup.Location = new System.Drawing.Point(745, 505);
            this.AccionesGroup.Name = "AccionesGroup";
            this.AccionesGroup.Size = new System.Drawing.Size(574, 147);
            this.AccionesGroup.TabIndex = 4;
            this.AccionesGroup.TabStop = false;
            this.AccionesGroup.Text = "Acciones Realizadas";
            // 
            // Salida
            // 
            this.Salida.FormattingEnabled = true;
            this.Salida.ItemHeight = 16;
            this.Salida.Location = new System.Drawing.Point(7, 22);
            this.Salida.Name = "Salida";
            this.Salida.Size = new System.Drawing.Size(561, 116);
            this.Salida.TabIndex = 0;
            // 
            // BtnGroup
            // 
            this.BtnGroup.Controls.Add(this.CleanOut);
            this.BtnGroup.Controls.Add(this.cleanImg);
            this.BtnGroup.Controls.Add(this.IniciarAE);
            this.BtnGroup.Controls.Add(this.Examinar);
            this.BtnGroup.Location = new System.Drawing.Point(296, 505);
            this.BtnGroup.Name = "BtnGroup";
            this.BtnGroup.Size = new System.Drawing.Size(443, 144);
            this.BtnGroup.TabIndex = 5;
            this.BtnGroup.TabStop = false;
            this.BtnGroup.Text = "Botones y Funciones";
            // 
            // CleanOut
            // 
            this.CleanOut.Enabled = false;
            this.CleanOut.Location = new System.Drawing.Point(328, 53);
            this.CleanOut.Name = "CleanOut";
            this.CleanOut.Size = new System.Drawing.Size(109, 33);
            this.CleanOut.TabIndex = 3;
            this.CleanOut.Text = "Limpiar Salida";
            this.CleanOut.UseVisualStyleBackColor = true;
            this.CleanOut.Click += new System.EventHandler(this.CleanOut_Click);
            // 
            // cleanImg
            // 
            this.cleanImg.Enabled = false;
            this.cleanImg.Location = new System.Drawing.Point(181, 53);
            this.cleanImg.Name = "cleanImg";
            this.cleanImg.Size = new System.Drawing.Size(130, 33);
            this.cleanImg.TabIndex = 2;
            this.cleanImg.Text = "Limpiar Imagenes";
            this.cleanImg.UseVisualStyleBackColor = true;
            this.cleanImg.Click += new System.EventHandler(this.cleanImg_Click);
            // 
            // IniciarAE
            // 
            this.IniciarAE.Enabled = false;
            this.IniciarAE.Location = new System.Drawing.Point(96, 53);
            this.IniciarAE.Name = "IniciarAE";
            this.IniciarAE.Size = new System.Drawing.Size(79, 33);
            this.IniciarAE.TabIndex = 1;
            this.IniciarAE.Text = "Iniciar AE";
            this.IniciarAE.UseVisualStyleBackColor = true;
            this.IniciarAE.Click += new System.EventHandler(this.IniciarAE_Click);
            // 
            // Examinar
            // 
            this.Examinar.Location = new System.Drawing.Point(6, 53);
            this.Examinar.Name = "Examinar";
            this.Examinar.Size = new System.Drawing.Size(75, 33);
            this.Examinar.TabIndex = 0;
            this.Examinar.Text = "Examinar";
            this.Examinar.UseVisualStyleBackColor = true;
            this.Examinar.Click += new System.EventHandler(this.Examinar_Click);
            // 
            // IOgroup
            // 
            this.IOgroup.Controls.Add(this.ImagenInicial);
            this.IOgroup.Location = new System.Drawing.Point(27, 41);
            this.IOgroup.Name = "IOgroup";
            this.IOgroup.Size = new System.Drawing.Size(259, 298);
            this.IOgroup.TabIndex = 6;
            this.IOgroup.TabStop = false;
            this.IOgroup.Text = "Imagen Original";
            // 
            // ImagenInicial
            // 
            this.ImagenInicial.Location = new System.Drawing.Point(7, 22);
            this.ImagenInicial.Name = "ImagenInicial";
            this.ImagenInicial.Size = new System.Drawing.Size(246, 270);
            this.ImagenInicial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenInicial.TabIndex = 0;
            this.ImagenInicial.TabStop = false;
            // 
            // imgfinalgroup
            // 
            this.imgfinalgroup.Controls.Add(this.ImagenFinal);
            this.imgfinalgroup.Location = new System.Drawing.Point(296, 41);
            this.imgfinalgroup.Name = "imgfinalgroup";
            this.imgfinalgroup.Size = new System.Drawing.Size(1023, 450);
            this.imgfinalgroup.TabIndex = 7;
            this.imgfinalgroup.TabStop = false;
            this.imgfinalgroup.Text = "Imagen Final";
            // 
            // ImagenFinal
            // 
            this.ImagenFinal.Location = new System.Drawing.Point(6, 22);
            this.ImagenFinal.Name = "ImagenFinal";
            this.ImagenFinal.Size = new System.Drawing.Size(1011, 422);
            this.ImagenFinal.TabIndex = 0;
            this.ImagenFinal.TabStop = false;
            // 
            // imagendecarga
            // 
            this.imagendecarga.FileName = "img";
            this.imagendecarga.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.imgfinalgroup);
            this.Controls.Add(this.IOgroup);
            this.Controls.Add(this.BtnGroup);
            this.Controls.Add(this.AccionesGroup);
            this.Controls.Add(this.Parametter);
            this.Name = "Layout";
            this.Text = "Algoritmo Evolutivo";
            this.Parametter.ResumeLayout(false);
            this.Parametter.PerformLayout();
            this.FactoresGroup.ResumeLayout(false);
            this.FactoresGroup.PerformLayout();
            this.AccionesGroup.ResumeLayout(false);
            this.BtnGroup.ResumeLayout(false);
            this.IOgroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenInicial)).EndInit();
            this.imgfinalgroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenFinal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox Parametter;
        private System.Windows.Forms.TextBox Umbral_d;
        private System.Windows.Forms.TextBox Umbral;
        private System.Windows.Forms.TextBox numInd;
        private System.Windows.Forms.Label LabelUmbralDistancia;
        private System.Windows.Forms.Label LabelUmbralgrises;
        private System.Windows.Forms.Label LabelNUmIndi;
        private System.Windows.Forms.GroupBox FactoresGroup;
        private System.Windows.Forms.TextBox Mutacion;
        private System.Windows.Forms.TextBox Cruce;
        private System.Windows.Forms.Label labelMutacion;
        private System.Windows.Forms.Label labelCruce;
        private System.Windows.Forms.GroupBox AccionesGroup;
        private System.Windows.Forms.ListBox Salida;
        private System.Windows.Forms.GroupBox BtnGroup;
        private System.Windows.Forms.Button CleanOut;
        private System.Windows.Forms.Button cleanImg;
        private System.Windows.Forms.Button IniciarAE;
        private System.Windows.Forms.Button Examinar;
        private System.Windows.Forms.GroupBox IOgroup;
        private System.Windows.Forms.PictureBox ImagenInicial;
        private System.Windows.Forms.GroupBox imgfinalgroup;
        private System.Windows.Forms.PictureBox ImagenFinal;
        private System.Windows.Forms.OpenFileDialog imagendecarga;
    }
}