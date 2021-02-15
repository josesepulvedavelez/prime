using Prime.Datos.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Datos.Dao
{
    public class EstudianteDAO
    {
        int result; 

        public List<Estudiante> Seleccionar()
        {
            List<Estudiante> lst = new List<Estudiante>();
            PrimeEntities prime = new PrimeEntities();

            lst = prime.Estudiante.ToList();

            return lst;
        }

        public int Insertar(Estudiante estudiante)
        {
            PrimeEntities prime = new PrimeEntities();
            prime.Estudiante.Add(estudiante);
            
            result = prime.SaveChanges();

            return result;
        }

        public int Actualizar(Estudiante estudiante)
        {
            PrimeEntities prime = new PrimeEntities();
            Estudiante estudianteOld = prime.Estudiante.Where(e => e.EstudianteId == estudiante.EstudianteId).FirstOrDefault();
            
            estudianteOld.Codigo = estudiante.Codigo;
            estudianteOld.Nombres = estudiante.Nombres;
            estudianteOld.Apellidos = estudiante.Apellidos;
            estudianteOld.Acudiente = estudiante.Acudiente;
            estudianteOld.Usuario = estudiante.Usuario;
            estudianteOld.Contraseña = estudiante.Contraseña;
            
            result = prime.SaveChanges();

            return result;
        }

        public int Eliminar(int Id)
        {
            PrimeEntities prime = new PrimeEntities();
            Estudiante estudiante = prime.Estudiante.Find(Id);
            prime.Estudiante.Remove(estudiante);

            result = prime.SaveChanges();

            return result;
        }
    }
}
