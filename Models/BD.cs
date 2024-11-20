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

    public static bool StatusBusqueda = false;

    /* Metodos */

    public static List<Usuarios> ObtenerUsuarios()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuarios"; // Obtenemos todos los usuarios
            return connection.Query<Usuarios>(sql).ToList();
        }
    }

    public static List<Grupos> ObtenerGrupos()
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Grupos";
            ListaGrupos = db.Query<Grupos>(sql).ToList();
        }
        return ListaGrupos;
    }

    public static List<Grupos> ObtenerTresGrupos()
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT TOP 3 * FROM Grupos g INNER JOIN IntegrantesXGrupo i ON g.IdGrupo = i.IdGrupo ORDER BY TopActividad";
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

    public static List<Mensajes> ObtenerMensajesPrivado(int IdUsuario)
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Mensajes WHERE IdUsuario = 1";
            ListaMensajes = db.Query<Mensajes>(sql, new { pIdUsuario = IdUsuario}).ToList();
        }
        return ListaMensajes;
    }

    public static List<Mensajes> ObtenerMensajesGrupo(int IdGrupo)
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Mensajes WHERE IdGrupo = @pIdGrupo";
            ListaMensajes = db.Query<Mensajes>(sql, new { pIdGrupo = IdGrupo}).ToList();
        }
        return ListaMensajes;
    }
    public static List<Mensajes> ObtenerMensajesComunidad(int IdComunidad)
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Mensajes WHERE IdComunidad = @pIdComunidad";
            ListaMensajes = db.Query<Mensajes>(sql, new { pIdComunidad = IdComunidad}).ToList();
        }
        return ListaMensajes;
    }

    public static string ObtenerFoto(int IdUsuario)
    {
        string foto;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Foto FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            foto = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuario});
        }
        return foto ?? "/images/default.jpg";
    }

    public static string ObtenerFotodePerfil(int IdGrupo)
    {
        string foto;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT FotodePerfil FROM Grupos WHERE IdGrupo = @pIdGrupo";
            foto = db.QueryFirstOrDefault<string>(sql, new { pIdGrupo = IdGrupo});
        }
        return foto ?? "/images/default.jpg";
    }
}