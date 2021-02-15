using Prime.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Datos.Dao
{
    public class CursoDAO
    {
        int result;

        public List<Curso> Seleccionar()
        {
            List<Curso> lst = new List<Curso>();
            PrimeEntities prime = new PrimeEntities();

            lst = prime.Curso.ToList();

            return lst;
        }

        public int Insertar(Curso curso)
        {
            PrimeEntities prime = new PrimeEntities();
            prime.Curso.Add(curso);

            result = prime.SaveChanges();

            return result;
        }

        public int Actualizar(Curso curso)
        {
            PrimeEntities prime = new PrimeEntities();
            Curso cursoOld = prime.Curso.Where(c => c.CursoId == curso.CursoId).FirstOrDefault();
            
            cursoOld.Codigo = curso.Codigo;
            cursoOld.Nombre = curso.Nombre;            
            
            result = prime.SaveChanges();

            return result;
        }

        public int Eliminar(int Id)
        {
            PrimeEntities prime = new PrimeEntities();
            Curso curso = prime.Curso.Find(Id);
            prime.Curso.Remove(curso);

            result = prime.SaveChanges();

            return result;
        }

    }
}
