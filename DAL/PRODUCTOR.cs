//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTOR
    {
        public PRODUCTOR()
        {
            this.GEOLOCALIZACION = new HashSet<GEOLOCALIZACION>();
            this.PRODUCTO = new HashSet<PRODUCTO>();
        }
    
        public string PROV_RUT { get; set; }
        public string PROV_NOMBRE { get; set; }
        public string PROV_EMAIL { get; set; }
        public decimal COMUNA_COM_ID { get; set; }
        public System.DateTime PROV_FECHA_REGISTRO { get; set; }
        public string PROV_DIRECCION { get; set; }
        public decimal PROV_VALORACION { get; set; }
        public string PROV_ESTADO { get; set; }
    
        public virtual COMUNA COMUNA { get; set; }
        public virtual ICollection<GEOLOCALIZACION> GEOLOCALIZACION { get; set; }
        public virtual ICollection<PRODUCTO> PRODUCTO { get; set; }
    }
}