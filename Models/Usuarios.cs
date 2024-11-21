using System.Text.Json;

[Serializable]
public class Usuarios
{
    public int IdUsuario;
    
    public string? Apellido;

    public string? Nombre;

    public string? Contraseña { get; set; }

    public string? Pronombres;

    public string? Nametag;

    public string? Foto;

    public string? Descripcion;

    public string? Estado;

    public int Notificaciones;

    public string? Email { get; set; }

    public Usuarios(string email, string contraseña){
        this.Email = email;
        this.Contraseña = Contraseña;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Usuarios? FromString(string? json)
    {
        if (json is null)
        {
            return null;
        }

        return JsonSerializer.Deserialize<Usuarios>(json);
    }
}
