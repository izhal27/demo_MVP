namespace DomainLayer.Models.Barang
{
   public interface IBarangModel
   {
      int id { get; set; }
      string nama { get; set; }
      int stok { get; set; }
      decimal harga_pokok { get; set; }
      decimal harga_jual { get; set; }
   }
}