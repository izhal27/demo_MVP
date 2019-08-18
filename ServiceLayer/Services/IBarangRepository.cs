using DomainLayer.Models.Barang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
   public interface IBarangRepository
   {
      void Add(IBarangModel barangModel);
      void Update(IBarangModel barangModel);
      void Delete(IBarangModel barangModel);
      IEnumerable<BarangModel> GetAll();
      BarangModel GetById(int id);
   }
}
