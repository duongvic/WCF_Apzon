using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;
namespace DataAcess
{
   public class DataConnect
    {
       DataTable dt ;
       SqlConnection con = null;
       public SqlConnection GetConnect()
       {
           return new SqlConnection(@"Data Source=.;Initial Catalog=PointOfSale;Persist Security Info=True;User ID=sa;Password=123456"); ;
       }

       public DataTable GetTable(string sql)
       {
            con = GetConnect();
           SqlDataAdapter da = new SqlDataAdapter(sql, con);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       }

       public void ExcuteNonQuery(string sql)
       {
           con = GetConnect();
           con.Open();
           SqlCommand cmd = new SqlCommand(sql, con);
           cmd.ExecuteNonQuery();
           cmd.Dispose();
           con.Close();
           
       }

       // Hàm thực hiện câu truy vấn INSERT, UPDATE, DELETE trả về thực hiện thành công hay ko
       //public bool ExecuteQuery(string sql)
       //{
       //    int numRecordsEffect = 0;
       //    try
       //    {
       //        if (con.State == ConnectionState.Closed)
       //            con.Open();
       //        SqlCommand cmd = new SqlCommand(sql, con);
       //        numRecordsEffect = cmd.ExecuteNonQuery();
       //        if (con.State == ConnectionState.Open)
       //            con.Close();
       //    }
       //    catch (Exception ex)
       //    {
       //        throw;
       //    }
       //    if (numRecordsEffect > 0)
       //        return true;
       //    return false;
       //}
      
       public bool CheckExistValue(string nameTable, string nameFiled, string value)
       {
           string sql = "SELECT * FROM " + nameTable + " WHERE " + nameFiled + " = '" + value + "'";
           GetTable(sql);
           // Đếm số dòng trả về, nếu > 0  tức tồn tại value
           if (dt.Rows.Count > 0)
               return true;
           return false;
       }

       // Lấy mã cuối cùng
       public string GetLastID(string nameTable, string nameFiled)
       {
           string sql = "SELECT TOP 1 " + nameFiled + " FROM " + nameTable + " ORDER BY " + nameFiled + " DESC";
           // thực hiện câu truy vấn trên
           GetTable(sql);
         return dt.Rows[0][nameFiled].ToString();
       }
     
    }
}
