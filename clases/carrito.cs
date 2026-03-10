using System.Dynamic;

public class Carrito
    {
        private string ID;
        private string cliente;
        private double total_apagar=0.0;
        public struct carrito
        {
            public Producto producto;
            public int cantidad;
        }
        private List<carrito> CARRITO;
        private int cantidad_complementos=0;

        public Carrito(string codigo)
        {
            CARRITO = new List<carrito> { } ;
            ID = codigo;
        }

        public bool AgregarAlCarrito(Producto pp , int cantidad)
        {
            // verificar si ya esta en el carrito
            foreach(carrito p in CARRITO)
            {
                if(p.producto.conseguircodigo() == pp.conseguircodigo())
                {
                    return false;
                }
            }

            carrito nuevo = new carrito();
        nuevo.producto = pp;
        nuevo.cantidad = cantidad;
            

            CARRITO.Add(nuevo);
            return true;

        }

        public void  total_de_compra()
        {
            total_apagar = 0.0;

            foreach(carrito p in CARRITO)
            {
                total_apagar += (double)p.producto.conseguirprecio() * p.cantidad ;
            }

        
        }

        public double conseguirtotal()
        {
            return total_apagar;
        }


        public void numero_de_complementos_carrito()
        {
            foreach (carrito p in CARRITO)
            {
                cantidad_complementos+=p.cantidad;
            }

           

        }

        public int conseguircantidadcomplementos()
        {
            return cantidad_complementos;
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