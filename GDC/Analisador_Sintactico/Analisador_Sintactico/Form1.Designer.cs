namespace Analisador_Sintactico
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
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtExpresion = new System.Windows.Forms.TextBox();
            this.txtResLexico = new System.Windows.Forms.TextBox();
            this.dgvSintactico = new System.Windows.Forms.DataGridView();
            this.Pi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtErroresLexico = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSintactico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(280, 12);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(85, 37);
            this.btnAnalizar.TabIndex = 0;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(437, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 37);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtExpresion
            // 
            this.txtExpresion.Location = new System.Drawing.Point(12, 78);
            this.txtExpresion.Multiline = true;
            this.txtExpresion.Name = "txtExpresion";
            this.txtExpresion.Size = new System.Drawing.Size(285, 360);
            this.txtExpresion.TabIndex = 2;
            // 
            // txtResLexico
            // 
            this.txtResLexico.Location = new System.Drawing.Point(313, 78);
            this.txtResLexico.Multiline = true;
            this.txtResLexico.Name = "txtResLexico";
            this.txtResLexico.Size = new System.Drawing.Size(301, 181);
            this.txtResLexico.TabIndex = 3;
            // 
            // dgvSintactico
            // 
            this.dgvSintactico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSintactico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pi,
            this.Salida});
            this.dgvSintactico.Location = new System.Drawing.Point(629, 78);
            this.dgvSintactico.Name = "dgvSintactico";
            this.dgvSintactico.RowTemplate.Height = 25;
            this.dgvSintactico.Size = new System.Drawing.Size(243, 360);
            this.dgvSintactico.TabIndex = 5;
            // 
            // Pila
            // 
            this.Pi.HeaderText = "Pila";
            this.Pi.Name = "Pila";
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            // 
            // txtErroresLexico
            // 
            this.txtErroresLexico.Location = new System.Drawing.Point(313, 280);
            this.txtErroresLexico.Multiline = true;
            this.txtErroresLexico.Name = "txtErroresLexico";
            this.txtErroresLexico.Size = new System.Drawing.Size(301, 158);
            this.txtErroresLexico.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Analizador Léxico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Errores";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ingrese Expresión";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtErroresLexico);
            this.Controls.Add(this.dgvSintactico);
            this.Controls.Add(this.txtResLexico);
            this.Controls.Add(this.txtExpresion);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAnalizar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSintactico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAnalizar;
        private Button btnLimpiar;
        private TextBox txtExpresion;
        private TextBox txtResLexico;
        private DataGridView dgvSintactico;
        private DataGridViewTextBoxColumn Pi;
        private DataGridViewTextBoxColumn Salida;
        private TextBox txtErroresLexico;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}