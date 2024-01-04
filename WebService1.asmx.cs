using ServicioWeb.Class;
using ServicioWeb.Helper;
using ServicioWeb.Modelds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace ServicioWeb
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {


        private QueryClass qlt=  new QueryClass();
        public UserDetails User;
        [WebMethod]
        [SoapHeader("User")]
        public  List<Userdbt> GetListData()
        {
            try
            {
                if (User != null)
                {
                    if (User.IsValid())
                    {
                        return qlt.GetList();
                    }
                    else
                    {
                        return null;
                    }
                  
                }
                else
                {
                    return null;
                }



            }
            catch(Exception )
            {
                return null ;
            }
           


            
        }


        [WebMethod]
        [SoapHeader("User")]
        public List<Userdbt> GetUser(int id)
        {
            try
            {
                if (User != null)
                {
                    if (User.IsValid())
                    {
                        return qlt.GetUser(id);
                    }
                    else
                    {
                        return null;
                    }
                   
                }
                else
                {
                    return null;
                }



            }
            catch (Exception)
            {
                return null;
            }
            
        }

        [WebMethod]
        [SoapHeader("User")]
        public string CreateUser(string name_user, string email_user, string password_user)
        {
            try
            {
                if (User != null)
                {
                    if (User.IsValid())
                    {
                        return qlt.CreateUser(name_user, email_user, password_user);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }



            }
            catch (Exception)
            {
                return null;
            }



            
        }
        [WebMethod]
        [SoapHeader("User")]
        public string EditarUser(int user_id, string name_user, string email_user, string password_user)
        {
            try
            {
                if (User != null)
                {
                    if (User.IsValid())
                    {
                        return qlt.EditarUser(user_id, name_user, email_user, password_user);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }



            }
            catch (Exception)
            {
                return null;
            }
           
        }

        [WebMethod]
        [SoapHeader("User")]
        public string Delete(int id)
        {
            try
            {
                if (User != null)
                {
                    if (User.IsValid())
                    {
                        return qlt.Delete(id);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }



            }
            catch (Exception)
            {
                return null;
            }
           
        }

    }
}
