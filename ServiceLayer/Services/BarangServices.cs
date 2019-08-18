using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Barang;

namespace ServiceLayer.Services
{
   public class BarangServices : IBarangServices, IBarangRepository
   {
      private IBarangRepository _barangRepository;
      private IModelDataAnnotationCheck _modelDataAnnotationCheck;

      public BarangServices(IBarangRepository barangRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
      {
         _barangRepository = barangRepository;
         _modelDataAnnotationCheck = modelDataAnnotationCheck;
      }

      public IEnumerable<BarangModel> GetAll()
      {
         return _barangRepository.GetAll();
      }

      public BarangModel GetById(int id)
      {
         return _barangRepository.GetById(id);
      }

      public void Add(IBarangModel barangModel)
      {
         _barangRepository.Add(barangModel);
      }

      public void Update(IBarangModel barangModel)
      {
         _barangRepository.Update(barangModel);
      }

      public void Delete(IBarangModel barangModel)
      {
         _barangRepository.Delete(barangModel);
      }

      public void ValidateModel(IBarangModel barangModel)
      {
         _modelDataAnnotationCheck.ValidateModel(barangModel);
      }

      public void ValidateModelDataAnnotations(IBarangModel barangModel)
      {
         _modelDataAnnotationCheck.ValidateModel(barangModel);
      }
   }
}
