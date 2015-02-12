using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;
using BusinessObject;
using System.Data;

namespace BussinessEntity
{
  public class BE_OCRD
    {
      DataConnect kn = new DataConnect ();

      public DataTable showOCRD()
      {
          string sql = "select * from OCRD ";         
          return kn.GetTable(sql);
      }
    }
}
