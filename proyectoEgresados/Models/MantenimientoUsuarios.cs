using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace proyectoEgresados.Models
{
    public class MantenimientoUsuarios
    {
        private SqlConnection con;
        private void conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(Usuarios usu)//Crea los elementos
        {
            conectar();
            SqlCommand comando = new SqlCommand("insert into ESUsuarios (usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro)values(@usu_id,@usu_documento,@usu_tipodoc,@usu_nombre,@usu_celular,@usu_email,@usu_genero,@usu_aprendiz,@usu_egresado,@usu_areaformacion,@usu_fechaegresado,@usu_direccion,@usu_barrio,@usu_ciudad,@usu_departamento,@usu_fecharegistro)", con);

            //es para especificar que tipo de dato es.
            comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters.Add("@usu_documento", SqlDbType.Int);
            comando.Parameters.Add("@usu_tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_celular", SqlDbType.Int);
            comando.Parameters.Add("@usu_email", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_genero", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_aprendiz", SqlDbType.Bit);
            comando.Parameters.Add("@usu_egresado", SqlDbType.Bit);
            comando.Parameters.Add("@usu_areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@usu_direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_barrio ", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_ciudad ", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@usu_fecharegistro", SqlDbType.Date);

            //lee y modifica los datos.
           
            comando.Parameters["@usu_id"].Value = usu.Id;
            comando.Parameters["@usu_documento"].Value= usu.Documento;
            comando.Parameters["@usu_tipodoc"].Value=usu.Tipodoc;
            comando.Parameters["@usu_nombre"].Value=usu.Nombre;
            comando.Parameters["@usu_celular"].Value=usu.Celular;
            comando.Parameters["@usu_email"].Value=usu.Email;
            comando.Parameters["@usu_genero"].Value=usu.Genero;
            comando.Parameters["@usu_aprendiz"].Value=usu.Aprendiz;
            comando.Parameters["@usu_egresado"].Value=usu.Egresado;
            comando.Parameters["@usu_areaformacion"].Value=usu.Areaformacion;
            comando.Parameters["@usu_fechaegresado"].Value=usu.Fechaegresado;
            comando.Parameters["@usu_direccion"].Value=usu.Fecharegistro;
            comando.Parameters["@usu_barrio "].Value=usu.Barrio;
            comando.Parameters["@usu_ciudad "].Value=usu.Ciudad;
            comando.Parameters["@usu_departamento"].Value=usu.Departamento;
            comando.Parameters["@usu_fecharegistro"].Value=usu.Fecharegistro;

            con.Open();//abre la conexion
            int i = comando.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            con.Close();//cierra la conexion
            return i;//retorna cuantas filas se afectaron 

        }
        public List<Usuarios> RecuperarTodos()//nos trae lo que estan en la base de datos.
        {
            conectar();//abre la conexion.
            List<Usuarios> usu = new List<Usuarios>();
            SqlCommand com = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro  from ESUsuarios order by usu_documento, asc", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())//muestra los registros por linea, uno por uno.
            {
                Usuarios dat = new Usuarios
                {
                    Id = int.Parse(registros["usu_id"].ToString()),
                    Documento = int.Parse(registros["usu_documento"].ToString()),
                    Tipodoc = registros["usu_tipodoc"].ToString(),
                    Nombre = registros["usu_nombre"].ToString(),
                    Celular = int.Parse(registros["usu_celular"].ToString()),
                    Email = registros["usu_email"].ToString(),
                    Genero = registros["usu_genero"].ToString(),
                    Aprendiz = bool.Parse( registros["usu_aprendiz"].ToString()),
                    Egresado = bool.Parse( registros["usu_egresado"].ToString()),
                    Areaformacion = registros["usu_areaformacion"].ToString(),
                    Fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString()),
                    Direccion = registros["usu_direccion"].ToString(),
                    Barrio = registros["usu_barrio"].ToString(),
                    Ciudad = registros["usu_ciudad"].ToString(),
                    Departamento = registros["usu_departamento"].ToString(),
                    Fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString())
                    
                };
                usu.Add(dat);


            }
            con.Close();
            return usu;
        }



    }
}