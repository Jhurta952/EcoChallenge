namespace EcoChallenge.Presentacion
{
    partial class FrmMisionesAdmin
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.chkActiva = new System.Windows.Forms.CheckBox();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dgvMisiones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.Location = new System.Drawing.Point(52, 487);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(173, 53);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(309, 487);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(173, 53);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(565, 487);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(173, 53);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(821, 487);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(173, 53);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(75, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(163, 28);
            this.txtNombre.TabIndex = 4;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(75, 273);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 30);
            this.cmbTipo.TabIndex = 5;
            // 
            // chkActiva
            // 
            this.chkActiva.AutoSize = true;
            this.chkActiva.Location = new System.Drawing.Point(75, 357);
            this.chkActiva.Name = "chkActiva";
            this.chkActiva.Size = new System.Drawing.Size(129, 26);
            this.chkActiva.TabIndex = 6;
            this.chkActiva.Text = "checkBox1";
            this.chkActiva.UseVisualStyleBackColor = true;
            // 
            // txtPuntos
            // 
            this.txtPuntos.Location = new System.Drawing.Point(75, 198);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(224, 28);
            this.txtPuntos.TabIndex = 7;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(75, 124);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(407, 28);
            this.txtDescripcion.TabIndex = 8;
            // 
            // dgvMisiones
            // 
            this.dgvMisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisiones.Location = new System.Drawing.Point(497, 12);
            this.dgvMisiones.Name = "dgvMisiones";
            this.dgvMisiones.RowHeadersWidth = 51;
            this.dgvMisiones.RowTemplate.Height = 24;
            this.dgvMisiones.Size = new System.Drawing.Size(548, 456);
            this.dgvMisiones.TabIndex = 9;
            // 
            // FrmMisionesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 605);
            this.Controls.Add(this.dgvMisiones);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtPuntos);
            this.Controls.Add(this.chkActiva);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnCrear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMisionesAdmin";
            this.Text = "FrmMisionesAdmin";
            this.Load += new System.EventHandler(this.FrmMisionesAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.DataGridView dgvMisiones;
    }
}