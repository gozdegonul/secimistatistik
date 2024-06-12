namespace secimistatistik
{
    partial class Giris
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
            this.btnkullanici = new System.Windows.Forms.Button();
            this.btnvatandas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnkullanici
            // 
            this.btnkullanici.BackColor = System.Drawing.SystemColors.Control;
            this.btnkullanici.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkullanici.Location = new System.Drawing.Point(83, 85);
            this.btnkullanici.Margin = new System.Windows.Forms.Padding(4);
            this.btnkullanici.Name = "btnkullanici";
            this.btnkullanici.Size = new System.Drawing.Size(367, 113);
            this.btnkullanici.TabIndex = 0;
            this.btnkullanici.Text = "Veri Girişi";
            this.btnkullanici.UseVisualStyleBackColor = false;
            this.btnkullanici.Click += new System.EventHandler(this.btnkullanici_Click);
            // 
            // btnvatandas
            // 
            this.btnvatandas.BackColor = System.Drawing.SystemColors.Control;
            this.btnvatandas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnvatandas.Location = new System.Drawing.Point(83, 254);
            this.btnvatandas.Margin = new System.Windows.Forms.Padding(4);
            this.btnvatandas.Name = "btnvatandas";
            this.btnvatandas.Size = new System.Drawing.Size(367, 113);
            this.btnvatandas.TabIndex = 1;
            this.btnvatandas.Text = "Vatandaş Girişi";
            this.btnvatandas.UseVisualStyleBackColor = false;
            this.btnvatandas.Click += new System.EventHandler(this.btnvatandas_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(582, 459);
            this.Controls.Add(this.btnvatandas);
            this.Controls.Add(this.btnkullanici);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkullanici;
        private System.Windows.Forms.Button btnvatandas;
    }
}

