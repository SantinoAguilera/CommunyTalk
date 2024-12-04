using System.Data.SqlClient;
using System.Net.Http.Headers;
using Dapper;

public static class BD
{
    /* Atributos */
    private static string _connectionString = @"Server=sasanet\sqlexpress;Database=DB_CommunyTalk;Trusted_Connection=True;";
    public static int IdUsuarioSesion;
    public static int IdComunidadActual;
    public static int IdGrupoActual;
    public static int IdChatActual;
    public static List<Usuarios> ListaUsuarios = new List<Usuarios>();
    public static List<Grupos> ListaGrupos = new List<Grupos>();
    public static List<Comunidades> ListaComunidades = new List<Comunidades>();
    public static List<Mensajes> ListaMensajes = new List<Mensajes>();

    public static bool StatusBusqueda = false;

    /* Metodos */

    public static List<Usuarios> ObtenerUsuarios()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuarios"; // Obtenemos todos los usuarios
            ListaUsuarios = db.Query<Usuarios>(sql).ToList();
        }
        return ListaUsuarios;
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

    public static List<Comunidades> ObtenerTresComunidades()
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT TOP 3 * FROM Comunidades c INNER JOIN IntegrantesXComunidad i ON c.IdComunidad = i.IdComunidad ORDER BY TopActividad";
            ListaComunidades = db.Query<Comunidades>(sql).ToList();
        }
        return ListaComunidades;
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
            string sql = "SELECT * FROM Mensajes WHERE IdUsuario = @pIdUsuario AND IdUsuarioEmisor = @pIdUsuarioEmisor";
            ListaMensajes = db.Query<Mensajes>(sql, new { pIdUsuario = IdUsuario, pIdUsuarioEmisor = IdUsuarioSesion}).ToList();
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

    public static void EnviarMensajePrivado (string Contenido, int IdUsuario)
    {
        DateTime FechaHora = DateTime.Now;
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "INSERT INTO Mensajes(Contenido, FechaHora, IdUsuario, IdUsuarioEmisor) VALUES (@pContenido, @pFechaHora, @pIdUsuario, @pIdUsuarioSesion)";
            db.Execute(sql, new { pContenido = Contenido, pFechaHora = FechaHora, pIdUsuario = IdChatActual, pIdUsuarioSesion = IdUsuarioSesion });
        }
    }

    public static void EnviarMensajeGrupo (string Contenido, int IdUsuario)
    {
        DateTime FechaHora = DateTime.Now;
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "INSERT INTO Mensajes(Contenido, FechaHora, IdGrupo, IdUsuarioEmisor) VALUES (@pContenido, @pFechaHora, @pIdGrupo, @pIdUsuarioSesion)";
            db.Execute(sql, new { pContenido = Contenido, pFechaHora = FechaHora, pIdGrupo = IdGrupoActual, pIdUsuarioSesion = IdUsuarioSesion });
        }
    }

    public static void EnviarMensajeComunidad (string Contenido, int IdUsuario)
    {
        DateTime FechaHora = DateTime.Now;
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "INSERT INTO Mensajes(Contenido, FechaHora, IdComunidad, IdUsuarioEmisor) VALUES (@pContenido, @pFechaHora, @pIdComunidad, @pIdUsuarioSesion)";
            db.Execute(sql, new { pContenido = Contenido, pFechaHora = FechaHora, pIdComunidad = IdComunidadActual, pIdUsuarioSesion = IdUsuarioSesion });
        }
    }

    public static string ObtenerFoto(int IdUsuario)
    {
        string foto;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Foto FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            foto = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuario});
        }
        foto ??= "default.png";
        return foto ?? "default.png";
    }

    public static string ObtenerNametag()
    {
        string NameTag;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT NameTag FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            NameTag = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return NameTag;
    }

    public static string ObtenerEmail()
    {
        string Email;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Email FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            Email = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return Email ?? "?";
    }

    public static string ObtenerPronombres()
    {
        string Pronombres;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Pronombres FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            Pronombres = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return Pronombres ?? "?";
    }

    public static string ObtenerDescripcion()
    {
        string Descripcion;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Descripcion FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            Descripcion = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return Descripcion ?? "?";
    }

    public static string ObtenerFotodePerfil(int IdGrupo)
    {
        string foto;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT FotodePerfil FROM Grupos WHERE IdGrupo = @pIdGrupo";
            foto = db.QueryFirstOrDefault<string>(sql, new { pIdGrupo = IdGrupo});
        }
        if (foto == null) foto = "default.jpg";
        return foto ?? "/images/default.jpg";
    }

    public static void AñadirUsuario(Usuarios usuario)
    {
        string sql = "INSERT INTO Usuarios (Contraseña, Email) VALUES (@pContraseña,@pEmail)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pContraseña = usuario.Contraseña, pEmail = usuario.Email });
        }
    }

    public static Usuarios BuscarPersona(string Email, string Contraseña)
    {
        Usuarios usuario = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuarios WHERE Email = @Email AND Contraseña = @Contraseña";
            usuario = db.QueryFirstOrDefault<Usuarios>(sql, new { pEmail = Email, pContraseña = Contraseña });
        }
        return usuario;
    }

    public static void CambiarContraseña(string Email, string nuevaContraseña)
    {
        string sql = "UPDATE Usuarios SET Contraseña = @pNuevaContraseña WHERE Email = @pEmail";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNuevaContraseña = nuevaContraseña, pEmail = Email });
        }
    }

    public static Usuarios LoginIngresado(string Nametag, string Contraseña)
    {
        Usuarios Ingresado = new Usuarios();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuarios WHERE Nametag = @pNametag and Contraseña= @pContraseña";
            Ingresado = db.QueryFirstOrDefault<Usuarios>(sql, new { pNametag = Nametag , pContraseña = Contraseña });
        }
        return Ingresado;
    }
       public static Usuarios ListarPorId(int IdUsuario)
    {
        Usuarios Ingresado = new Usuarios();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            Ingresado = db.QueryFirstOrDefault<Usuarios>(sql, new { pIdUsuario = IdUsuario });
        }
        return Ingresado;
    }
    public static void InsertUser(Usuarios user)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Usuarios(Contraseña, Nametag, Email) VALUES (@pNametag, @pContraseña, @pEmail)";
            db.Execute(sql, new{ pContraseña = user.Contraseña, pUsuario = user.Nametag, pEmail = user.Email});
        }
    }
    public static void ActualizarContraseña(string Nametag, string NuevaContraseña)
    {
        string SQL = "UPDATE Usuarios SET Contraseña = @pNuevaContraseña WHERE Nametag = @pNametag";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new{ pNuevaContraseña = NuevaContraseña, pNametag = Nametag});
        }
    }
}
