using Equin.ApplicationFramework;
using PresentationLayer.Views.Barang;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters.Barang
{
   public class BarangPresenter : IBarangPresenter
   {
      private IBarangView _barangView;
      private IBarangServices _barangServices;

      public BarangPresenter(IBarangView barangView, IBarangServices barangServices)
      {
         _barangView = barangView;
         _barangServices = barangServices;

         SubscribeToEventsSetup();
      }

      public IBarangView GetBarangView
      {
         get { return _barangView; }
      }

      public void SubscribeToEventsSetup()
      {
         _barangView.OnBarangViewLoadEventRaised += OnBarangViewLoadEventRaised;
      }

      private void OnBarangViewLoadEventRaised(object sender, EventArgs e)
      {
         var listBarang = _barangServices.GetAll().ToList();
         _barangView.BindingLitViewBarang = new BindingListView<DomainLayer.Models.Barang.BarangModel>(listBarang);
      }
   }
}
