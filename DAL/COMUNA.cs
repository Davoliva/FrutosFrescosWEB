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
    
    public partial class COMUNA
    {
        public COMUNA()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
            this.ENTREGA = new HashSet<ENTREGA>();
            this.ENTREGA1 = new HashSet<ENTREGA>();
            this.PRODUCTOR = new HashSet<PRODUCTOR>();
        }
    
        public decimal COM_ID { get; set; }
        public string COM_NOMBRE { get; set; }
        public decimal PROVINCIA_PROVI_ID { get; set; }
    
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        public virtual PROVINCIA PROVINCIA { get; set; }
        public virtual ICollection<ENTREGA> ENTREGA { get; set; }
        public virtual ICollection<ENTREGA> ENTREGA1 { get; set; }
        public virtual ICollection<PRODUCTOR> PRODUCTOR { get; set; }
    }
}
