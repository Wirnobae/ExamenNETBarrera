using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Roles
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.RolesGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Roles roles = new ML.Roles();
                            roles.IdRol = obj.IdRol;
                            roles.Nombre = obj.Nombre;
                            result.Objects.Add(roles);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Roles";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        //public static ML.Result GetById(int IdRol)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
        //        {
        //            var query = context.(IdRol).FirstOrDefault();
        //            result.Object = new List<object>();

        //            if (query != null)
        //            {
        //                result.Objects = new List<object>();
        //                ML.Materia materias = new ML.Materia();
        //                materias.IdMateria = query.IdMateria;
        //                materias.Nombre = query.Nombre;
        //                materias.Costo = query.Costo.Value;
        //                materias.Creditos = query.Creditos.Value;
        //                result.Object = materias;
        //                result.Correct = true;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "ROL NO ENCONTRADO";
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}


    }
}
