using PresentationLayer.Views.Barang;

namespace PresentationLayer.Presenters.Barang
{
   public interface IBarangPresenter
   {
      IBarangView GetBarangView { get; }
   }
}