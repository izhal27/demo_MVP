using PresentationLayer.Presenters.Barang;
using PresentationLayer.Views;
using PresentationLayer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
   public class MainPresenter : BasePresenter, IMainPresenter
   {
      private IMainView _mainView;
      private IBarangPresenter _barangPresenter;

      public IMainView GetMainView
      {
         get { return _mainView; }
      }

      public MainPresenter(IMainView mainView, IErrorMessageView errorMessageView,
                           IBarangPresenter barangPresenter) : base(errorMessageView)
      {
         _mainView = mainView;
         _barangPresenter = barangPresenter;
         _mainView.OnBarangMenuClickEventRaised += _mainView_OnBarangMenuClickEventRaised;
      }

      private void _mainView_OnBarangMenuClickEventRaised(object sender, EventArgs e)
      {
         var barangView = _barangPresenter.GetBarangView;
         barangView.ShowBarangView();
      }
   }
}
