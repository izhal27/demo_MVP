using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Barang
{
   [Table("barang")]
   public class BarangModel : IBarangModel
   {
      [DisplayName("ID")]
      public int id { get; set; }
      [Required(AllowEmptyStrings = false, ErrorMessage = "Nama barang harus diisi !!!")]
      [StringLength(50, MinimumLength = 3, ErrorMessage = "Nama barang harus diantara 3 sampai 50 karakter !!!")]
      [DisplayName("Nama")]
      public string nama { get; set; }
      [DisplayName("Stok")]
      public int stok { get; set; }
      [DisplayName("Harga Pokok")]
      public decimal harga_pokok { get; set; }
      [DisplayName("Harga Jual")]
      public decimal harga_jual { get; set; }
   }
}
