namespace TiendaConsola;

public class Compra
{
    private Carrito car;
    private double total_compra;
    private DateTime fecha_de_compra;

    public Compra(Carrito carro)
    {
        this.car = carro;
        this.fecha_de_compra = DateTime.Now;
        this.total_compra = CALCULARTOTAL();
    }

    public double devolvertotal()
    {
        return total_compra;
    }

    public DateTime devolvertiempo()
    {
        return fecha_de_compra;
    }


    public double CALCULARTOTAL()
    {
        if (car.estavacio()) return -1.0;
        double sum = 0.0;
        List<Carrito.carrito> carcp = car.GetCarrito();
        for (int i = 0; i < carcp.Count(); ++i)
        {
            sum += carcp[i].producto.conseguirprecio() * carcp[i].cantidad;
        }

        return sum;
    }
    
    
        
    
}