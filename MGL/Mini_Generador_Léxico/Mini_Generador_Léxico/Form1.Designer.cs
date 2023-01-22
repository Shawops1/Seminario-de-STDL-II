namespace Mini_Generador_Léxico
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
            this.Bttn1 = new System.Windows.Forms.Button();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.Tbx1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // Bttn1
            // 
            this.Bttn1.Location = new System.Drawing.Point(360, 205);
            this.Bttn1.Name = "Bttn1";
            this.Bttn1.Size = new System.Drawing.Size(75, 23);
            this.Bttn1.TabIndex = 1;
            this.Bttn1.Text = "Analizar ";
            this.Bttn1.UseVisualStyleBackColor = true;
            this.Bttn1.Click += new System.EventHandler(this.Bttn1_Click);
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(453, 21);
            this.tabla.Name = "tabla";
            this.tabla.RowTemplate.Height = 25;
            this.tabla.Size = new System.Drawing.Size(344, 387);
            this.tabla.TabIndex = 2;
            // 
            // Tbx1
            // 
            this.Tbx1.Location = new System.Drawing.Point(57, 21);
            this.Tbx1.Multiline = true;
            this.Tbx1.Name = "Tbx1";
            this.Tbx1.Size = new System.Drawing.Size(274, 387);
            this.Tbx1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.Tbx1);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.Bttn1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Bttn1;
        private TextBox Tbx1;
        public DataGridView tabla;
    }
}