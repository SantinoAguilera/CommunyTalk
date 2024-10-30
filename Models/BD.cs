using System.Data.SqlClient;
using Dapper;

public static class BD
{
    /* Atributos */
    private static string _connectionString = @"Server=A-PHZ2-CIDI-21;Database=DB_CommunyTalk;Trusted_Connection=True;";
    public static List<Grupos> ListaGrupos = new List<Grupos>();

    /* Metodos */
    public static List<Grupos> ObtenerGrupos()
    {
        using (SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Grupos";
            ListaGrupos = db.Query<Grupos>(sql).ToList();
        }
        return ListaGrupos;
    }
}