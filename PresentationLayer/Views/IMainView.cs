using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
   public interface IMainView
   {
      event EventHandler OnBarangMenuClickEventRaised;

      void ShowMainView();
   }
}
