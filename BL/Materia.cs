using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add (ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo,materia.Creditos);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La materia no se pudo insertar correctamente.";
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

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo,materia.Creditos);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La materia no se pudo actualizar correctamente.";
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

        public static ML.Result Delete(int materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaDelete(materia);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La materia no se pudo insertar correctamente.";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;
                            materia.Creditos = obj.Creditos.Value;
                            result.Objects.Add(materia);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Materia";
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

        public static ML.Result GetById( int materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaGetById(materia).FirstOrDefault();
                    result.Object = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                            ML.Materia materias = new ML.Materia();
                            materias.IdMateria = query.IdMateria;
                            materias.Nombre = query.Nombre;
                            materias.Costo = query.Costo.Value;
                            materias.Creditos = query.Creditos.Value;
                            result.Object = materias;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "DATOS NO ENCONTRADOS";
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



    }
}
