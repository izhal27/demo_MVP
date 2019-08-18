using CommonComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories
{
   public class DapperContext : IDisposable
   {
      private IDbConnection _conn;
      private IDbTransaction _transaction;
      private readonly string _connString;
      private readonly string _providerName;

      public IDbConnection Conn
      {
         get { return _conn ?? (_conn = GetOpenConnection(_connString, _providerName)); }
      }

      public IDbTransaction Transaction
      {
         get { return _transaction; }
      }

      public DapperContext()
      {
         _providerName = @"System.Data.SQLite";
         _connString = @"Data Source=|DataDirectory|\db_product.sqlite;Version=3;";

         if (_conn == null)
         {
            _conn = GetOpenConnection(_connString, _providerName);
         }
      }

      private IDbConnection GetOpenConnection(string connString, string providerName)
      {
         IDbConnection conn = null;
         DataAccessStatus dataAccessStatus = new DataAccessStatus();

         try
         {
            var provider = DbProviderFactories.GetFactory(providerName);
            conn = provider.CreateConnection();
            conn.ConnectionString = connString;
            conn.Open();
         }
         catch (SQLiteException ex)
         {
            dataAccessStatus.SetValues(status: "Error", operationSucceeded: false, exceptionMessage: ex.Message,
                                       customMessage: "Tidak dapat membuka koneksi ke Database.",
                                       helpLink: ex.HelpLink, errorCode: ex.ErrorCode, stackTrace: ex.StackTrace);
            throw new DataAccessException(message: ex.Message, innerException: ex.InnerException,
                                          dataAccessStatus: dataAccessStatus);
         }

         return conn;
      }
      
      public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
      {
         if (_transaction != null)
         {
            _transaction = Conn.BeginTransaction(isolationLevel);
         }
      }

      public void Commit()
      {
         if (_transaction != null)
         {
            _transaction.Commit();
            _transaction = null;
         }
      }

      public void RollBack()
      {
         if (_transaction != null)
         {
            _transaction.Rollback();
            _transaction = null;
         }
      }

      public void Dispose()
      {
         if (_conn != null)
         {
            try
            {
               if (_conn.State == ConnectionState.Open)
               {
                  RollBack();
                  _conn.Close();
               }
            }
            finally
            {
               _conn.Dispose();
            }
         }

         GC.SuppressFinalize(this);
      }
   }
}
