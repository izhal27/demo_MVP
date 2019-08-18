using CommonComponents;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
   public partial class MainView : Form, IMainView
   {
      public event EventHandler OnBarangMenuClickEventRaised;

      public MainView()
      {
         InitializeComponent();
      }


      public void ShowMainView()
      {
         Show();
      }

      private void btnShowBarang_Click(object sender, EventArgs e)
      {
         EventHelper.RaiseEvent(this, OnBarangMenuClickEventRaised, e);
      }
   }
}
