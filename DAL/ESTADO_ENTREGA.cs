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
    
    public partial class ESTADO_ENTREGA
    {
        public ESTADO_ENTREGA()
        {
            this.ENTREGA = new HashSet<ENTREGA>();
        }
    
        public decimal EST_ID { get; set; }
        public string EST_NOMBRE { get; set; }
    
        public virtual ICollection<ENTREGA> ENTREGA { get; set; }
    }
}
