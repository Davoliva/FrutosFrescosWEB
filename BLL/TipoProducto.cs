using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class TipoProducto
    {
        public decimal id { get; set; }
        public string nombre { get; set; }

        public bool save()
        {
            try
            {
                TIPO_PRODUCTO tp = new TIPO_PRODUCTO();
                tp.TP_ID = id;
                tp.TP_NOMBRE = nombre;
                using (var comun = new Common().modelo)
                {
                    comun.TIPO_PRODUCTO.Add(tp);
                    comun.SaveChanges();
                }
                return true;
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
                    TIPO_PRODUCTO tp = comun.TIPO_PRODUCTO.Where(tpp => tpp.TP_ID == this.id).First();
                    tp.TP_NOMBRE = nombre;
                    comun.SaveChanges();
                }
                return true;
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
                    TIPO_PRODUCTO tp = comun.TIPO_PRODUCTO.Where(tpp => tpp.TP_ID == this.id).First();
                    comun.TIPO_PRODUCTO.Remove(tp);
                    comun.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoProducto> getAll()
        {
            try
            {
                List<TipoProducto> list = new List<TipoProducto>();
                using (var comun = new Common().modelo)
                {
                    List<TIPO_PRODUCTO> _list = comun.TIPO_PRODUCTO.ToList();
                    foreach (var item in _list)
                    {
                        TipoProducto _tp = new TipoProducto() { id = item.TP_ID, nombre = item.TP_NOMBRE };
                        list.Add(_tp);
                        _tp = null;
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TipoProducto getByIdStatic(decimal id)
        {
            try
            {
                TipoProducto p = new TipoProducto();
                using (var comun = new Common().modelo)
                {
                    TIPO_PRODUCTO pp = comun.TIPO_PRODUCTO.First(tpp => tpp.TP_ID == id);

                    p.id = pp.TP_ID;
                    p.nombre = pp.TP_NOMBRE;
                    
                }
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoProducto getById()
        {
            try
            {
                TipoProducto p = new TipoProducto();
                using (var comun = new Common().modelo)
                {
                    TIPO_PRODUCTO pp = comun.TIPO_PRODUCTO.First(tpp => tpp.TP_ID == id);

                    p.id = pp.TP_ID;
                    p.nombre = pp.TP_NOMBRE;

                }
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
