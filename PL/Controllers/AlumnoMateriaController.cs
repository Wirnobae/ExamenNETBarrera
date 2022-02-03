using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        //
        // GET: /AlumnoMateria/
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();
            alumno.Alumnos = result.Objects;
            return View(alumno);
        }

        public ActionResult MateriaGetAsignados(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();
            ML.Result result = BL.AlumnoMateria.MateriaGetAsignados(IdAlumno);
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            alumnoMateria.AlumnoMaterias = result.Objects;
            alumnoMateria.Alumno = ((ML.Alumno)resultAlumno.Object);
            return View(alumnoMateria);
        }

        public ActionResult Delete(int IdAlumnoMateria, int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.IdAlumnoMateria = IdAlumnoMateria;
            ML.Result result = BL.AlumnoMateria.Delete(IdAlumnoMateria);
            ViewBag.MateriasAsignadas = true;
            ViewBag.IdAlumno = IdAlumno;
            if (result.Correct)
            {
                ViewBag.Mensaje = "La materia asignada se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "La materia no se ha eliminado correctamente" + result.Ex;
            }
            return PartialView("ModalPV");
        }


        [HttpGet]
        public ActionResult MateriaGetNoAsignados(int IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Materia = new ML.Materia();
            ML.Result result = BL.AlumnoMateria.MateriaGetNoAsignados(IdAlumno);
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            alumnoMateria.AlumnoMaterias = result.Objects;
            alumnoMateria.Alumno = ((ML.Alumno)resultAlumno.Object);
            return View(alumnoMateria);
        }



        [HttpPost]
        public ActionResult MateriaGetNoAsignados(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnoMateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnos = new ML.AlumnoMateria();

                    alumnos.Alumno = new ML.Alumno();
                    alumnos.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnos.Materia = new ML.Materia();
                    alumnos.Materia.IdMateria = int.Parse(IdMateria);      
                    ML.Result resul = BL.AlumnoMateria.Add(alumnos);
                }
                result.Correct = true;
                ViewBag.Mensaje = "Las materias se han agregado correctamente";
                
            }
            else
            {
                result.Correct = false;
                ViewBag.Mensaje = "Las materias no se han agregado correctamente";

            }
            return PartialView("Modal");
        }



	}
}