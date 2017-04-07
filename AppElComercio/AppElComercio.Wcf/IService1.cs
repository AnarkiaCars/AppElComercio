using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppElComercio.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
      
        [OperationContract]
        List<ordenPagoLista> selectOrdenPago(string SucCodigo, string CodMoneda);

        [OperationContract]
        List<sucursalesLista> selectSucursales(string BanCodigo);
    }

    [DataContract]
    public class ordenPagoLista
    {
        int ordCodigo;
        string banNombre;
        string sucursal;
        decimal monto;
        string moneda;
        string estado;
        DateTime ordfechaPago;

        [DataMember]
        public int OrdCodigo
        {
            get { return ordCodigo; }
            set { ordCodigo = value; }
        }

        [DataMember]
        public string BanNombre
        {
            get { return banNombre; }
            set { banNombre = value; }
        }

        [DataMember]
        public string Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        [DataMember]
        public decimal Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        [DataMember]
        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        [DataMember]
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        [DataMember]
        public DateTime OrdfechaPago
        {
            get { return ordfechaPago; }
            set { ordfechaPago = value; }
        }
    }

    [DataContract]
    public class sucursalesLista
    {
        int sucCodigo;
        string banNombre;
        string sucursal;
        string direccion;
        DateTime fechaRegistro;

        [DataMember]
        public int SucCodigo
        {
            get { return sucCodigo; }
            set { sucCodigo = value; }
        }

        [DataMember]
        public string BanNombre
        {
            get { return banNombre; }
            set { banNombre = value; }
        }

        [DataMember]
        public string Sucursal
        {
            get { return sucursal; }
            set { sucursal = value; }
        }

        [DataMember]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        [DataMember]
        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
    }
}
