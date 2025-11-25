namespace EcoChallenge.Presentacion
{
    partial class FrmMenuJugador
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCompletar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.dgvRecompensas = new System.Windows.Forms.DataGridView();
            this.dgvMisiones = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPuntosTotales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecompensas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(639, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido Jugador";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCompletar
            // 
            this.btnCompletar.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompletar.Location = new System.Drawing.Point(39, 488);
            this.btnCompletar.Name = "btnCompletar";
            this.btnCompletar.Size = new System.Drawing.Size(118, 40);
            this.btnCompletar.TabIndex = 2;
            this.btnCompletar.Text = "Completar";
            this.btnCompletar.UseVisualStyleBackColor = true;
            this.btnCompletar.Click += new System.EventHandler(this.btnCompletar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(1269, 488);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(155, 40);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar Sesión";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(340, 273);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 16);
            this.lblResultado.TabIndex = 5;
            // 
            // dgvRecompensas
            // 
            this.dgvRecompensas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecompensas.Location = new System.Drawing.Point(844, 76);
            this.dgvRecompensas.Name = "dgvRecompensas";
            this.dgvRecompensas.RowHeadersWidth = 51;
            this.dgvRecompensas.RowTemplate.Height = 24;
            this.dgvRecompensas.Size = new System.Drawing.Size(584, 354);
            this.dgvRecompensas.TabIndex = 6;
            // 
            // dgvMisiones
            // 
            this.dgvMisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisiones.Location = new System.Drawing.Point(12, 76);
            this.dgvMisiones.Name = "dgvMisiones";
            this.dgvMisiones.RowHeadersWidth = 51;
            this.dgvMisiones.Size = new System.Drawing.Size(606, 354);
            this.dgvMisiones.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(650, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Puntos Obtenidos";
            // 
            // lblPuntosTotales
            // 
            this.lblPuntosTotales.AutoSize = true;
            this.lblPuntosTotales.Location = new System.Drawing.Point(701, 178);
            this.lblPuntosTotales.Name = "lblPuntosTotales";
            this.lblPuntosTotales.Size = new System.Drawing.Size(44, 16);
            this.lblPuntosTotales.TabIndex = 9;
            this.lblPuntosTotales.Text = "label3";
            // 
            // FrmMenuJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 566);
            this.Controls.Add(this.lblPuntosTotales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvMisiones);
            this.Controls.Add(this.dgvRecompensas);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCompletar);
            this.Controls.Add(this.label1);
            this.Name = "FrmMenuJugador";
            this.Text = "FrmMenuJugador";
            this.Load += new System.EventHandler(this.FrmMenuJugador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecompensas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCompletar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.DataGridView dgvRecompensas;
        private System.Windows.Forms.DataGridView dgvMisiones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPuntosTotales;
    }
}