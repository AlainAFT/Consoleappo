namespace TiendaConsola;
public class Roles
{
    
    private string pos;
    public Privilegios prive;
    public const string user = "USER";
    public const string Admin = "ADMIN";
    public const string nulo = "Nothing";
    public Roles(string posicion)
    {
        this.pos = posicion;
        prive = new Privilegios();
        if (pos == user)
        {
            prive.puedeagregaralcarrito = true;
            prive.puedeeliminardelcarrito = true;
            prive.puedevercarrito = true;
            prive.puedeverinventario=true;
        }

        if (pos == Admin)
        {
            prive.puedeagregaralcarrito = true;
            prive.puedeeliminardelcarrito = true;
            prive.puedevercarrito = true;
            prive.puedeverinventario = true;
            prive.puedeagregarproductos = true;
            prive.puedecrearproductos = true;
            prive.puedeeliminarproductos = true;
            prive.puedeeditarinventario = true;
        }
    }

    public void AnularRol()
    {
        this.pos = nulo;
        prive.puedeagregaralcarrito=false;
        prive.puedeeliminardelcarrito=false;
        prive.puedevercarrito = false;
        prive.puedeverinventario = false;
        prive.puedeagregarproductos = false;
        prive.puedecrearproductos = false;
        prive.puedeeliminarproductos = false;
        prive.puedeeditarinventario = false;
    }

    public string conseguirrol()
    {
        return pos;
    }
   
    
    
}