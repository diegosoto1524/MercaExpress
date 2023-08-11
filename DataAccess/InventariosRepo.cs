using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Entities;
using Microsoft.Data.SqlClient;
using DataAccess.Interfaces;
using DataAcces;

namespace DataAccess
{
    public class InventariosRepo : IInventariosRepo
    {

        IProductRepo productRepo;
        IBaseRepo baseRepo;
        public InventariosRepo(IBaseRepo baseRepo, IProductRepo productRepo)
        {
            this.baseRepo = baseRepo;   
            this.productRepo = productRepo;
        }

        public List<double> AgregarAInventarioBodega(List<int> listadoProductos, List<double> listadoCantidades)
        {
            List<double> listaNuevasCantidades = new List<double>();

            for (int i = 0; i < listadoProductos.Count; i++)
            {
                int idActual = listadoProductos[i];
                if (productRepo.CheckIfProductExists(idActual))
                {
                    int CantActualEnBodega = GetInventarioBodegaById(idActual);
                    string sqlQuery = @"update [dbo].[Productos] set CantidadEnBodega=@CantidadEnBodega where Id=@Id";
                    double cantidadEnBodegaNueva = listadoCantidades[i] + CantActualEnBodega;
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter("@CantidadEnBodega", cantidadEnBodegaNueva));
                    sqlParameters.Add(new SqlParameter("@Id", idActual));
                    baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);
                    listaNuevasCantidades.Add(cantidadEnBodegaNueva);

                }
                else
                {
                    throw new InvalidOperationException($"Verify, the product with Id: {idActual} does not exist");
                }
            }
            return listaNuevasCantidades;
        }

        public int GetInventarioBodegaById(int id)
        {
            int cantidadEnBodegaActual = 0;
            string sqlQuery = $"select CantidadEnBodega from [dbo].[Productos] where Id={id}";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    object result = sqlDataReader.GetValue(0);
                    if (result != null && result != DBNull.Value)
                    {
                        cantidadEnBodegaActual = Convert.ToInt32(result);
                    }
                }
            }            
            return cantidadEnBodegaActual;
        }

        public List<int> AgregarAInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades)
        {
            List<int> listaNuevoInventario = new List<int>();
            for (int i = 0; i < listadoProductos.Count; i++)
            {
                int idActual = listadoProductos[i];
                if (productRepo.CheckIfProductExists(idActual))
                {
                    int invActual = GetInventarioExhibicionById(idActual);
                    string sqlQuery = "update [dbo].[Productos] set CantidadEnExhibicion=@CantidadEnExhibicion where Id = @Id";
                    int cantidadNueva = invActual + listadoCantidades[i];
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter("@Id", idActual));
                    sqlParameters.Add(new SqlParameter("@CantidadEnExhibicion", cantidadNueva));
                    baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);
                    listaNuevoInventario.Add(cantidadNueva);                    
                }
                else
                {
                    throw new InvalidOperationException($"Verify, the product with Id: {idActual} does not exist");
                }
            }

            return listaNuevoInventario;
        }

        public int GetInventarioExhibicionById(int id)
        {
            int cantidadEnExhibicion = 0;
            string sqlQuery = $"select CantidadEnExhibicion from [dbo].[Productos] where Id={id}";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    object result = sqlDataReader.GetValue(0);
                    if (result != null && result != DBNull.Value)
                    {
                        cantidadEnExhibicion = Convert.ToInt32(result);
                    }
                }
            }
            return cantidadEnExhibicion;
        }

        public List<int> SacarDeInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades)
        {
            List<int> listaNuevoInventarioExhibicion = new List<int>();
            for (int i = 0; i < listadoProductos.Count; i++)
            {
                int idActual = listadoProductos[i];
                if (productRepo.CheckIfProductExists(idActual))
                {
                    int invActual = GetInventarioExhibicionById(idActual);
                    string sqlQuery = "update [dbo].[Productos] set CantidadEnExhibicion=@CantidadEnExhibicion where Id=@Id";
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    int invNuevo = invActual - listadoCantidades[i];
                    sqlParameters.Add(new SqlParameter("@CantidadEnExhibicion", invNuevo));
                    sqlParameters.Add(new SqlParameter("@Id", idActual));
                    baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);
                    listaNuevoInventarioExhibicion.Add(invNuevo);
                }
                else
                {
                    throw new InvalidOperationException($"Product with id: {idActual} does not exist");
                }
            }
            return listaNuevoInventarioExhibicion;
        }

        public List<double> SacarDeInvetarioBodega(List<ProductQuantity> productQuantity)
        {
            List<double> listaNuevasCantidades = new List<double>();
            for (int i = 0; i < productQuantity.Count; i++)
            {
                int idActual = productQuantity[i].Product.Id;
                if (productRepo.CheckIfProductExists(idActual))
                {
                    int inventarioActual = GetInventarioBodegaById(idActual);
                    string sqlQuery = $"update [dbo].[Productos] set CantidadEnBodega = @CantidadEnBodega where Id=@Id";
                    double cantidadNueva = inventarioActual - productQuantity[i].Quantity;
                    List<SqlParameter> sqlParameters = new List<SqlParameter>();
                    sqlParameters.Add(new SqlParameter("@CantidadEnBodega", cantidadNueva));
                    sqlParameters.Add(new SqlParameter("@Id", idActual));
                    baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);
                    listaNuevasCantidades.Add(cantidadNueva);
                }
                else
                {
                    throw new InvalidOperationException($"Verify, the product with Id: {idActual} does not exist");
                }
            }
            return listaNuevasCantidades;

        }
    }
}
