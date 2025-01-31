﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {


        public static ML.Result Add(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            ML.AlumnoMateria resultAlumno = new ML.AlumnoMateria();
            resultAlumno.Alumno = new ML.Alumno();
            resultAlumno.Materia = new ML.Materia();
            resultAlumno.Materia.IdMateria = alumnoMateria.Materia.IdMateria;
            resultAlumno.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaAdd(resultAlumno.Alumno.IdAlumno, resultAlumno.Materia.IdMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE PUDO AGREGAR LA MATERIA";
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


        public static ML.Result Delete(int IdAlumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaDelete(IdAlumnoMateria);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE PUDO ELIMINAR LA MATERIA";
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




        public static ML.Result MateriaGetAsignados(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaGetAsignados(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnoMateria.IdAlumno= obj.IdAlumno.Value;
                            alumnoMateria.IdMateria= obj.IdMateria.Value;
                            alumnoMateria.Alumno= new ML.Alumno();
                            alumnoMateria.Alumno.Nombre= obj.NombreAlumno;
                            alumnoMateria.Alumno.ApellidoPaterno= obj.ApellidoPaterno;
                            alumnoMateria.Alumno.ApellidoMaterno= obj.ApellidoMaterno;
                            alumnoMateria.Materia= new ML.Materia();
                            alumnoMateria.Materia.Nombre= obj.NombreMateria;
                            result.Objects.Add(alumnoMateria);
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

        public static ML.Result MateriaGetNoAsignados(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MDeLunaControlEscolarEntities context = new DL.MDeLunaControlEscolarEntities())
                {
                    var query = context.MateriaGetNoAsignado(IdAlumno).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = obj.Costo.Value;
                            result.Objects.Add(alumnoMateria);
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

    }
}
