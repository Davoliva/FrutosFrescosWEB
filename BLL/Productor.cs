using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Productor
    {

        public string rut { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public decimal comuna { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public string direccion { get; set; }
        public decimal valoracion { get; set; }
        public string estado { get; set; }

        public bool save()
        {
            try
            {
                PRODUCTOR p = new PRODUCTOR();
                p.PROV_RUT = rut;
                p.PROV_NOMBRE = nombre;
                p.PROV_EMAIL = email;
                p.COMUNA_COM_ID = comuna;
                p.PROV_FECHA_REGISTRO = fecha_registro;
                p.PROV_DIRECCION = direccion;
                p.PROV_VALORACION = 0;
                p.PROV_ESTADO = "H";

                using (var comun = new Common().modelo)
                {
                    comun.PRODUCTOR.Add(p);
                    comun.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool update()
        {
            try
            {
                using (var comun = new Common().modelo)
                {
                    PRODUCTOR p = comun.PRODUCTOR.First(pp => pp.PROV_RUT == rut);
                    p.PROV_NOMBRE = nombre;
                    p.PROV_EMAIL = email;
                    p.COMUNA_COM_ID = comuna;
                    p.PROV_FECHA_REGISTRO = fecha_registro;
                    p.PROV_DIRECCION = direccion;
                    p.PROV_VALORACION = valoracion;
                    p.PROV_ESTADO = estado;
                    comun.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool delete()
        {
            try
            {
                using (var comun = new Common().modelo)
                {
                    PRODUCTOR p = comun.PRODUCTOR.First(pp => pp.PROV_RUT == rut);
                    comun.PRODUCTOR.Remove(p);
                    comun.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Productor findProductorByEmail(String email)
        {
            try
            {
                Productor pp = null;
                using (var comun = new Common().modelo)
                {
                    PRODUCTOR p = comun.PRODUCTOR.First(ppp => ppp.PROV_EMAIL.Equals(email));
                    pp = new Productor();
                    pp.rut = p.PROV_RUT;
                    return pp;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
