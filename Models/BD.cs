using System.Data.SqlClient;
using System.Net.Http.Headers;
using Dapper;

public static class BD
{
    /* Atributos */
    private static string _connectionString = @"Server=A-PHZ2-CIDI-20;Database=DB_CommunyTalk;Trusted_Connection=True;";
    public static int IdUsuarioSesion;
    public static int IdComunidadActual;
    public static int IdGrupoActual;
    public static int IdChatActual;
    public static List<Usuarios> ListaUsuarios = new List<Usuarios>();
    public static List<Grupos> ListaGrupos = new List<Grupos>();
    public static List<Comunidades> ListaComunidades = new List<Comunidades>();
    public static List<Mensajes> ListaMensajes = new List<Mensajes>();
    public static List<IntegrantesXGrupo> ListaIntegrantesGrupos = new List<IntegrantesXGrupo>();

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

    public static List<Usuarios> ObtenerAmigos()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM AmigosXUsuario x INNER JOIN Usuarios u ON u.IdUsuario = x.IdUsuario WHERE u.IdUsuario = @pIdUsuarioSesion";
            ListaUsuarios = db.Query<Usuarios>(sql, new { pIdUsuarioSesion = IdUsuarioSesion }).ToList();
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

    public static List<IntegrantesXGrupo> ObtenerIntegrantesGrupos(){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM IntegrantesXGrupo";
            ListaIntegrantesGrupos = db.Query<IntegrantesXGrupo>(sql).ToList();
        }
        return ListaIntegrantesGrupos;
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

    public static string ObtenerNameTagEmisor(int IdUsuario)
    {
        string NameTag;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT NameTag FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            NameTag = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuario});
        }
        NameTag ??= "ERROR";
        return NameTag ?? "ERROR";
    }

    public static string ObtenerNameTag()
    {
        string NameTag;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT NameTag FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            NameTag = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return NameTag;
    }

    public static string ObtenerNombre()
    {
        string Nombre;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Nombre FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            Nombre = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return Nombre;
    }

    public static string ObtenerApellido()
    {
        string Apellido;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT Apellido FROM Usuarios WHERE IdUsuario = @pIdUsuario";
            Apellido = db.QueryFirstOrDefault<string>(sql, new { pIdUsuario = IdUsuarioSesion});
        }
        return Apellido;
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

    public static void EditarPerfil(string FotodePerfil, string NameTag, string Nombre, string Apellido, string Pronombres, string Descripcion)
    {
        string sql = "UPDATE Usuarios SET Foto = @FotodePerfil, NameTag = @NameTag, Nombre = @Nombre, Apellido = @pApellido, Pronombres = @pPronombres, Descripcion = @pDescripcion WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pFotodePerfil = FotodePerfil, pNameTag = NameTag, pNombre = Nombre, pApellido = Apellido, pPronombres = Pronombres, pDescripcion = Descripcion, pIdUsuarioSesion = IdUsuarioSesion});
        }
    }

    public static void AñadirUsuario(string Usuario, string Contraseña, string Email)
    {
        string sql = "INSERT INTO Usuarios (Contraseña, NameTag, Email) VALUES (@pContraseña, @pNameTag, @pEmail)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pContraseña = Contraseña, pNameTag = Usuario, pEmail = Email });
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

    public static void CambiarFoto(string FotodePerfil)
    {
        string sql = "UPDATE Usuarios SET Foto = @pFotodePerfil WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pFotodePerfil = FotodePerfil, pIdUsuarioSesion = IdUsuarioSesion});
        }
    }

    public static void CambiarNameTag(string NameTag)
    {
        string sql = "UPDATE Usuarios SET NameTag = @pNameTag WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNameTag = NameTag, pIdUsuarioSesion = IdUsuarioSesion});
        }
    }

    public static void CambiarNombre(string Nombre)
    {
        string sql = "UPDATE Usuarios SET Nombre = @pNombre WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = Nombre, pIdUsuarioSesion = IdUsuarioSesion});
        }
    }

    public static void CambiarApellido(string Apellido)
    {
        string sql = "UPDATE Usuarios SET Apellido = @pApellido WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pApellido = Apellido, pIdUsuarioSesion = IdUsuarioSesion});
        }
    }

    public static void CambiarPronombres(string Pronombres)
    {
        string sql = "UPDATE Usuarios SET Pronombres = @pPronombres WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pPronombres = Pronombres, pIdUsuarioSesion = IdUsuarioSesion});
        }
    }

    public static void CambiarDescripcion(string Descripcion)
    {
        string sql = "UPDATE Usuarios SET Descripcion = @pDescripcion WHERE IdUsuario = @pIdUsuarioSesion";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pDescripcion = Descripcion, pIdUsuarioSesion = IdUsuarioSesion});
        }
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

public static void InsertGroup(Grupos grupo)
{
    int idGrupo;
    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        string sql = @"
            INSERT INTO Grupos (Descripcion, FotodePerfil, Nombre, Privado, IdAdmin) VALUES (@pDescripcion, @pFotodePerfil, @pNombre, @pPrivado, @pIdAdmin);
            SELECT CAST(SCOPE_IDENTITY() AS INT)";
        idGrupo = db.QuerySingle<int>(sql, new
        {pDescripcion = grupo.Descripcion, pFotodePerfil = grupo.FotodePerfil, pNombre = grupo.Nombre, pPrivado = grupo.Privado, pIdAdmin = grupo.IdAdmin});
    }
    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        string sql = "INSERT INTO IntegrantesXGrupo (IdGrupo, IdUsuario, TopActividad) VALUES (@pIdGrupo, @pIdUsuario, 4)";

        db.Execute(sql, new
        {pIdGrupo = idGrupo, pIdUsuario = grupo.IdAdmin});
    }
}
}
