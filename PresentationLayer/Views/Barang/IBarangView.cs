using DomainLayer.Models.Barang;
using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.Barang
{
   public interface IBarangView
   {
      event EventHandler OnBarangViewLoadEventRaised;
      BindingListView<BarangModel> BindingLitViewBarang { get; set; }

      void ShowBarangView();
   }
}
