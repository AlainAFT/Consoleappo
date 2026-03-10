Producto p1 = new Producto("001", "Manzana", 0.5);
Producto p2 = new Producto("002", "Banana", 0.3);
Producto p3 = new Producto("003", "Naranja", 0.4);
Producto p4 = new Producto("004", "Pera", 0.6);
Producto p5 = new Producto("005", "Uva", 0.2);
Producto p6 = new Producto("006", "Fresa", 0.8);
Producto p7 = new Producto("007", "Melon", 1.0);
Producto p8 = new Producto("008", "Sandia", 1.2);
Producto p9 = new Producto("009", "Piña", 1.5);
Producto p10 = new Producto("010", "Mango", 0.9);
Inventario inventario = new Inventario();
inventario.AgregarProducto(p1, 100);
inventario.AgregarProducto(p2, 150);
inventario.AgregarProducto(p3, 120);
inventario.AgregarProducto(p4, 80);
inventario.AgregarProducto(p5, 200);
inventario.AgregarProducto(p6, 50);
inventario.AgregarProducto(p7, 30);
inventario.AgregarProducto(p8, 20);
inventario.AgregarProducto(p9, 10);
inventario.AgregarProducto(p10, 60);

Carrito carrito = new Carrito("carrito 001");

Console.Write("Ingrese el nombre del cliente: ");
string nombreCliente = Convert.ToString(Console.ReadLine());
carrito.nombrarcliente(nombreCliente);
carrito.AgregarAlCarrito(p1, 5);
carrito.AgregarAlCarrito(p3, 3);
carrito.AgregarAlCarrito(p5, 10);
carrito.AgregarAlCarrito(p7, 2);


Presentation presentacion = new Presentation(inventario);
presentacion.principalpresentacion();


