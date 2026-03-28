using System.ComponentModel;
using TiendaConsola ;
using TiendaConsola.presentacion;

Console.WriteLine("Bienvenido , a la tienda borrador");

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

int choice = 0;
PresentacionTienda present = new PresentacionTienda(inventario);

bool pristinidad = true;


while (present.devolvercerrartienda() != true)
{


    present.mostrarinstruccionesdecuenta();

    Console.WriteLine("input : ");

    choice = int.Parse(Console.ReadLine());

    present.decidirinputdecuenta(choice);

    present.mostrardecidir();
}























/*
bool pristinidad = true;
while (choice != 13)
{
    if (pristinidad == true)
    {
        string em, nom, id, rol, contra;
        Console.Write("ingrese su nombre y id:");
        nom = Console.ReadLine();
        id = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine(" Ingrese su email:");
        em = Console.ReadLine();
        Console.WriteLine("introduzca su contraseña");
        contra = Console.ReadLine();
        Console.WriteLine("Intruduzca su rol:");
        rol = Console.ReadLine();
        usuario us = new usuario(id, nom, em, contra, rol);
        present.ingresarUsuario(us);
        pristinidad = false;
    }

    present.mostrarinstrucciones();
    choice = int.Parse(Console.ReadLine());
    present.decidirelinput(choice);
    if (choice == 11)
    {
        pristinidad = true;
    }



}*/

