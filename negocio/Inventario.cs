namespace TiendaConsola;

public class Inventario
{
    public struct stock
    {
        public Producto producto;
        public int cantidad;
    }
    private List<stock> productos;

    public Inventario()
    {
        productos = new List<stock>();
    }

    public Producto encontrarproducto(string name)
    {
        foreach (stock p in productos)
        {
            if (p.producto.conseguirnombre() == name)
            {
                return p.producto;
            }
        }

        return null;
    }

    public bool AgregarProducto(Producto prod, int cantidad = 1)
    {

        // verificar si el producto ya existe en el inventario
        foreach (stock p in productos)
        {
            if (p.producto.conseguircodigo() == prod.conseguircodigo()) return false;
        }
        // agregar

        stock nuevoproducto = new stock();
        nuevoproducto.producto = prod;
        nuevoproducto.cantidad = cantidad;
        productos.Add(nuevoproducto);
        return true;
    }

    public bool CambiarStock(string codigo, int cant)
    {
        if (cant <= 0) return false;
        
        for (int i = 0; i < productos.Count; ++i)
        {
            if (productos[i].producto.conseguircodigo() == codigo)
            {
                stock actualizado = productos[i];
                actualizado.cantidad = cant;
                productos[i] = actualizado;
                return true;
            }
        }
        return false;
    }

    public bool CambiarPrecio(string cod,double precio)
    {
        if (precio <= 0) return false;
        
        for (int i = 0; i < productos.Count; ++i)
        {
            if (productos[i].producto.conseguircodigo() == cod)
            {
                stock actualizado = productos[i];
                actualizado.producto.cambiarelprecio(precio);
                productos[i] = actualizado;
                return true;
            }
        }
        return false;
    }

    public void cambiarinvetario(List<stock> n)
    {
        productos = n;
    }
    
 
    public List<stock> EliminarProducto(string n,List<stock> antiguo) // solo nombre
    {
        List<stock> invnew = new List<stock>() ;

        
        for(int i =0 ;i<antiguo.Count();++i)
        {
            if ( antiguo[i].producto.conseguirnombre() != n )
            {
                invnew.Add(antiguo[i]);
            }
            
        }

        if (invnew.Count() == antiguo.Count())
        {
            return null;
        }
        
        return invnew;
    }

    public List<stock> GetStock()
    {
        return productos;
    }
}