using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AppElComercio.Wcf
{
    public class Conexion
    {
        public SqlConnection GetConexion()
        {
            try
            {
                SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=DBTemplate;Integrated Security=True");
                return Conexion;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
