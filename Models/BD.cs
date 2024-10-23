using System.Data.SqlClient;
using Dapper;

public static class BD
{
    
    /* Atributos */
    private static string _connectionString = @"Server=localhost;Database=DB_CommunyTalk;Trusted_Connection=True;";
    public static List<Ejemplo> ListaPaises = new List<Ejemplo>();
}