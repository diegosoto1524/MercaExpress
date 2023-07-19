using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Entities;
using Microsoft.Data.SqlClient;
using DataAccess.Interfaces;


namespace DataAccess
{
    public class InventariosRepo : IInventariosRepo
    {
        private readonly SqlConnection connection;
        public InventariosRepo(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public List<int> AgregarInventarioBodega(List<Product> listadoProductos, List<int> listadoCantidades)
        {
            List <int> listaNuevasCantidades = new List<int>();
            for (int i= 0; i < listadoProductos.Count; i++)
            {
                Product product = listadoProductos[i];
                if (CheckIfProductExists(product.Id))
                {
                    int CantActualEnBodega = GetCantidadEnBodega(product.Id);
                    string sqlQuery = @"update [dbo].[Productos] set CantidadEnBodega=@CantidadEnBodega where Id=@Id";
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
                    {
                        int cantidadEnBodegaNueva = listadoCantidades[i] + CantActualEnBodega;
                        sqlCommand.Parameters.AddWithValue("@CantidadEnBodega", cantidadEnBodegaNueva);
                        sqlCommand.Parameters.AddWithValue("@Id", product.Id);
                        sqlCommand.ExecuteNonQuery();
                        listaNuevasCantidades.Add(cantidadEnBodegaNueva);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Verify, the product with Id: {product.Id} does not exist");
                }
            }
            return listaNuevasCantidades;
        }
        private bool CheckIfProductExists(int id)  //REVISAR PARA DEJAR UN SOLO METODO
        {
            string sqlQuery = @"SELECT COUNT(*) FROM [dbo].[Productos] WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }

        }

        private int GetCantidadEnBodega(int id)
        {
            int cantidadEnBodegaActual=0;
            string sqlQuery = $"select CantidadEnBodega from [dbo].[Productos] where Id={id}";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                object result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    cantidadEnBodegaActual = Convert.ToInt32(result);                 
                }
            }
            return cantidadEnBodegaActual;
        }

        public bool AgregarInventarioExhibicion(List<Product> listadoProductos, List<int> listadoCantidades)
        {
            throw new NotImplementedException();
        }

        public bool SacarDeInventarioExhibicion(List<Product> listadoProductos, List<int> listadoCantidades)
        {
            throw new NotImplementedException();
        }

        public bool SacarDeInvetarioBodega(List<Product> listadoProductos, List<int> listadoCantidades)
        {
            throw new NotImplementedException();
        }
    }
}
