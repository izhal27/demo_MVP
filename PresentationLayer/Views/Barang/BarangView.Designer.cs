namespace PresentationLayer.Views.Barang
{
   partial class BarangView
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
         this.dgvBarang = new System.Windows.Forms.DataGridView();
         ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).BeginInit();
         this.SuspendLayout();
         // 
         // dataGridView1
         // 
         this.dgvBarang.AllowUserToAddRows = false;
         this.dgvBarang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.dgvBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dgvBarang.Location = new System.Drawing.Point(12, 12);
         this.dgvBarang.Name = "dataGridView1";
         this.dgvBarang.ReadOnly = true;
         this.dgvBarang.Size = new System.Drawing.Size(676, 380);
         this.dgvBarang.TabIndex = 0;
         // 
         // BarangView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(700, 404);
         this.Controls.Add(this.dgvBarang);
         this.Name = "BarangView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "BarangView";
         this.Load += new System.EventHandler(this.BarangView_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView dgvBarang;
   }
}