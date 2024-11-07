using System.Data.SqlClient;
using Dapper;

public static class BD
{
    /* Atributos */
    private static string _connectionString = @"Server=A-PHZ2-CIDI-21;Database=DB_CommunyTalk;Trusted_Connection=True;";
    public static int IdUsuarioSesion;
    public static List<Grupos> ListaGrupos = new List<Grupos>();
    public static List<Comunidades> ListaComunidades = new List<Comunidades>();
    public static List<Mensajes> ListaMensajes = new List<Mensajes>();

    /* Metodos */
    public static List<Grupos> ObtenerGrupos()
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Grupos";
            ListaGrupos = db.Query<Grupos>(sql).ToList();
        }
        return ListaGrupos;
    }

    public static List<Comunidades> ObtenerComunidades()
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Comunidades";
            ListaComunidades = db.Query<Comunidades>(sql).ToList();
        }
        return ListaComunidades;
    }

<<<<<<< HEAD

=======
>>>>>>> 87a23737593d1074af3e5af2e778535e257d94b9
    public static List<Mensajes> ObtenerMensajesPrivado(int IdUsuario)
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Mensajes m INNER JOIN MensajesXUsuario x ON m.IdMensaje = x.IdMensaje WHERE IdUsuario = @pIdUsuario";
            ListaMensajes = db.Query<Mensajes>(sql, new { pIdUsuario = IdUsuario}).ToList();
        }
        return ListaMensajes;
    }

    public static List<Mensajes> ObtenerMensajesGrupo(int IdGrupo)
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Mensajes m INNER JOIN MensajesXGrupo x ON m.IdMensaje = x.IdMensaje WHERE IdGrupo = @pIdGrupo";
            ListaMensajes = db.Query<Mensajes>(sql, new { pIdGrupo = IdGrupo}).ToList();
        }
        return ListaMensajes;
    }

    public static string ObtenerFotoDePerfil(int IdUsuario)
    {
        string foto;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Foto FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            foto = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuario});
        }
        return foto ?? "/images/default.jpg";
    }

    public static List<Usuarios> ObtenerUsuarios()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuarios"; // Obtenemos todos los usuarios
            return connection.Query<Usuarios>(sql).ToList();
        }
    }
}