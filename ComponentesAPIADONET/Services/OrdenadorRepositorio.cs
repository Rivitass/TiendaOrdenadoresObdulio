using ComponentesAPIADONET.Data;
using ComponentesAPIADONET.Models;
using System.Data;
using System.Data.SqlClient;

namespace ComponentesAPIADONET.Repositorios
{
    public class OrdenadorRepositorio : IOrdenadorRepositorio
    {
        private readonly IConfiguration _configuration;

        private readonly SqlConnection conexion;

        public OrdenadorRepositorio(ADOContext context)
        {
            conexion = context.GetConnection();
        }

        public void Create(Ordenador c)
        {

            string sql = $"Insert Into Ordenadores (DescripcionOrdenador) Values ('{c.DescripcionOrdenador}')";

            using (SqlCommand command = new SqlCommand(sql, conexion))
            {
                command.CommandType = (System.Data.CommandType)CommandType.Text;

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }

        public void Delete(int id)
        {

            string sql = $"Delete From Ordenadores Where IdOrdenador='{id}'";
            using (SqlCommand command = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }

        public List<OrdenadorComponente> GetComponentes(int id)
        {
            List<OrdenadorComponente> resultadoList = new List<OrdenadorComponente>();



            string sql = @"
        SELECT Ordenadores.IdOrdenador AS OrdenadorId, Ordenadores.DescripcionOrdenador AS OrdenadorDescripcion,
        Componente.Id AS ComponenteId, Componente.Descripcion AS ComponenteDescripcion,
        Componente.NumeroSerie, Componente.Precio, Componente.Cores, Componente.Grados,
        Componente.Almacenamiento, Componente.TipoComponente
        FROM Ordenadores
        INNER JOIN Componente ON Componente.OrdenadorId = Ordenadores.IdOrdenador
        WHERE Componente.OrdenadorId = @Id";

            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Ordenador ordenador = new Ordenador();
                    ordenador.IdOrdenador = Convert.ToInt32(dataReader["OrdenadorId"]);
                    ordenador.DescripcionOrdenador = Convert.ToString(dataReader["OrdenadorDescripcion"]);

                    Componente componente = new Componente();
                    componente.Id = Convert.ToInt32(dataReader["ComponenteId"]);
                    componente.Descripcion = Convert.ToString(dataReader["ComponenteDescripcion"]);
                    componente.NumeroSerie = Convert.ToString(dataReader["NumeroSerie"]);
                    componente.Precio = Convert.ToDouble(dataReader["Precio"]);
                    componente.Cores = Convert.ToInt32(dataReader["Cores"]);
                    componente.Grados = Convert.ToInt32(dataReader["Grados"]);
                    componente.Almacenamiento = Convert.ToString(dataReader["Almacenamiento"]);
                    componente.TipoComponente = Convert.ToInt32(dataReader["TipoComponente"]);
                    componente.OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]);

                    OrdenadorComponente ordenadorComponente = new OrdenadorComponente();
                    ordenadorComponente.Ordenador = ordenador;
                    ordenadorComponente.Componente = componente;

                    resultadoList.Add(ordenadorComponente);
                }
            }

            conexion.Close();


            return resultadoList;
        }


        public IEnumerable<Ordenador> GetOrdenador()
        {
            List<Ordenador> ordenadorList = new();




            string sql = "Select * From Ordenadores";

            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Ordenador ordenador = new Ordenador();
                    ordenador.IdOrdenador = Convert.ToInt32(dataReader["IdOrdenador"]);
                    ordenador.DescripcionOrdenador = Convert.ToString(dataReader["DescripcionOrdenador"]);

                    ordenadorList.Add(ordenador);
                }
            }

            conexion.Close();

            return ordenadorList;
        }

        public Ordenador GetOrdenadorById(int id)
        {
            Ordenador ordenador = new Ordenador();




            string sql = $"Select * From Ordenadores WHERE IdOrdenador = @Id";


            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    ordenador = new Ordenador();
                    ordenador.IdOrdenador = Convert.ToInt32(dataReader["IdOrdenador"]);
                    ordenador.DescripcionOrdenador = Convert.ToString(dataReader["DescripcionOrdenador"]);

                }
            }

            conexion.Close();

            return ordenador;
        }

        public void Update(int id, Ordenador c)
        {




            string selectSql = $"SELECT * FROM Ordenadores WHERE IdOrdenador = '{id}'";
            conexion.Open();
            using (SqlCommand selectCommand = new SqlCommand(selectSql, conexion))
            {
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (!reader.Read())
                    {


                    }
                }
            }


            string updateSql = $"UPDATE Ordenadores SET DescripcionOrdenador='{c.DescripcionOrdenador}' WHERE IdOrdenador='{id}'";
            using (SqlCommand command = new SqlCommand(updateSql, conexion))
            {
                command.ExecuteNonQuery();
            }

            conexion.Close();



        }
    }
}

