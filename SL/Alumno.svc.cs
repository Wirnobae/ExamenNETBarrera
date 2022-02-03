using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public SL.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        public SL.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        public SL.Result Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.Delete(IdAlumno);
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        public SL.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };

        }

        public SL.Result GetById(int IdUsuario)
        {
            ML.Result result = BL.Alumno.GetById(IdUsuario);
            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };



        }
    }
}
