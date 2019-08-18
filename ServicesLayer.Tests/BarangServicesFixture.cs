using DomainLayer.Models.Barang;
using ServiceLayer.CommonServices;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Tests
{
   public class BarangServicesFixture
   {
      private IBarangServices _barangService;
      private IBarangModel _barangModel;

      public BarangServicesFixture()
      {
         _barangModel = new BarangModel();
         _barangService = new BarangServices(null, new ModelDataAnnotationCheck());
      }

      public BarangModel BarangModel
      {
         get { return (BarangModel)_barangModel; }
         set { _barangModel = value; }
      }

      public BarangServices BarangService
      {
         get { return (BarangServices)_barangService; }
         set { _barangService = value; }
      }
   }
}
