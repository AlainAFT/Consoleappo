namespace TiendaConsola;

public class usuario
{
    private string IDusuario ;
    private string nombre;
    private string email;
    private string contraseña;
    private  bool estado = true;
    public Roles rol;
    public usuario( string na , string em,string contra , string pos)
    {
        
        this.nombre = na;
        this.contraseña = contra;
        this.email = em;
        rol = new Roles(pos);

    }

    public string devolvernombre()
    {
        return nombre;
    }

    public bool devolverestado()
    {
        return estado;
    }

    public void cambiarelestado()
    {
        estado = !estado;
    }

    public string conseguirID()
    {
        return IDusuario;
    }
    public string conseguirInfoUSER()
    {
        return " | "+IDusuario + " | " + nombre + " | "+email+" | ";
    }

    public string conseguirinfoprivuser()
    { 
        return email + " " + contraseña;
    }

    public string conseguircontraseña()
    {
        return contraseña;
    }

    public string conseguiremail()
    {
        return email;
    }

    public void vaciarUsuario()
    {
        IDusuario = "";
        nombre = "";
        email = "";
        contraseña = "";
        rol.AnularRol();
    }

    public bool verificarmayor0(string i)
    {
        int aña = int.Parse(i);
        if (aña <= 0)
        {
            return false;
        }

        return true;

    }

    public void cambiardeestadoid(string i)
    {
        if (verificarmayor0(i))
        {
            IDusuario = i;
        }
    }

    public void cambiarestadodenombre(string n)
    {
        nombre = n;
    }

    public void cambiardeestadoemail(string e)
    {
        email = e;
    }

    public void cambiarestadocontraseña(string c)
    {
        contraseña = c;
    }
    
}