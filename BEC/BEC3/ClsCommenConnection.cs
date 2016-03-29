using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BEC3
{
    class ClsCommenConnection
    {
        public SqlConnection con = new SqlConnection(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Connection.INI"));
        public SqlCommand cmd = new SqlCommand();
    }
}
