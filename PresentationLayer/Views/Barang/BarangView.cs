using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainLayer.Models.Barang;
using Equin.ApplicationFramework;

namespace PresentationLayer.Views.Barang
{
   public partial class BarangView : Form, IBarangView
   {
      public event EventHandler OnBarangViewLoadEventRaised;

      public BindingListView<BarangModel> BindingLitViewBarang
      {
         get
         {
            return (BindingListView<BarangModel>)dgvBarang.DataSource;
         }

         set
         {
            dgvBarang.DataSource = value;
         }
      }

      public BarangView()
      {
         InitializeComponent();
      }

      private void BarangView_Load(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnBarangViewLoadEventRaised, e);
      }

      public void ShowBarangView()
      {
         this.ShowDialog();
      }
      
   }
}
