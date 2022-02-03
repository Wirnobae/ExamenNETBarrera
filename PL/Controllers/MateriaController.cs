using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        //
        // GET: /Materia/
        public ActionResult GetAll()
        {
            ML.Materia resultMateria = new ML.Materia();
            resultMateria.Materias = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1718/api/");

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
                        resultMateria.Materias.Add(resultItemList);
                    }
                }
            }
            return View(resultMateria);
        }


        [HttpGet]
        public ActionResult Form(int? IdMateria) //Add { Id null } //Update {Id > 0 }
        {
            ML.Materia materia = new ML.Materia();

            ML.Result resultMateria = BL.Materia.GetAll();

            if (IdMateria == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1718/api/");
                    var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Materia resultItemList = new ML.Materia();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        materia = ((ML.Materia)result.Object);

                        return View(materia);
                    }
                    else
                    {

                    }
                }
            }
            return View();
        }





        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            char[] ValidacionMateria = System.Configuration.ConfigurationManager.AppSettings["ValidacionNombreMateria"].ToCharArray();
            foreach (char caracter in ValidacionMateria)
            {
                materia.Nombre = materia.Nombre.Replace(caracter.ToString(), "");
            }
            ML.Result result = new ML.Result();
            if (ModelState.IsValid)
            {
                if (materia.IdMateria == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:1718/api/");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                        postTask.Wait();

                        var resultAseguradora = postTask.Result;
                        if (resultAseguradora.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "La materia se ha registrado correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La materia no se ha registrado correctamente " + result.ErrorMessage;
                        }

                    }

                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:1718/api/");

                        //HTTP POST
                        var postTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update/" + materia.IdMateria, materia);
                        postTask.Wait();

                        var resultAseguradora = postTask.Result;
                        if (resultAseguradora.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "La materia se ha actualizado correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La materia no se ha actualizado correctamente " + result.ErrorMessage;
                        }
                    }
                }
            }
            else
            {
                materia = new ML.Materia();

                ML.Result resultAlumno = BL.Materia.GetAll();
                return View(materia);

            }

            return PartialView("ModalPV");
        }



        public ActionResult Delete(int IdMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result resultMateria = new ML.Result();
            //aseguradora.IdAseguradora= IdAseguradora;   
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1718/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "La materia se ha eliminado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "La materia no se ha eliminado correctamente " + resultMateria.ErrorMessage;
                }

                return PartialView("ModalPV");
            }

        }
    }
}