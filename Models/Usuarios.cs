public class Usuarios
{
    public int IdUsuario;
    
    public string? Apellido;

    public string? Nombre;

    public string Contraseña;

    public string? Pronombres;

    public string Nametag;

    public string Foto;

    public string? Descripcion;

    public string? Estado;

    public int Notificaciones;

    public string Email;

    public string ConfirmarContraseña {get; set;}
}
/* esto da error and idk why
 public Usuarios() {}

 public Usuarios(int id, string apellido, string nombre, string contraseña, string pronombres, string nametag, string foto, string descripcion, string estado, int notificaciones, string email, string confirmarcontraseña){
    this.IdUsuario=id;
    this.Apellido=apellido;
    this.Nombre=nombre;
    this.Contraseña=contraseña;
    this.Pronombres=pronombres;
    this.Nametag=nametag;
    this.Foto=foto;
    this.Descripcion=descripcion;
    this.Estado=estado;
    this.Notificaciones=notificaciones;
    this.Email=email;
    this.ConfirmarContraseña=confirmarcontraseña;
}
*/