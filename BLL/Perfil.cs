using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Perfil
    {
        public decimal id { get; set; }
        public string nombre { get; set; }

        public bool save()
        {
            try
            {
                PERFIL per = new PERFIL();
                per.PER_ID = id;
                per.PER_NOMBRE = nombre;

                using (var comun = new Common().modelo)
                {
                    comun.PERFIL.Add(per);
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
                    PERFIL per = comun.PERFIL.First(p => p.PER_ID == this.id);
                    per.PER_NOMBRE = nombre;
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
                    PERFIL per = comun.PERFIL.First(p => p.PER_ID == this.id);
                    comun.PERFIL.Remove(per);
                    comun.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfil> getAll()
        {
            try
            {
                List<Perfil> list = new List<Perfil>();
                using (var comun = new Common().modelo)
                {
                    var _list = comun.PERFIL.ToList();
                    foreach (var item in _list)
                    {
                        Perfil p = new Perfil() { id = item.PER_ID, nombre = item.PER_NOMBRE };
                        list.Add(p);
                        p = null;
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
