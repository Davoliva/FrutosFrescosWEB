using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Comuna
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public decimal provincia { get; set; }

        public bool save()
        {
            try
            {
                COMUNA com = new COMUNA();
                com.COM_ID = id;
                com.COM_NOMBRE = nombre;
                com.PROVINCIA_PROVI_ID = provincia;

                using (var comun = new Common().modelo)
                {
                    comun.COMUNA.Add(com);
                    comun.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Comuna findName(string nombre)
        {
            try
            {
                Comuna comuna = null;
                using (var comun = new Common().modelo)
                {
                    var comunas = comun.COMUNA.ToList();
                    COMUNA comu = comun.COMUNA.First(cc => cc.COM_NOMBRE.Equals(nombre));
                    comuna = new Comuna();
                    comuna.id = comu.COM_ID;
                    comuna.nombre = comu.COM_NOMBRE;
                    comuna.provincia = comu.PROVINCIA_PROVI_ID;
                }

                return comuna;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
