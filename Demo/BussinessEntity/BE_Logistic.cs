using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;
using System.Data;
using System.Data.SqlClient;
using BusinessObject;

namespace BussinessEntity
{
  public class BE_Logistic
    {
      DataConnect kn = new DataConnect();

      public DataTable showLogistic()
      {
          string sql = "select * from Logistic";  
          return kn.GetTable(sql); ;

      }

      public void addLogistic(BO_Logistic obj)
      {
          try
          {
              string sql =  @"INSERT INTO Logistic (TrnspCode, ShipToCode, PayToCode,Confirmed ) ";
                     sql += " VALUES ('" + obj.TrnspCode + "','" + obj.ShipToCode  + "','" + obj.PayToCode  + "','" + obj.Confirmed + "' ) " ;                                                                    
              kn.ExcuteNonQuery(sql);
          }
          catch (Exception)
          {

              throw;
          }
      }

      public void updateLogistic(BO_Logistic obj)
      {
          try
          {
              string sql = @"UPDATE Logistic ";
                    sql +="                     SET TrnspCode= '"+obj.TrnspCode+"' ,ShipToCode = '"+obj.ShipToCode+"' ,PayToCode= '"+obj.PayToCode+"' , Confirmed = '"+obj.Confirmed+"' ";
          }
          catch (Exception) { throw; }
      }
    }
}
