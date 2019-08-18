using PresentationLayer.Views;

namespace PresentationLayer.Presenters
{
   public interface IMainPresenter
   {
      IMainView GetMainView { get; }
   }
}