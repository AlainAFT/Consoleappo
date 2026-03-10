using System.Reflection;

class Presentation
{
    private Inventario inventario;
    private Carrito carrito;


    public Presentation(Inventario inv)
    {
        inventario = inv;
        
    }

    public Presentation(Carrito car)
    {
        carrito = car;
    }


 public void MostrarInventario()
    {
       foreach (Inventario.stock p in inventario.GetStock())
        {
            Console.WriteLine($"codigo del producto : {p.producto.conseguircodigo()} |  nombre :  {p.producto.conseguirnombre()} |  unidades del producto : {p.cantidad}  |  precio del producto  {p.producto.conseguirprecio()}  Bs");
        }
    }

    public void MostrarCarrito()
    {
        foreach (Carrito.carrito p in carrito.GetCarrito())
        {
            Console.WriteLine($"codigo del producto : {p.producto.conseguircodigo()} |  nombre :  {p.producto.conseguirnombre()} |  unidades del producto : {p.cantidad}  |  precio del producto  {p.producto.conseguirprecio()}  Bs");
        }
        carrito.total_de_compra();
        carrito.numero_de_complementos_carrito();
        Console.WriteLine($"Cantidad de productos en el carrito : {carrito.conseguircantidadcomplementos()} ");
        Console.WriteLine($"Total a pagar : {carrito.conseguirtotal()} Bs");
    }
public void mostrarinstrucciones()
    {
        Console.WriteLine("Bienvenido a la tienda virtual de la universidad catolica boliviana  \n");
        Console.WriteLine("Instrucciones : \n");
        Console.WriteLine("1. mostrar inventario de la tienda \n");
        Console.WriteLine("2.SALIR DE LA TIENDA \n");

    }

    public void principalpresentacion()
    {
        mostrarinstrucciones();
        int opcion = 0;
        while (opcion != 2)
        {
            Console.WriteLine("Ingrese una opcion : ");
            opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    MostrarInventario();
                    break;
                case 2:
                    Console.WriteLine("Gracias por visitar nuestra tienda virtual");
                    break;
                default:
                    Console.WriteLine("Opcion no valida, por favor ingrese una opcion valida");
                    break;
            }
        }
     


    MostrarCarrito();
    

    }

}