public class Producto
{
    
  private  string Codigo;
   private string Nombre;
       private double Precio;

    public Producto(string cod,string nom , double pre){
                Codigo=cod;

        Nombre=nom;
        Precio=pre;
    }

    public string conseguircodigo()
    {
        return Codigo;
    }
    public string conseguirnombre()
    {
        return Nombre;
    }

    public double  conseguirprecio()
    {
        return Precio;
    }

   




}




    


