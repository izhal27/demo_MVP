using CommonComponents;
using DomainLayer.Models.Barang;
using InfrastructureLayer.DataAccess.Repositories.Specific.Barang;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceLayer.CommonServices;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
   public class BarangServicesDataAccessTests
   {
      private readonly ITestOutputHelper _testOutputHelper;
      private BarangServices _barangServices;

      public BarangServicesDataAccessTests(ITestOutputHelper testOutputHelper)
      {
         _testOutputHelper = testOutputHelper;
         _barangServices = new BarangServices(new BarangRepository(), new ModelDataAnnotationCheck());
      }

      [Fact]
      public void ShouldReturnListOfBarangs()
      {
         var listBarang = (List<BarangModel>)_barangServices.GetAll();

         Assert.NotEmpty(listBarang);

         foreach (var barang in listBarang)
         {
            var strBuilder = new StringBuilder();
            strBuilder.Append($"ID --> {barang.id}").AppendLine();
            strBuilder.Append($"Nama --> {barang.nama}").AppendLine();
            strBuilder.Append($"Stok --> {barang.stok}").AppendLine();
            strBuilder.Append($"Harga pokok --> {barang.harga_pokok}").AppendLine();
            strBuilder.Append($"Harga jual --> {barang.harga_jual}").AppendLine();

            _testOutputHelper.WriteLine(strBuilder.ToString());
         }
      }

      [Fact]
      public void ShouldReturnBarangModelMatchingId()
      {
         BarangModel barangModel = null;
         int idToGet = 1;

         try
         {
            barangModel = _barangServices.GetById(idToGet);
         }
         catch (DataAccessException ex)
         {
            _testOutputHelper.WriteLine(ex.DataAccessStatusInfo.GetFormatedValues());
         }

         Assert.True(barangModel != null);
         Assert.True(barangModel.id == idToGet);

         if (barangModel != null)
         {
            var barangModelJsonStr = JsonConvert.SerializeObject(barangModel);
            var formattedJsonStr = JToken.Parse(barangModelJsonStr).ToString();
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForAdd()
      {
         var barangModel = new BarangModel()
         {
            nama = "Barang #4",
            stok = 48,
            harga_pokok = 56250,
            harga_jual = 75000
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _barangServices.Add(barangModel);
            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = ex.DataAccessStatusInfo.OperationSucceeded;
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }

         try
         {
            Assert.True(operationSecceded);
            _testOutputHelper.WriteLine("Data barang berhasil ditambahkan.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForUpdate()
      {
         var barangModel = new BarangModel()
         {
            id = 1,
            nama = "Barang #1",
            stok = 48,
            harga_pokok = 56250,
            harga_jual = 75000
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _barangServices.Update(barangModel);
            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = ex.DataAccessStatusInfo.OperationSucceeded;
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }

         try
         {
            Assert.True(operationSecceded);
            _testOutputHelper.WriteLine("Data barang berhasil diubah.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }

      [Fact]
      private void ShouldReturnSuccessForDelete()
      {
         var barangModel = new BarangModel()
         {
            id = 5,
         };

         var operationSecceded = false;
         var dataAccessJsonStr = string.Empty;
         var formattedJsonStr = string.Empty;

         try
         {
            _barangServices.Delete(barangModel);
            operationSecceded = true;
         }
         catch (DataAccessException ex)
         {
            operationSecceded = ex.DataAccessStatusInfo.OperationSucceeded;
            dataAccessJsonStr = JsonConvert.SerializeObject(ex.DataAccessStatusInfo);
            formattedJsonStr = JToken.Parse(dataAccessJsonStr).ToString();
         }

         try
         {
            Assert.True(operationSecceded);
            _testOutputHelper.WriteLine("Data barang berhasil dihapus.");
         }
         finally
         {
            _testOutputHelper.WriteLine(formattedJsonStr);
         }
      }
   }
}
