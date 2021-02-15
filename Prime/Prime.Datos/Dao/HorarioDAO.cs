using Prime.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Datos.Dao
{
    public class HorarioDAO
    {
        int result;

        public List<Horario> Seleccionar()
        {
            List<Horario> lst = new List<Horario>();
            PrimeEntities prime = new PrimeEntities();

            lst = prime.Horario.ToList();

            return lst;
        }

        public int Insertar(Horario horario)
        {
            PrimeEntities prime = new PrimeEntities();
            prime.Horario.Add(horario);

            result = prime.SaveChanges();

            return result;
        }

        public int Actualizar(Horario horario)
        {
            PrimeEntities prime = new PrimeEntities();
            Horario horarioOld = prime.Horario.Where(h => h.HorarioId == horario.HorarioId).FirstOrDefault();

            horarioOld.Dia = horario.Dia;
            horarioOld.Hora = horario.Hora;
            horarioOld.Aula = horario.Aula;
            horarioOld.EstudianteId = horario.EstudianteId;
            horarioOld.Curso = horario.Curso;

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
