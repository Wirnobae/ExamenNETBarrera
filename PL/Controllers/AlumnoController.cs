using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        //
        // GET: /Alumno/
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();
            alumno.Roles = new ML.Roles();
            alumno.Alumnos = result.Objects;
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno) //Add { Id null } //Update {Id > 0 }
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Roles = new ML.Roles();
            ML.Result resultAlumno = BL.Alumno.GetAll();
            ML.Result resultRoles = BL.Roles.GetAll();
            if (IdAlumno == null)
            {
                alumno.Roles.Rols = resultRoles.Objects;
                return View(alumno);
            }
            else
            {
                
                ML.Result result = new ML.Result();
                result = BL.Alumno.GetById(IdAlumno.Value);
                if (result.Correct)
                {
                    alumno.Roles = new ML.Roles();
                    alumno = ((ML.Alumno)result.Object);
                    alumno.Alumnos = resultAlumno.Objects;
                    alumno.Roles.Rols = resultRoles.Objects;
                    return View(alumno);
                }
                else
                {

                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
          
            ML.Result result = new ML.Result();
            if (ModelState.IsValid)
            {

                if (alumno.IdAlumno == 0)
                {
                    result = BL.Alumno.Add(alumno);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El alumno se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El alumno no se ha registrado correctamente " + result.ErrorMessage;
                    }

                }
                else
                {
                    result = BL.Alumno.Update(alumno);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El alumno se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El alumno no se ha actualizado correctamente " + result.ErrorMessage;
                    }
                }
            }
            else
            {
                alumno = new ML.Alumno();

                ML.Result resultAlumno = BL.Alumno.GetAll();
                return View(alumno);

            }

            return PartialView("ModalPV");
        }

        public ActionResult Delete(int IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.IdAlumno = IdAlumno;
            ML.Result result = BL.Alumno.Delete(IdAlumno);
            if (result.Correct)
            {
                ViewBag.Mensaje = "El alumno se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El alumno no se ha eliminado correctamente " + result.ErrorMessage;
            }

            return PartialView("ModalPV");
        }


	}
}