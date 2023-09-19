using ComponentesAPIADONET.Data;
using ComponentesAPIADONET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace ComponentesAPIADONET.Repositorios
{
    public class ComponenteRepositorio : IComponenteRepositorio
    {
        private readonly IConfiguration _configuration;

        private readonly SqlConnection conexion;

        public ComponenteRepositorio(ADOContext context)
        {
            conexion = context.GetConnection();
        }



        public IEnumerable<Componente> GetComponentes()
        {
            List<Componente> componenteList = new List<Componente>();


            string sql = "Select * From Componente";


            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Componente componente = new Componente();
                    componente.Id = Convert.ToInt32(dataReader["Id"]);
                    componente.Descripcion = Convert.ToString(dataReader["Descripcion"]);
                    componente.NumeroSerie = Convert.ToString(dataReader["NumeroSerie"]);
                    componente.Precio = Convert.ToDouble(dataReader["Precio"]);
                    componente.Cores = Convert.ToInt32(dataReader["Cores"]);
                    componente.Grados = Convert.ToInt32(dataReader["Grados"]);
                    componente.Almacenamiento = Convert.ToString(dataReader["Almacenamiento"]);
                    componente.TipoComponente = Convert.ToInt32(dataReader["TipoComponente"]);
                    componente.OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]);

                    componenteList.Add(componente);
                }
            }

            conexion.Close();

            return componenteList;
        }

        public Componente GetComponenteById(int id)
        {
            Componente componente = new Componente();




            string sql = $"Select * From Componente WHERE Id = @Id";


            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    componente = new Componente();
                    componente.Id = Convert.ToInt32(dataReader["Id"]);
                    componente.Descripcion = Convert.ToString(dataReader["Descripcion"]);
                    componente.NumeroSerie = Convert.ToString(dataReader["NumeroSerie"]);
                    componente.Precio = Convert.ToDouble(dataReader["Precio"]);
                    componente.Cores = Convert.ToInt32(dataReader["Cores"]);
                    componente.Grados = Convert.ToInt32(dataReader["Grados"]);
                    componente.Almacenamiento = Convert.ToString(dataReader["Almacenamiento"]);
                    componente.TipoComponente = Convert.ToInt32(dataReader["TipoComponente"]);
                    componente.OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]);


                }
            }

            conexion.Close();

            return componente;
        }

        public void Create(Componente c)
        {

            string sql = $"Insert Into Componente (Descripcion, NumeroSerie, Precio, Cores, Grados, Almacenamiento, TipoComponente, OrdenadorId) Values ('{c.Descripcion}', '{c.NumeroSerie}','{c.Precio}','{c.Cores}','{c.Grados}','{c.Almacenamiento}','{c.TipoComponente}','{c.OrdenadorId}')";

            using (SqlCommand command = new SqlCommand(sql, conexion))
            {
                command.CommandType = (System.Data.CommandType)CommandType.Text;

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }

        public void Update(int id, Componente c)
        {




            string selectSql = $"SELECT * FROM Componente WHERE Id = @Id";
            conexion.Open();
            using (SqlCommand selectCommand = new SqlCommand(selectSql, conexion))
            {
                selectCommand.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        throw new InvalidOperationException("El componente con el ID especificado no existe.");
                    }
                }
            }


            string updateSql = "UPDATE Componente SET ";

            if (!string.IsNullOrEmpty(c.Descripcion))
            {
                updateSql += "Descripcion = @Descripcion, ";
            }

            if (!string.IsNullOrEmpty(c.NumeroSerie))
            {
                updateSql += "NumeroSerie = @NumeroSerie, ";
            }

            if (c.Precio != 0)
            {
                updateSql += "Precio = @Precio, ";
            }

            if (c.Cores != 0)
            {
                updateSql += "Cores = @Cores, ";
            }

            if (c.Grados != 0)
            {
                updateSql += "Grados = @Grados, ";
            }

            if (!string.IsNullOrEmpty(c.Almacenamiento))
            {
                updateSql += "Almacenamiento = @Almacenamiento, ";
            }

            if (c.TipoComponente != 0)
            {
                updateSql += "TipoComponente = @TipoComponente, ";
            }

            if (c.OrdenadorId != 0)
            {
                updateSql += "OrdenadorId = @OrdenadorId, ";
            }


            if (updateSql.EndsWith(", "))
            {
                updateSql = updateSql.Substring(0, updateSql.Length - 2);
            }

            updateSql += " WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(updateSql, conexion))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                if (!string.IsNullOrEmpty(c.Descripcion))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", c.Descripcion);
                }

                if (!string.IsNullOrEmpty(c.NumeroSerie))
                {
                    cmd.Parameters.AddWithValue("@NumeroSerie", c.NumeroSerie);
                }

                if (c.Precio != 0)
                {
                    cmd.Parameters.AddWithValue("@Precio", c.Precio);
                }

                if (c.Cores != 0)
                {
                    cmd.Parameters.AddWithValue("@Cores", c.Cores);
                }

                if (c.Grados != 0)
                {
                    cmd.Parameters.AddWithValue("@Grados", c.Grados);
                }

                if (!string.IsNullOrEmpty(c.Almacenamiento))
                {
                    cmd.Parameters.AddWithValue("@Almacenamiento", c.Almacenamiento);
                }

                if (c.TipoComponente != 0)
                {
                    cmd.Parameters.AddWithValue("@TipoComponente", c.TipoComponente);
                }

                if (c.OrdenadorId != 0)
                {
                    cmd.Parameters.AddWithValue("@OrdenadorId", c.OrdenadorId);
                }

                cmd.ExecuteNonQuery();
            }

        }


        public void Delete(int id)
        {

            string sql = $"Delete From Componente Where Id='{id}'";
            using (SqlCommand command = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }

        }

    }
}


