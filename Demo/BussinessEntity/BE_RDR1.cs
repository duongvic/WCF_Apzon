using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;
using System.Data.SqlClient;
using System.Data;
using BusinessObject;

namespace BussinessEntity
{
   public class BE_RDR1
    {
       DataConnect kn = new DataConnect();

       public DataTable ShowRDR1()
       {
           string sql = "select * from RDR1";         
           return kn.GetTable(sql);
       }

       public DataTable showRDR1ByDocEntry(int DocEntry)
       {
           string sql = "SELECT * FROM RDR1 WHERE Docentry= " + DocEntry;
           DataTable dt = kn.GetTable(sql);
           return dt;
       }
       public void addRDR1(BO_RDR1 obj)
       {
           try
           {
               string sql = @"INSERT INTO RDR1 (ItemCode, Dscription, Quantity, Price, DiscPrcnt, TaxCode, LineTotal, WhsCode, ShipDate, FreeTxt, OpenQty,Currency,Rate,     DocEntry,LineNum, BaseType, BaseEntry,BaseLine, AcctCode) ";
               sql += " VALUES ('" + obj.ItemCode + "','" + obj.Dscription + "','" + obj.Quantity + "','" + obj.TaxCode + "','" + obj.LineTotal + "','" + obj.WhsCode + "','" + obj.ShipDate
                                   + "','" + obj.FreeTxt + "', '" + obj.OpenQty + "','" + obj.Currency + "','" + obj.Rate + "',      ' ', ' ' , ' ' , ' ' , ' ' , ' '    )";
               kn.ExcuteNonQuery(sql);
           }
           catch (Exception)
           {

               throw;
           }
       }

       public void updateRDR1(BO_RDR1 obj)
       {
           try
           {

               string sql = @"Update RDR1 
                                         SET ItemCode ='" + obj.ItemCode + "', Dscription ='" + obj.Dscription + "', Quantity='" + obj.Quantity + "', TaxCode='" + obj.TaxCode
                                             + "',LineTotal ='" + obj.LineTotal + "', WhsCode = '" + obj.WhsCode + "',ShipDate = '" + obj.ShipDate + "',FreeTxt='" + obj.FreeTxt + "',OpenQty='" + obj.OpenQty
                                             + "',Currency='" + obj.Currency + "',Rate='" + obj.Rate + "', DocEntry=' ' ,LineNum =' ',BaseType=' ', BaseEntry =' ', BaseLine = ' ', AcctCode = ' '  ";
               sql += " WHERE ItemCode = '" + obj.ItemCode + "' ";
               kn.ExcuteNonQuery(sql);
           }
           catch (Exception)
           {

               throw;
           }
       }

    }
}
