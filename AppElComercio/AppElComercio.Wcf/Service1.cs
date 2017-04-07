using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace AppElComercio.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "ListaOrdenPago/{SucCodigo}/{CodMoneda}")]
        public List<ordenPagoLista> selectOrdenPago(string SucCodigo, string CodMoneda)
        {
            DataSet _ds = new DataSet();
            try
            {
                Conexion _Conexion = new Conexion();
                SqlConnection Con = _Conexion.GetConexion();

                Con.Open();

                SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = Con;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "up_ordenPago_listar";
                _cmd.Parameters.Add("@SucCodigo", SqlDbType.Int).Direction = ParameterDirection.Input;
                _cmd.Parameters.Add("@OrdMoneda", SqlDbType.Int).Direction = ParameterDirection.Input;
                _cmd.Parameters[0].Value = int.Parse(SucCodigo);
                _cmd.Parameters[1].Value = int.Parse(CodMoneda);
                SqlDataAdapter _adaptador = new SqlDataAdapter(_cmd);
                _adaptador.Fill(_ds);

                _cmd.Dispose();

                Con.Close();
            }
            catch (Exception)
            { throw; }

            if (_ds != null && _ds.Tables.Count == 1)
            {
                List<ordenPagoLista> ListaSalida = new List<ordenPagoLista>();

                foreach (DataRow dr in _ds.Tables[0].Rows)
                {
                    ordenPagoLista oordenpagoSalida = new ordenPagoLista();
                    oordenpagoSalida.OrdCodigo = int.Parse(dr["OrdCodigo"].ToString());
                    oordenpagoSalida.BanNombre = dr["banNombre"].ToString();
                    oordenpagoSalida.Sucursal = dr["SucNombre"].ToString();
                    oordenpagoSalida.Monto = decimal.Parse(dr["OrdMonto"].ToString());
                    oordenpagoSalida.Moneda = dr["Moneda"].ToString();
                    oordenpagoSalida.Estado = dr["Estado"].ToString();
                    oordenpagoSalida.OrdfechaPago = DateTime.Parse(dr["OrdFechaPago"].ToString());

                    ListaSalida.Add(oordenpagoSalida);
                }

                return ListaSalida; 
            }
            else
            { return null; }
        }

        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Xml,
                    UriTemplate = "ListaSucursalesXbanco/{BanCodigo}")]
        public List<sucursalesLista> selectSucursales(string BanCodigo)
        {
            DataSet _ds = new DataSet();
            try
            {
                Conexion _Conexion = new Conexion();
                SqlConnection Con = _Conexion.GetConexion();

                Con.Open();

                SqlCommand _cmd = new SqlCommand();
                _cmd.Connection = Con;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "up_sucursales_x_banco";
                _cmd.Parameters.Add("@BanCodigo", SqlDbType.Int).Direction = ParameterDirection.Input;
                _cmd.Parameters[0].Value = int.Parse(BanCodigo);
                SqlDataAdapter _adaptador = new SqlDataAdapter(_cmd);
                _adaptador.Fill(_ds);

                _cmd.Dispose();

                Con.Close();
            }
            catch (Exception)
            { throw; }

            if (_ds != null && _ds.Tables.Count == 1)
            {
                List<sucursalesLista> ListaSalida = new List<sucursalesLista>();

                foreach (DataRow dr in _ds.Tables[0].Rows)
                {
                    sucursalesLista oordenpagoSalida = new sucursalesLista();
                    oordenpagoSalida.SucCodigo = int.Parse(dr["SucCodigo"].ToString());
                    oordenpagoSalida.BanNombre = dr["banNombre"].ToString();
                    oordenpagoSalida.Sucursal = dr["SucNombre"].ToString();
                    oordenpagoSalida.Direccion = dr["SucDireccion"].ToString();
                    oordenpagoSalida.FechaRegistro = DateTime.Parse(dr["SucFechaRegistro"].ToString());

                    ListaSalida.Add(oordenpagoSalida);
                }

                return ListaSalida;
            }
            else
            { return null; }
        }
    }
}
