using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 
namespace Proyecto_Final
{
    public class Consultar
    {

        public static Usuario TraerUsuario(string nombreUsuario)
        {
            string connectionString = "Server= DESKTOP-N741CHP ; Database = SistemaGestion; Trusted_Connection = True;";
            var usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                var comando = new SqlCommand("Select * From Usuario Where NombreUsuario = '" + nombreUsuario + "'", connection);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    usuario._nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                    usuario._apellido = dr.GetString(dr.GetOrdinal("Apellido"));
                    usuario._nombreDeUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario"));
                    usuario._contraseña = dr.GetString(dr.GetOrdinal("Contraseña"));
                    usuario._mail = dr.GetString(dr.GetOrdinal("Mail"));


                }
                connection.Close();
            }
            return usuario; 
    }

        public static List<Producto> TraerProductos(int idusuario)
        {
            string connectionString = "Server= DESKTOP-N741CHP ; Database = SistemaGestion; Trusted_Connection = True;";
            var listaproductos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comando = new SqlCommand("Select * From Producto Where IdUsuario = '" + idusuario + "'", connection);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        var producto = new Producto();
                        producto._id = Convert.ToInt32(dr["Id"]);
                        producto._descripcion = dr["Descripciones"].ToString();
                        producto._costo = Convert.ToInt32(dr["Costo"]);
                        producto._precioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                        producto._stock = Convert.ToInt32(dr["Stock"]);
                        producto._idUsuario = Convert.ToInt32(dr["IdUsuario"]);

                        listaproductos.Add(producto);


                    }

                }
            }

            return listaproductos; 
        }
    
        public static List<Producto> TraerProductosVendidos(int idusuario)
        {
            string connectionString = "Server= DESKTOP-N741CHP ; Database = SistemaGestion; Trusted_Connection = True;";
            var listaproductos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comando = new SqlCommand("Select p.Descripciones , p.PrecioVenta , p.Stock , p.IdUsuario From Producto as p inner join Usuario as u  on u.id = p.IdUsuario inner join ProductoVendido as pv on p.id = pv.IdProducto  Where IdUsuario = '" + idusuario + "'", connection);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var producto = new Producto(); 
                        producto._descripcion = dr["Descripciones"].ToString();
                        producto._precioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                        producto._stock = Convert.ToInt32(dr["Stock"]);
                        producto._idUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        listaproductos.Add(producto);
                    }
                }
                connection.Close();

            }

            return listaproductos; 
        }

        public static List<Producto> TraerVentas(int idusuario)
        {
            string connectionString = "Server= DESKTOP-N741CHP ; Database = SistemaGestion; Trusted_Connection = True;";
            var listaproductos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comando = new SqlCommand("Select p.Descripciones , p.PrecioVenta , p.Stock , p.IdUsuario  From Producto as p inner join Usuario as u on u.id = p.IdUsuario inner join Venta as v on v.IdProducto = p.Id  Where IdUsuario = '" + idusuario + "'", connection);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var producto = new Producto();
                        producto._descripcion = dr["Descripciones"].ToString();
                        producto._precioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                        producto._stock = Convert.ToInt32(dr["Stock"]);
                        producto._idUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        listaproductos.Add(producto);

                    }
                }
                connection.Close();
            }
            return listaproductos; 



        }

        public static Usuario Login(string nombreUsuario , string contraseña)
        {
            string connectionString = "Server= DESKTOP-N741CHP ; Database = SistemaGestion; Trusted_Connection = True;";
            var usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var comando = new SqlCommand("Select * From Usuario Where NombreUsuario = '" + nombreUsuario + "' and Contraseña = '"+contraseña+"'", connection);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        usuario._nombre = dr.GetString(dr.GetOrdinal("Nombre"));
                        usuario._apellido = dr.GetString(dr.GetOrdinal("Apellido"));
                        usuario._nombreDeUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario"));
                        usuario._contraseña = dr.GetString(dr.GetOrdinal("Contraseña"));
                        usuario._mail = dr.GetString(dr.GetOrdinal("Mail"));

                    }
                    return usuario; 
                }
                else
                {
                    return usuario; 

                }
            }



        }

    }





}