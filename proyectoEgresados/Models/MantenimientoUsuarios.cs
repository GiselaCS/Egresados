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
            // SqlCommand comando = new SqlCommand("insert into ESUsuarios (usu_documento, usu_tipodoc, usu_nombre, usu_celular, usu_email, usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro) values(@usu_documento,@usu_tipodoc,@usu_nombre,@usu_celular,@usu_email,@usu_genero,@usu_aprendiz,@usu_egresado,@usu_areaformacion,@usu_fechaegresado,@usu_direccion,@usu_barrio,@usu_ciudad,@usu_departamento,@usu_fecharegistro)", con);
             SqlCommand comando = new SqlCommand("insert into ESUsuarios (usu_documento, usu_tipodoc, usu_nombre, usu_celular, usu_email, usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro) values(@documento,@tipodoc,@nombre,@celular,@email,@genero,@aprendiz,@egresado,@areaformacion,@fechaegresado,@direccion,@barrio,@ciudad,@departamento,@fecharegistro)", con);

            //es para especificar que tipo de dato es.
            //comando.Parameters.Add("@usu_id", SqlDbType.Int);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio ", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad ", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);

            //lee y modifica los datos.

            //comando.Parameters["@usu_id"].Value = usu.Id;
            comando.Parameters["@documento"].Value = usu.Documento;
            comando.Parameters["@tipodoc"].Value = usu.Tipodoc;
            comando.Parameters["@nombre"].Value = usu.Nombre;
            comando.Parameters["@celular"].Value = usu.Celular;
            comando.Parameters["@email"].Value = usu.Email;
            comando.Parameters["@genero"].Value = usu.Genero;
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;
            comando.Parameters["@egresado"].Value = usu.Egresado;
            comando.Parameters["@areaformacion"].Value = usu.Areaformacion;
            comando.Parameters["@fechaegresado"].Value = usu.Fechaegresado;
            comando.Parameters["@direccion"].Value = usu.Direccion;
            comando.Parameters["@barrio "].Value = usu.Barrio;
            comando.Parameters["@ciudad "].Value = usu.Ciudad;
            comando.Parameters["@departamento"].Value = usu.Departamento;
            comando.Parameters["@fecharegistro"].Value = usu.Fecharegistro;

            con.Open();//abre la conexion
            int i = comando.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            con.Close();//cierra la conexion
            return i;//retorna cuantas filas se afectaron 

        }
        public List<Usuarios> RecuperarTodos()//nos trae lo que estan en la base de datos.
        {
            conectar();//abre la conexion.
            List<Usuarios> usu = new List<Usuarios>();
            SqlCommand com = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro  from ESUsuarios order by usu_id asc", con);

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
                    Aprendiz = registros["usu_aprendiz"].ToString(),
                    Egresado = registros["usu_egresado"].ToString(),
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

        public Usuarios Recuperardoc(int id)
        {
            conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro  from ESUsuarios where usu_id=@id", con);//consulta en la base de datos.
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            Usuarios usu = new Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.

                usu.Id = Convert.ToInt32(registros["usu_id"]);
                usu.Documento = Convert.ToInt32(registros["usu_documento"]);
                usu.Tipodoc = registros["usu_tipodoc"].ToString();
                usu.Nombre = registros["usu_nombre"].ToString();
                usu.Celular = Convert.ToInt32(registros["usu_celular"]);
                usu.Email = registros["usu_email"].ToString();
                usu.Genero = registros["usu_genero"].ToString();
                usu.Aprendiz = registros["usu_aprendiz"].ToString();
                usu.Egresado = registros["usu_egresado"].ToString();
                usu.Areaformacion = registros["usu_areaformacion"].ToString();
                usu.Fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usu.Direccion = registros["usu_direccion"].ToString();
                usu.Barrio = registros["usu_barrio"].ToString();
                usu.Ciudad = registros["usu_ciudad"].ToString();
                usu.Departamento = registros["usu_departamento"].ToString();
                usu.Fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString());
                
            }
            else
                usu = null;

            con.Close();
            return usu;
        }
        public Usuarios Recuperararea(string Area)
        {
            conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro  from ESUsuarios where usu_areaformacion=@areaformacion", con);//consulta en la base de datos.
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = Area;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            Usuarios usu = new Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.

                usu.Id = int.Parse(registros["usu_id"].ToString());
                usu.Documento = int.Parse(registros["usu_documento"].ToString());
                usu.Tipodoc = registros["usu_tipodoc"].ToString();
                usu.Nombre = registros["usu_nombre"].ToString();
                usu.Celular = int.Parse(registros["usu_celular"].ToString());
                usu.Email = registros["usu_email"].ToString();
                usu.Genero = registros["usu_genero"].ToString();
                usu.Aprendiz = registros["usu_aprendiz"].ToString();
                usu.Egresado = registros["usu_egresado"].ToString();
                usu.Areaformacion = registros["usu_areaformacion"].ToString();
                usu.Fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usu.Direccion = registros["usu_direccion"].ToString();
                usu.Barrio = registros["usu_barrio"].ToString();
                usu.Ciudad = registros["usu_ciudad"].ToString();
                usu.Departamento = registros["usu_departamento"].ToString();
                usu.Fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString());
            }
            else
                usu = null;

            con.Close();
            return usu;
        }
        public Usuarios Recuperargen(string genero)
        {
            conectar();
            SqlCommand comando = new SqlCommand("select usu_id,usu_documento,usu_tipodoc,usu_nombre,usu_celular,usu_email,usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro  from ESUsuarios where usu_genero=@genero", con);//consulta en la base de datos.
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = genero;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();//trae cuantas lineas se guardo o afecto y ejecuta la sentencia.
            Usuarios usu = new Usuarios();

            if (registros.Read())
            {
                //trae la informacion de la base de datos para pasarla al controlador y despues el controlador los envia a la vista.

                usu.Id = int.Parse(registros["usu_id"].ToString());
                usu.Documento = int.Parse(registros["usu_documento"].ToString());
                usu.Tipodoc = registros["usu_tipodoc"].ToString();
                usu.Nombre = registros["usu_nombre"].ToString();
                usu.Celular = int.Parse(registros["usu_celular"].ToString());
                usu.Email = registros["usu_email"].ToString();
                usu.Genero = registros["usu_genero"].ToString();
                usu.Aprendiz = registros["usu_aprendiz"].ToString();
                usu.Egresado = registros["usu_egresado"].ToString();
                usu.Areaformacion = registros["usu_areaformacion"].ToString();
                usu.Fechaegresado = DateTime.Parse(registros["usu_fechaegresado"].ToString());
                usu.Direccion = registros["usu_direccion"].ToString();
                usu.Barrio = registros["usu_barrio"].ToString();
                usu.Ciudad = registros["usu_ciudad"].ToString();
                usu.Departamento = registros["usu_departamento"].ToString();
                usu.Fecharegistro = DateTime.Parse(registros["usu_fecharegistro"].ToString());
            }
            else
                usu = null;

            con.Close();
            return usu;
        }
        public int Modificar(Usuarios usu)
        {
            conectar();
            SqlCommand comando = new SqlCommand("update ESUsuarios set usu_tipodoc=@tipodoc,usu_nombre=@nombre,usu_celular=@celular,usu_email=@email,usu_genero=@genero,usu_aprendiz=@aprendiz,usu_egresado=@egresado,usu_areaformacion=@areaformacion,usu_fechaegresado=@fechaegresado,usu_direccion=@direccion,usu_barrio=@barrio,usu_ciudad=@ciudad,usu_departamento=@departamento,usu_fecharegistro=@fecharegistro  where usu_id=@id", con);

            //Muestra la informacion

            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.Tipodoc;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.Nombre;

            comando.Parameters.Add("@celular", SqlDbType.Int);
            comando.Parameters["@celular"].Value = usu.Celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.Email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.Genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.VarChar);
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;

            comando.Parameters.Add("@egresado", SqlDbType.VarChar);
            comando.Parameters["@egresado"].Value = usu.Egresado;

            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.Areaformacion;

            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters["@fechaegresado"].Value = usu.Fechaegresado;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.Direccion;

            comando.Parameters.Add("@barrio ", SqlDbType.VarChar);
            comando.Parameters["@barrio "].Value = usu.Barrio;

            comando.Parameters.Add("@ciudad ", SqlDbType.VarChar);
            comando.Parameters["@ciudad "].Value = usu.Ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.Departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);
            comando.Parameters["@fecharegistro"].Value = usu.Fecharegistro;

            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = usu.Documento;

            //comando.Parameters.Add("@id", SqlDbType.Int);
            //comando.Parameters["@id"].Value = usu.Documento;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int Documento)
        {
            conectar();
            SqlCommand comando = new SqlCommand("delete from ESUsuarios where usu_documento=@documento", con);
            comando.Parameters.Add("@documento", SqlDbType.Int);
            comando.Parameters["@documento"].Value = Documento;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;



        }
    }
}