using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    class ClsConexion
    {
        SqlConnection con = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True");
        public void Opendb()
        {
            try
            {
                con.Open();
               MessageBox.Show("Conexion Exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la conexion"+e.ToString());
            }
        }
        public void Closedb()
        {
            try
            {
                con.Close();
                Console.Write("ConexionDB exitosa");
            }
            catch (Exception e)
            {
                Console.Write("Error en la conexion");
            }
        }
        public Boolean loggin(string usuario,string contrasena)
        {
            Boolean request = false;
            try
            {
                con.Open();
                //Comando SQL que va a buscar a la BD 
                string query = "SELECT * FROM Usuario WHERE Correo=@correo and Clave=@clave";
                SqlCommand cmd = new SqlCommand(query, con);
                //Agregamos parámetros a nuestro comando para usuario y contraseña
                cmd.Parameters.AddWithValue("@correo", usuario);
                cmd.Parameters.AddWithValue("@clave", contrasena);
                //Nuevo objeto de SQL data adapter
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                //Llenar el DataTable con datos
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Console.Write("Inicio de sesion Exitoso");
                    request = true;
                }
                else
                {
                    //MessageBox.Show("Usuario y/o Contraseña incorrecta");
                }
                con.Close();

            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return request;

        }
        //privilegio de acceso del usuario
        public int privilegioUsuario(string correo)
        {

            int cod = 0;
            try
            {
                con.Open();
                string sql = "SELECT * from  Usuario WHERE Correo=@correo";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cod = Convert.ToInt16(reader["idCargo"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
            return cod;
        }

        //insertar datos empleado
        public void InsertarEmpleado(string nombre, string apellido, string edad, string email, string telefono, string ocupacion)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Empleado (Nombre,Apellido,Edad,Email,Telefono,idOcupacion) values (@nombre,@apellido,@edad,@email,@telefono,@ocupacion)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@edad", edad);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@ocupacion", ocupacion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de empleado Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // cargar datagrid empleados
        public void loadEmpleados(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Empleado";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        // editar empleado
        private static string codEmpleado;

        public string CodEmpleado
        {
            get
            {
                return codEmpleado;
            }

            set
            {
                codEmpleado = value;
            }
        }

        
        public void EditarEmpleado(string nombre, string apellido, string edad, string email, string telefono, string ocupacion)
        {
            try
            {
                Opendb();

                string query = "UPDATE  Empleado SET Nombre = @nombre,Apellido=@apellido,Edad=@edad,Email=@email,Telefono=@telefono,idOcupacion=@ocupacion WHERE idEmpleado=@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@edad", edad);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@ocupacion", ocupacion);
                comando.Parameters.AddWithValue("@cod", codEmpleado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Edit de empleado Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador"+e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Eliminar Empleado
        public void EliminarEmpleado()
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Empleado WHERE idEmpleado = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", codEmpleado);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de empleado Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Eliminar Empleados
        public void EliminarEmpleados()
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Empleado";

                SqlCommand comando = new SqlCommand(query, con);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registros elminados, Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //////////////////////////USUARIOS//////////////////////////
    
        public int VerificarUsuario(string correo)
        {
            int request=0;
            try
            {
                con.Open();
                string query = "SELECT * FROM Empleado WHERE Email = @correo";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@correo", correo);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {

                    con.Close();
                    //
                    con.Open();
                    string query2 = "SELECT * FROM Usuario WHERE Correo = @correo";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@correo", correo);
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    if (dt2.Rows.Count == 1)
                    {
                        request = 2;
                    }
                    else
                    {
                        request = 3;
                    }
                    con.Close();
                    return request;
                }
                else
                {
                    request = 0;
                }
                con.Close();
                return request;


            }
            catch (Exception e)
            {
                Console.Write(e);
                return 0;
            }

        }
        //insertar datos USUARIO
        public void InsertarUsuario( string correo, string cargo, string clave)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Usuario (Correo,idCargo,Clave) values (@correo,@cargo,@clave)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@cargo", cargo);
                comando.Parameters.AddWithValue("@clave", clave);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de usuario Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Actualizar datos USUARIO
        private string codusuario;
        public string Codusuario
        {
            get
            {
                return codusuario;
            }

            set
            {
                codusuario = value;
            }
        }

        public void EditarUsuario( string correo, string cargo, string clave)
        {
            try
            {
                Opendb();

                string query = "UPDATE Usuario SET Correo=@correo,idCargo=@cargo,Clave=@clave WHERE Correo =@correo";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@cargo", cargo);
                comando.Parameters.AddWithValue("@clave", clave);
                comando.ExecuteNonQuery();
                MessageBox.Show("Update de usuario Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Eliminar Usuario
        public void EliminarUsuario(string correo)
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Usuario WHERE Correo = @correo";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de Usuario Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Eliminar Usuarios
        public void EliminarUsuarios()
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Usuarios";

                SqlCommand comando = new SqlCommand(query, con);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registros elminados, Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // cargar datagrid usuarios
        public void loadUsuarios(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Usuario";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        ////////////////////////categorias//////////////////////
        public void InsertarCategoria(string Descripcion)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Categoria (Descripcion) values (@desc)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@desc", Descripcion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de categoria Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Actualizar datos USUARIO
      
        public void EditarCategoria(string descripcion, string codigo)
        {
            try
            {
                Opendb();

                string query = "UPDATE Categoria SET Descripcion=@desc WHERE idCategoria =@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@desc", descripcion);
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Update de categoria Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ///
        }
        ///load categoria
        public void loadUCategoria(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Categoria";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        // Eliminar Usuario
        public void EliminarCategoria(string codigo)
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Categoria WHERE idCategoria = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de categoria Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        ////////////////////////Editoria//////////////////////
        public void InsertarEditorial(string nombre,string pais)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Editorial (Nombre,Pais) values (@nombre,@pais)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@pais", pais);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de editorial Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Actualizar datos editorial

        public void EditarEditorial(string nombre, string pais, string codigo)
        {
            try
            {
                Opendb();

                string query = "UPDATE Editorial SET Nombre=@nombre,Pais=@pais WHERE idEditorial =@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@pais", pais);
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Update de editorial Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ///
        }
        ///load editorial
        public void loadEditorial(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Editorial";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        // Eliminar editorial
        public void EliminarEditorial(string codigo)
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Editorial WHERE idEditorial = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de editorial Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        ////////////////////////Autor//////////////////////
        public void InsertarAutor(string nombre, string appellido, string pais)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Autor (Nombre,Apellido,Pais) values (@nombre,@apellido,@pais)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", appellido);
                comando.Parameters.AddWithValue("@pais", pais);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de autor Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Actualizar datos autor

        public void EditarAutor(string nombre, string appellido, string pais,string codigo)
        {
            try
            {
                Opendb();

                string query = "UPDATE Autor SET Nombre=@nombre,Apellido=@apellido,Pais=@pais WHERE idAutor=@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", appellido);
                comando.Parameters.AddWithValue("@pais", pais);
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Update de editorial Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador"+e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ///
        }
        ///load autor
        public void loadAutor(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Autor";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        // Eliminar autor
        public void EliminarAutor(string codigo)
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Autor WHERE idAutor = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", codigo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de autor Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        ////////////////////////Libros//////////////////////
        public void InsertarLibro(string autor, string editorial, string categoria, string idioma, string paginas, string publicado,string titulo)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Libro (fkAutor,fkEditorial,fkCategoria,fkIdioma,Paginas,FechaPublicado,Titulo) values (@fkAutor,@fkEditorial,@fkCategoria,@fkIdioma,@Paginas,@FechaPublicado,@titulo)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@fkAutor", autor);
                comando.Parameters.AddWithValue("@fkEditorial", editorial);
                comando.Parameters.AddWithValue("@fkCategoria", categoria);
                comando.Parameters.AddWithValue("@fkIdioma", idioma);
                comando.Parameters.AddWithValue("@Paginas", paginas);
                comando.Parameters.AddWithValue("@FechaPublicado", publicado);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de libro Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Actualizar datos libro
        public static string CodLibro;
        public void EditarLibro(string autor, string editorial, string categoria, string idioma, string paginas, string publicado,string titulo)
        {
            try
            {
                Opendb();

                string query = "UPDATE Libro SET fkAutor=@fkAutor,fkEditorial=@fkEditorial,fkCategoria=@fkCategoria,fkIdioma=@fkIdioma,Paginas=@Paginas,FechaPublicado=@FechaPublicado,Titulo=@titulo WHERE idLibro=@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@fkAutor", autor);
                comando.Parameters.AddWithValue("@fkEditorial", editorial);
                comando.Parameters.AddWithValue("@fkCategoria", categoria);
                comando.Parameters.AddWithValue("@fkIdioma", idioma);
                comando.Parameters.AddWithValue("@Paginas", paginas);
                comando.Parameters.AddWithValue("@FechaPublicado", publicado);
                comando.Parameters.AddWithValue("@titulo", titulo);
                comando.Parameters.AddWithValue("@cod", CodLibro);
                comando.ExecuteNonQuery();
                MessageBox.Show("Update de libro Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ///
        }
        ///load libro
        public void loadLibro(DataGridView data)
        {
            try
            {
                string query = "select idLibro,Titulo,fkAutor,fkEditorial,fkCategoria,fkIdioma,Paginas,FechaPublicado from libro";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
        // Eliminar libro
        public void EliminarLibro()
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Libro WHERE idLibro = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", CodLibro);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de libro Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        ///cargar categoria 
        public void loadCategoria(ComboBox cbx)
        {
            con.Open();
            string query = "SELECT * FROM Categoria";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                cbx.Items.Add(data["Descripcion"].ToString());
            }
            con.Close();
        }
        /// cargar autor
        public void loadAutor(ComboBox cbx)
        {
            con.Open();
            string query = "SELECT * FROM Autor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                cbx.Items.Add(data["Nombre"].ToString());
            }
            con.Close();
        }
        /// load editorial
        public void loadEditorial(ComboBox cbx)
        {
            con.Open();
            string query = "SELECT * FROM Editorial";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                cbx.Items.Add(data["Nombre"].ToString());
            }
            con.Close();
        }
        //////////////////////////////Lectores ////////////////
        //insertar datos lector
        public void InsertarLector(string nombre, string apellido, string edad, string email, string telefono, string direccion)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Lector (Nombre,Apellido,Edad,Email,Telefono,Direccion) values (@nombre,@apellido,@edad,@email,@telefono,@direccion)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@edad", edad);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de Lector Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador"+e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // cargar datagrid lector
        public void loadLector(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Lector";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        // editar lector
        public static string codLector;

        public void EditarLector(string nombre, string apellido, string edad, string email, string telefono, string direccion)
        {
            try
            {
                Opendb();

                string query = "UPDATE  Lector SET Nombre = @nombre,Apellido=@apellido,Edad=@edad,Email=@email,Telefono=@telefono,Direccion=@direccion WHERE idLector=@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido", apellido);
                comando.Parameters.AddWithValue("@edad", edad);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@cod", codLector);
                comando.ExecuteNonQuery();
                MessageBox.Show("Edit de lector Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Eliminar lector
        public void EliminarLector()
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Lector WHERE idLector = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", codLector);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de lector Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //////////////////////////////Prestamos ////////////////
        //insertar datos prestamo
        public void InsertarPrestamo(string lector, string libro, string fecha1, string fecha2)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Prestamo (fkLector,fkLibro,FechaPrestamo ,FechaDevoluacion) values (@lector,@libro,@fecha1,@fecha2)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@lector", lector);
                comando.Parameters.AddWithValue("@libro", libro);
                comando.Parameters.AddWithValue("@fecha1", fecha1);
                comando.Parameters.AddWithValue("@fecha2", fecha2);
 
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de prestamo Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // cargar datagrid prestamo
        public void loadPrestamo(DataGridView data)
        {
            try
            {
                string query = "SELECT * FROM Prestamo";
                SqlCommand comando = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                data.DataSource = tabla;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        // editar prestamo
        public static string codPrestamo;

        public void EditarPrestamo(string lector, string libro, string fecha1, string fecha2)
        {
            try
            {
                Opendb();

                string query = "UPDATE  Prestamo SET fkLector = @lector,fkLibro=@libro,FechaPrestamo=@fecha1,FechaDevoluacion=@fecha2 WHERE idPrestamo=@cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@lector", lector);
                comando.Parameters.AddWithValue("@libro", libro);
                comando.Parameters.AddWithValue("@fecha1", fecha1);
                comando.Parameters.AddWithValue("@fecha2", fecha2);
                comando.Parameters.AddWithValue("@cod", codPrestamo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Edit de lector Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Eliminar prestamo
        public void EliminarPrestamo()
        {
            try
            {
                Opendb();

                string query = "DELETE FROM Prestamo WHERE idPrestamo = @cod";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@cod", codPrestamo);
                comando.ExecuteNonQuery();
                MessageBox.Show("Delete de prestamo Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //ultimo prestamo
        public int CodUprestamo()
        {
            
            int cod = 0;
            try
            {
                con.Open();
                string sql = "SELECT TOP (1) idPrestamo FROM Prestamo ORDER BY idPrestamo desc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cod = Convert.ToInt16(reader["idPrestamo"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
            return cod;
        }
        //ultimo edadCliente
        public int edadLector(string nombre)
        {

            int cod = 0;
            try
            {
                con.Open();
                string sql = "select b.Nombre,b.Edad,a.idPrestamo from Prestamo as a join Lector as b on a.fkLector=b.Nombre WHERE b.Nombre=@nombre";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cod = Convert.ToInt16(reader["Edad"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador" + e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
            return cod;
        }
        //insertar datos entregaFactura
        public void InsertarEntrega(string prestamo, string lector, string libro, string mora, string subtotal, string descuento, string impuesto, string total, string monto, string cambio)
        {
            try
            {
                Opendb();

                string query = "INSERT INTO Entrega (fkPrestamo,fkLector,fkLibro,Mora,Subtotal,Descuento,Impuesto,Total,MontoPagado,Cambio) values (@fkPrestamo,@fkLector,@fkLibro,@Mora,@Subtotal,@Descuento,@Impuesto,@Total,@MontoPagado,@Cambio)";

                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@fkPrestamo", prestamo);
                comando.Parameters.AddWithValue("@fkLector", lector);
                comando.Parameters.AddWithValue("@fkLibro", libro);
                comando.Parameters.AddWithValue("@Mora", mora);
                comando.Parameters.AddWithValue("@Subtotal", subtotal);
                comando.Parameters.AddWithValue("@Descuento", descuento);
                comando.Parameters.AddWithValue("@Impuesto", impuesto);
                comando.Parameters.AddWithValue("@Total", total);
                comando.Parameters.AddWithValue("@MontoPagado", monto);
                comando.Parameters.AddWithValue("@Cambio", cambio);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro de entrega Exitoso");
                Closedb();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema, contactar un administrador"+e, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
