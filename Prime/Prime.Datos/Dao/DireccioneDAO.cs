using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prime.Datos.Entity;
using System.Configuration;

namespace Prime.Datos.Dao
{
    public class DireccioneDAO
    {
        SqlConnection conexion;
        SqlDataReader lector;
        SqlCommand comando;
        int result;
        string cadena = ConfigurationManager.ConnectionStrings["PrimeEntities"].ConnectionString;

        public List<Direccion> Seleccionar()
        {
            List<Direccion> lst = new List<Direccion>();

            using (conexion = new SqlConnection(cadena))
            {
                conexion.Open();

                using (comando = new SqlCommand("DireccionSelect", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Direccion direccion = new Direccion
                        {
                            Pais = Convert.ToString(lector["Pais"]),
                            Estado = Convert.ToString(lector["Estado"]),
                            Ciudad = Convert.ToString(lector["Ciudad"]),
                            Barrio = Convert.ToString(lector["Barrio"]),
                            Calle = Convert.ToString(lector["Calle"]),
                            CasaApto = Convert.ToString(lector["CasaApto"]),
                            DireccionId = Convert.ToInt32(lector["DireccionId"]),
                            EstudianteId = Convert.ToInt32(lector["EstudianteId"])
                        };
                        lst.Add(direccion);
                    }
                }
            }
            return lst;
        }

        public List<Direccion> SeleccionarxEstudiante(int EstudianteId)
        {
            List<Direccion> lst = new List<Direccion>();

            using (conexion = new SqlConnection(cadena))
            {
                conexion.Open();

                using (comando = new SqlCommand("DireccionSelectByEstudianteId", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@EstudianteId", EstudianteId);
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Direccion direccion = new Direccion
                        {
                            Pais = Convert.ToString(lector["Pais"]),
                            Estado = Convert.ToString(lector["Estado"]),
                            Ciudad = Convert.ToString(lector["Ciudad"]),
                            Barrio = Convert.ToString(lector["Barrio"]),
                            Calle = Convert.ToString(lector["Calle"]),
                            CasaApto = Convert.ToString(lector["CasaApto"]),
                            DireccionId = Convert.ToInt32(lector["DireccionId"]),
                            EstudianteId = Convert.ToInt32(lector["EstudianteId"])
                        };
                        lst.Add(direccion);
                    }
                }
            }
            return lst;
        }

        public int Insertar(Direccion direccion)
        {
            using (conexion = new SqlConnection(cadena))
            {
                using (comando = new SqlCommand("DireccionInsert", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Pais", direccion.Pais);
                    comando.Parameters.AddWithValue("@Estado", direccion.Estado);
                    comando.Parameters.AddWithValue("@Ciudad", direccion.Ciudad);
                    comando.Parameters.AddWithValue("@Barrio", direccion.Barrio);
                    comando.Parameters.AddWithValue("@Calle", direccion.Calle);
                    comando.Parameters.AddWithValue("@CasaApto", direccion.CasaApto);
                    comando.Parameters.AddWithValue("@EstudianteId", direccion.EstudianteId);

                    conexion.Open();
                    result = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return result;
        }

        public int Actualizar(Direccion direccion)
        {
            using (conexion = new SqlConnection(cadena))
            {
                using (comando = new SqlCommand("DireccionUpdate", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Pais", direccion.Pais);
                    comando.Parameters.AddWithValue("@Estado", direccion.Estado);
                    comando.Parameters.AddWithValue("@Ciudad", direccion.Ciudad);
                    comando.Parameters.AddWithValue("@Barrio", direccion.Barrio);
                    comando.Parameters.AddWithValue("@Calle", direccion.Calle);
                    comando.Parameters.AddWithValue("@CasaApto", direccion.CasaApto);
                    comando.Parameters.AddWithValue("@DireccionId", direccion.DireccionId);
                    comando.Parameters.AddWithValue("@EstudianteId", direccion.EstudianteId);

                    conexion.Open();
                    result = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return result;
        }

        public int Eliminar(Direccion direccion)
        {
            using (conexion = new SqlConnection(cadena))
            {
                using (comando = new SqlCommand("DireccionDelete", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@DireccionId", direccion.DireccionId);
                    
                    conexion.Open();
                    result = comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            return result;
        }

    }
}
