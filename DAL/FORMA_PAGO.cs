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
    
    public partial class FORMA_PAGO
    {
        public FORMA_PAGO()
        {
            this.CARRITO = new HashSet<CARRITO>();
        }
    
        public decimal FOPA_ID { get; set; }
        public string FOPA_NOMBRE { get; set; }
        public string FOPA_ESTADO { get; set; }
    
        public virtual ICollection<CARRITO> CARRITO { get; set; }
    }
}
