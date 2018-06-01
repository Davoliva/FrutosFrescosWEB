using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Producto
    {
        public decimal id { get; set; }
        public string nombre { get; set; }
        public decimal cantidad { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public decimal tipo_producto { get; set; }
        public string productor { get; set; }

        public bool save()
        {

            try
            {
                PRODUCTO pd = new PRODUCTO();
                pd.PROD_ID = id;
                pd.PRO_NOMBRE = nombre;
                pd.PROD_CANTIDAD = cantidad;
                pd.PROD_DESCRIPCION = descripcion;
                pd.PROD_PRECIO = precio;
                pd.TIPO_PRODUCTO_TP_ID = tipo_producto;
                pd.PRODUCTOR_PROV_RUT = productor;

                using (var comun = new Common().modelo)
                {
                    comun.PRODUCTO.Add(pd);
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
                    PRODUCTO pd = comun.PRODUCTO.First(pdd => pdd.PROD_ID == id);
                    pd.PRO_NOMBRE = nombre;
                    pd.PROD_CANTIDAD = cantidad;
                    pd.PROD_DESCRIPCION = descripcion;
                    pd.PROD_PRECIO = precio;
                    pd.TIPO_PRODUCTO_TP_ID = tipo_producto;
                    pd.PRODUCTOR_PROV_RUT = productor;
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
                    PRODUCTO pd = comun.PRODUCTO.First(pdd => pdd.PROD_ID == id);
                    comun.PRODUCTO.Remove(pd);
                    comun.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Producto> findByProductor(String rutProductor)
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                using (var comun = new Common().modelo)
                {
                    var _list = comun.PRODUCTO.Where(pdd => pdd.PRODUCTOR_PROV_RUT.Equals(rutProductor)).ToList();
                    foreach (var item in _list)
                    {
                        Producto p = new Producto();
                        p.id = item.PROD_ID;
                        p.nombre = item.PRO_NOMBRE;
                        p.descripcion = item.PROD_DESCRIPCION;
                        p.cantidad = item.PROD_CANTIDAD;
                        p.precio = item.PROD_PRECIO;
                        p.productor = item.PRODUCTOR_PROV_RUT;
                        p.tipo_producto = item.TIPO_PRODUCTO_TP_ID;
                        productos.Add(p);
                        p = null;
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static decimal getLastId()
        {
            using (var comun = new Common().modelo)
            {
                var data = comun.PRODUCTO.ToList().OrderBy(pp => pp.PROD_ID).Last().PROD_ID;

                return data + 1;
            }
        }

        public Producto getById()
        {
            try
            {
                Producto producto = new Producto();
                using (var comun = new Common().modelo)
                {
                    var data = comun.PRODUCTO.First(ppp => ppp.PROD_ID == this.id);

                    Producto p = new Producto();
                    p.id = data.PROD_ID;
                    p.nombre = data.PRO_NOMBRE;
                    p.descripcion = data.PROD_DESCRIPCION;
                    p.cantidad = data.PROD_CANTIDAD;
                    p.precio = data.PROD_PRECIO;
                    p.productor = data.PRODUCTOR_PROV_RUT;
                    p.tipo_producto = data.TIPO_PRODUCTO_TP_ID;
                    return p;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
