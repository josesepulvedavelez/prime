using Prime.Datos.Dao;
using Prime.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prime.Comun;
using System.IO;

namespace Prime.Api.Controllers
{
    [RoutePrefix("Api/Estudiante")]
    public class EstudianteController : ApiController
    {
        int result;
        List<Estudiante> lst;
        EstudianteDAO estudianteDAO;

        [HttpGet]
        [Route("Seleccionar")]
        public List<Estudiante> Seleccionar()
        {
            try
            {
                estudianteDAO = new EstudianteDAO();
                lst = new List<Estudiante>();

                lst = estudianteDAO.Seleccionar();

                return lst;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("C:\\log.txt"))
                {
                    LogErrores.Log(ex.Message, w);                    
                }

                using (StreamReader reg = File.OpenText("C:\\log.txt"))
                {
                    LogErrores.Registro(reg);
                }

                return null;
            }
        }

        [HttpPost]
        [Route("Insertar")]
        public int Insertar([FromBody] Estudiante estudiante)
        {
            try
            {
                estudianteDAO = new EstudianteDAO();
                result = estudianteDAO.Insertar(estudiante);

                return result;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("C:\\log.txt"))
                {
                    LogErrores.Log(ex.Message, w);
                }

                using (StreamReader reg = File.OpenText("C:\\log.txt"))
                {
                    LogErrores.Registro(reg);
                }

                return 0;
            }
        }

        [HttpPut]
        [HttpPost]
        [Route("Actualizar")]
        public int Actualizar([FromBody] Estudiante estudiante)
        {
            try
            {
                estudianteDAO = new EstudianteDAO();
                result = estudianteDAO.Actualizar(estudiante);

                return result;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("C:\\log.txt"))
                {
                    LogErrores.Log(ex.Message, w);
                }

                using (StreamReader reg = File.OpenText("C:\\log.txt"))
                {
                    LogErrores.Registro(reg);
                }

                return 0;
            }
        }

        [HttpDelete]
        [HttpPost]
        [Route("Eliminar")]
        public int Eliminar(int Id)
        {
            try
            {
                estudianteDAO = new EstudianteDAO();
                result = estudianteDAO.Eliminar(Id);

                return result;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText("C:\\log.txt"))
                {
                    LogErrores.Log(ex.Message, w);
                }

                using (StreamReader reg = File.OpenText("C:\\log.txt"))
                {
                    LogErrores.Registro(reg);
                }

                return 0;
            }
        }

    }
}
