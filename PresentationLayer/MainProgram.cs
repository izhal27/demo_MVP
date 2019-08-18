using InfrastructureLayer.DataAccess.Repositories.Specific.Barang;
using PresentationLayer.Presenters;
using PresentationLayer.Presenters.Barang;
using PresentationLayer.Views;
using PresentationLayer.Views.Barang;
using PresentationLayer.Views.Common;
using ServiceLayer.CommonServices;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace PresentationLayer
{
   static class MainProgram
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         IUnityContainer ioc = new UnityContainer();

         ioc.RegisterType<MainPresenter, MainPresenter>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IBarangPresenter, BarangPresenter>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IBarangView, BarangView>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IBarangServices, BarangServices>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IBarangRepository, BarangRepository>(new ContainerControlledLifetimeManager());
         ioc.RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager());

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         IMainPresenter mainPresenter = ioc.Resolve<MainPresenter>();
         IMainView mainView = mainPresenter.GetMainView;

         Application.Run((MainView)mainView);
      }
   }
}
