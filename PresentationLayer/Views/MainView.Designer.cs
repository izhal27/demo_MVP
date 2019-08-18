namespace PresentationLayer.Views
{
   partial class MainView
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
         this.btnShowBarang = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnShowBarang
         // 
         this.btnShowBarang.Location = new System.Drawing.Point(74, 120);
         this.btnShowBarang.Name = "btnShowBarang";
         this.btnShowBarang.Size = new System.Drawing.Size(137, 23);
         this.btnShowBarang.TabIndex = 0;
         this.btnShowBarang.Text = "Show Barang";
         this.btnShowBarang.UseVisualStyleBackColor = true;
         this.btnShowBarang.Click += new System.EventHandler(this.btnShowBarang_Click);
         // 
         // MainView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 262);
         this.Controls.Add(this.btnShowBarang);
         this.Name = "MainView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Belajar MVP";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnShowBarang;
   }
}

