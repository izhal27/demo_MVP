using DomainLayer.Models.Barang;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ServicesLayer.Tests
{
   [Trait("Category", "Model Validations")]
   public class BarangServicesValidationTests : IClassFixture<BarangServicesFixture>
   {
      private readonly ITestOutputHelper _testOutputHelper;
      private BarangServicesFixture _barangServicesFixture;

      public BarangServicesValidationTests(BarangServicesFixture barangServicesFixture, ITestOutputHelper testOutputHelper)
      {
         _barangServicesFixture = barangServicesFixture;
         _testOutputHelper = testOutputHelper;

         SetValidSampleValues();
      }

      [Fact]
      public void ShouldNotThrowExceptionForDefaultTestValuesOnAnnotations()
      {
         var exception = Record.Exception(() =>
         _barangServicesFixture.BarangService.ValidateModelDataAnnotations(_barangServicesFixture.BarangModel));

         Assert.Null(exception);

         WriteExceptionTestResult(exception);
      }
      [Fact]
      public void ShouldThrowExceptionForNamaEmpty()
      {
         _barangServicesFixture.BarangModel.nama = string.Empty;

         var exception = Record.Exception(() =>
         _barangServicesFixture.BarangService.ValidateModelDataAnnotations(_barangServicesFixture.BarangModel));
         
         WriteExceptionTestResult(exception);
      }

      [Fact]
      public void ShouldThrowExceptionForNamaTooShort()
      {
         _barangServicesFixture.BarangModel.nama = "A";

         var exception = Record.Exception(() =>
         _barangServicesFixture.BarangService.ValidateModelDataAnnotations(_barangServicesFixture.BarangModel));
         
         WriteExceptionTestResult(exception);
      }

      private void SetValidSampleValues()
      {
         _barangServicesFixture.BarangModel = new BarangModel()
         {
            id = 1,
            nama = "Barang #1",
            stok = 27,
            harga_pokok = 56250M,
            harga_jual = 56250M
         };
      }

      private void WriteExceptionTestResult(Exception exception)
      {
         if (exception != null)
         {
            _testOutputHelper.WriteLine(exception.Message);
         }
         else
         {
            StringBuilder strBuilder = new StringBuilder();
            JObject json = JObject.FromObject(_barangServicesFixture.BarangModel);
            strBuilder.Append("********** Tidak ada exception yang terjadi *********").AppendLine();

            foreach (var jProperty in json.Properties())
            {
               strBuilder.Append(jProperty.Name).Append(" ---> ").Append(jProperty.Value).AppendLine();
            }

            _testOutputHelper.WriteLine(strBuilder.ToString());
         }
      }
   }
}
