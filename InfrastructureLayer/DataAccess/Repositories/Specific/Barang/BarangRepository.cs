using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models.Barang;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using CommonComponents;
using Dapper;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Barang
{
   public class BarangRepository : IBarangRepository
   {
      private DapperContext _context;

      enum TypeOfExistenceCheck
      {
         DoesExistInDB,
         DoesNotExistInDB
      }

      enum RequestType
      {
         Add,
         Update,
         Read,
         Delete,
         ConfirmAdd,
         ConfirmDelete
      }

      public BarangRepository()
      {
         _context = new DapperContext();
      }

      public BarangRepository(DapperContext context)
      {
         _context = context;
      }

      public IEnumerable<BarangModel> GetAll()
      {
         var listObj = new List<BarangModel>();

         var dataAccessStatus = new DataAccessStatus();

         try
         {
            listObj = _context.Conn.GetAll<BarangModel>().ToList();
         }
         catch (SQLiteException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Tidak dapat mengambil list Model barang dari Database.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return listObj;
      }

      public BarangModel GetById(int id)
      {
         BarangModel model = null;
         var dataAccessStatus = new DataAccessStatus();

         try
         {
            model = _context.Conn.Get<BarangModel>(id);
         }
         catch (SQLiteException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Tidak dapat mengambil data barang yang sesuai dengan permintaan id.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         if (model == null)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: "",
                                       customMessage: "Data tidak ditemukan. " +
                                       $"Tidak dapat mengambil data barang yang sesuai dengan permintaan id {id}. " +
                                       $"ID {id} tidak ada di database.",
                                       helpLink: "", errorCode: 0, stackTrace: "");
            throw new DataAccessException(dataAccessStatus: dataAccessStatus);
         }

         return model;
      }

      public void Add(IBarangModel barangModel)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         var exists = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) from barang where nama=@nama", new { barangModel.nama });

         if (exists)
         {
            dataAccessStatus.Status = "Error";
            dataAccessStatus.CustomMessage = "Nama barang sudah ada, silahkan ganti dengan nama yang lain.";

            throw new DataAccessException(dataAccessStatus); ;
         }

         try
         {
            _context.Conn.Insert((BarangModel)barangModel);
         }
         catch (SQLiteException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Terjadi kesalahan saat menambahkan data Barang.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(barangModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.ConfirmAdd);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.Status = "Error";
            ex.DataAccessStatusInfo.OperationSucceeded = false;
            ex.DataAccessStatusInfo.CustomMessage = "Tidak dapat menemukan data barang di database setelah sukses menambahkan data.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }
      }

      public void Update(IBarangModel barangModel)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((BarangModel)barangModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Update);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.CustomMessage = "Barang tidak dapat diubah, dikarenakan data barang tidak ditemukan.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }

         try
         {
            _context.Conn.Update((BarangModel)barangModel);
         }
         catch (SQLiteException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Terjadi kesalahan saat menyimpan data Barang.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

      }

      public void Delete(IBarangModel barangModel)
      {
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            RecordExistsCheck((BarangModel)barangModel, TypeOfExistenceCheck.DoesExistInDB, RequestType.Delete);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.CustomMessage = "Barang tidak dapat dihapus, dikarenakan data barang tidak ditemukan.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }

         try
         {
            _context.Conn.Delete((BarangModel)barangModel);
         }
         catch (SQLiteException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Terjadi kesalahan saat menghapus data Barang.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         try
         {
            RecordExistsCheck(barangModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.ConfirmDelete);
         }
         catch (DataAccessException ex)
         {
            ex.DataAccessStatusInfo.Status = "Error";
            ex.DataAccessStatusInfo.OperationSucceeded = false;
            ex.DataAccessStatusInfo.CustomMessage = "Gagal menghapus data barang di database.";
            ex.DataAccessStatusInfo.ExceptionMessage = string.Copy(ex.Message);
            ex.DataAccessStatusInfo.StackTrace = string.Copy(ex.StackTrace);

            throw ex;
         }
      }

      private bool RecordExistsCheck(IBarangModel barangModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
      {
         bool exists = false;
         bool recordExistsCheckPassed = true;

         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            if (requestType == RequestType.Add || requestType == RequestType.ConfirmAdd)
            {
               exists = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) from barang where nama=@nama", new { barangModel.nama });
            }
            else if (requestType == RequestType.Update || requestType == RequestType.ConfirmDelete || requestType == RequestType.Delete)
            {
               exists = _context.Conn.ExecuteScalar<bool>("SELECT COUNT(1) from barang where id=@id", new { barangModel.id });
            }
         }
         catch (SQLiteException ex)
         {
            throw ex;
         }

         if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesExistInDB) && !exists)
         {
            dataAccessStatus.Status = "Error";
            recordExistsCheckPassed = false;

            throw new DataAccessException(dataAccessStatus);
         }
         else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && exists)
         {
            dataAccessStatus.Status = "Error";
            recordExistsCheckPassed = false;

            throw new DataAccessException(dataAccessStatus);
         }

         return recordExistsCheckPassed;
      }
   }
}
