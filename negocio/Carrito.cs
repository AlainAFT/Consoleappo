namespace TiendaConsola;

public class Carrito
{
    private string ID;//id del usuario
    private string cliente; // su nombre

    public struct carrito
    {
        public Producto producto;
        public int cantidad;
    };
    private List<carrito> CARRITO;

    private   string  estadocarrito  = "activo" ;   // cerrado o activo

    public Carrito(string codigo)
    {
        CARRITO = new List<carrito> { } ;
        ID = codigo;
    }

    public string devolverprocedencia()
    {
        return ID + " " + cliente;
    }
    
    public int AgregarAlCarrito(Producto pp , int cantidad)
    {
        // verificar si ya esta en el carrito
        for(int i =0;i<CARRITO.Count(); ++i)
        {
            if(CARRITO[i].producto.conseguircodigo() == pp.conseguircodigo())
            {
                carrito yahay = CARRITO[i];
                yahay.cantidad = yahay.cantidad + cantidad;

                CARRITO[i] = yahay;
                
                return 1;

            }
        }

        carrito nuevo = new carrito();
        nuevo.producto = pp;
        nuevo.cantidad = cantidad;
            

        CARRITO.Add(nuevo);
        return 0;

    }

    

    public int EliminarProducto(Producto p , int cant)
    { 
        if (cant == 0) // eliminacion del producto
        {
            List<carrito> nuevo = CARRITO;
            for (int i = 0; i < CARRITO.Count(); ++i)
            {
                if (CARRITO[i].producto.conseguirnombre() != p.conseguirnombre())
                {
                    nuevo.Add(CARRITO[i]);
                }
            }

            if (CARRITO.Count()== nuevo.Count()) return -2;
            CARRITO = nuevo;
            return 2;
        }

        if (cant > 0) // reduce la cantidad del producto
        {
            for (int i = 0; i < CARRITO.Count(); ++i)
            {
                if (CARRITO[i].producto.conseguirnombre() == p.conseguirnombre())
                {
                    carrito restado = CARRITO[i];
                    if (cant > restado.cantidad)
                    {
                        return -1; 
                    }
                    restado.cantidad = restado.cantidad - cant;

                    CARRITO[i] = restado;
                }
            }

            return 1;
        }

        return 0;
    }
   

    


   
    

    public List<carrito> GetCarrito()
    {
        return CARRITO;
    }
    public bool estavacio()
    {
        if (CARRITO.Count() == 0)
        {
            return true;
        }
        return false;
    }

    public void vaciarcarrito()
    {
        CARRITO.Clear();
    }

    public void nombrarcliente(string nombre)
    {
        cliente = nombre;
    }
}