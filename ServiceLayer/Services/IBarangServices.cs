using System.Collections.Generic;
using DomainLayer.Models.Barang;

namespace ServiceLayer.Services
{
   public interface IBarangServices
   {
      IEnumerable<BarangModel> GetAll();
      BarangModel GetById(int id);
      void Add(IBarangModel barangModel);
      void Delete(IBarangModel barangModel);
      void Update(IBarangModel barangModel);
      void ValidateModel(IBarangModel barangModel);
      void ValidateModelDataAnnotations(IBarangModel barangModel);
   }
}