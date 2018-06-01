using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Usuario
    {
        public string email { get; set; }
        public string password { get; set; }
        public decimal perfil { get; set; }

        public bool save()
        {
            try
            {
                USUARIO usu = new USUARIO();
                usu.USU_EMAIL = email;
                usu.USU_PASSWORD = password;
                usu.PERFIL_PER_ID = perfil;

                using (var comun = new Common().modelo)
                {
                    comun.USUARIO.Add(usu);
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
                    USUARIO usu = comun.USUARIO.First(uss => uss.USU_EMAIL == email);
                    usu.USU_PASSWORD = password;
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
                    USUARIO usu = comun.USUARIO.First(uss => uss.USU_EMAIL == email);
                    comun.USUARIO.Remove(usu);
                    comun.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario login()
        {
            try
            {
                Usuario us = new Usuario();
                using (var comun = new Common().modelo)
                {
                    USUARIO usu = comun.USUARIO.First(uss => uss.USU_EMAIL.Equals(email) && uss.USU_PASSWORD.Equals(password));

                    if (usu != null)
                    {
                        us.email = usu.USU_EMAIL;
                        us.perfil = usu.PERFIL_PER_ID;
                    }
                }

                return us;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
