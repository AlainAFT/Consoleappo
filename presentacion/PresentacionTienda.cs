using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;

namespace TiendaConsola.presentacion;

public class PresentacionTienda
{
    
    private Inventario inventario;
    private Carrito carrito;
    private usuario user;
    private Login registr;
    private Compra cp;
    private bool cerrartienda = false;
    //private bool cerrarsesion = false;

    
    

    public bool devolvercerrartienda()
    {
        return cerrartienda;
    }

    /*public bool devolvercerrarsesion()
    {
        return cerrarsesion;
    }*/
    public PresentacionTienda(Inventario inv )
    {
        inventario = inv;

        usuario pruebaad = new usuario("alain", "admin", "1234", "ADMIN");
        usuario pruebaus = new usuario("Anthony", "user", "1234", "USER");
       
        registr = new Login();
        registr.IniciarSesionCnueva(pruebaad);
        registr.IniciarSesionCnueva(pruebaus);

    }

    public PresentacionTienda(Carrito car)
    {
        carrito = car;
    }

    public PresentacionTienda(usuario us)
    {
        this.user = us;
    }

    public void ingresarUsuario(usuario us)
    {
        this.user = us;
    }

 public void MostrarInventario()
    {
       foreach (Inventario.stock p in inventario.GetStock())
        {
            Console.WriteLine($"codigo del producto : {p.producto.conseguircodigo()} |  nombre :  {p.producto.conseguirnombre()} |  unidades del producto : {p.cantidad}  |   precio unitario : {p.producto.conseguirprecio()}");
        }
    }

    public void MostrarCatalogousuario()
    {
        foreach (Inventario.stock p in inventario.GetStock())
        {
            Console.WriteLine($" |  nombre :  {p.producto.conseguirnombre()}   |   precio unitario : {p.producto.conseguirprecio()}");
        }
    }

    public void MostrarCarrito()
    {
        foreach (Carrito.carrito p in carrito.GetCarrito())
        {
            Console.WriteLine($"codigo del producto : {p.producto.conseguircodigo()} |  nombre :  {p.producto.conseguirnombre()} |  unidades del producto : {p.cantidad}  |  precio del producto  {p.producto.conseguirprecio()}  Bs");
        }
       // carrito.total_de_compra();
       // carrito.numero_de_complementos_carrito();
        //Console.WriteLine($"Cantidad de productos en el carrito : {carrito.conseguircantidadcomplementos()} ");
       // Console.WriteLine($"Total a pagar : {carrito.conseguirtotal()} Bs");
    }

    
        public void listar_usuario()
        {
            List<usuario> lista = registr.devolverlistadeusuarios();
            foreach (usuario p in lista)
            {
                if (p.devolverestado() == true)
                {
                    Console.WriteLine(p.conseguirInfoUSER());
                }
            }
        }
   
    
    public void mostrarinstruccionesuser()
    {
        Console.WriteLine("Instrucciones : \n");
        Console.WriteLine("1. ver productos");
        Console.WriteLine("2.  VER EL CARRTIO");
        Console.WriteLine("3. agregar producto al carrito");
        Console.WriteLine("4. Eliminar producto del carrito");
        Console.WriteLine("5. realizar Compra");
        Console.WriteLine("6. cerrar sesion");
        Console.WriteLine("7. cerrar tienda");
    }
public void mostrarinstruccionesadmin()
    {
       
        Console.WriteLine("Instrucciones : \n");
        Console.WriteLine("1.  listar producto");
        Console.WriteLine("2. agregar producto");
        Console.WriteLine("3. actualizar producto");
        Console.WriteLine("4. eliminar producto ");
        Console.WriteLine("5. listar usuario");
        Console.WriteLine("6. agregar usuario");
        Console.WriteLine(" 7. actualizar usuario");
        Console.WriteLine("8. eliminar usuario");
        Console.WriteLine("9. cerrar sesion");
        Console.WriteLine("10.cerrar  LA TIENDA ");
    }

    public void mostrarintruccionesparacambiarusario()
    {
        Console.WriteLine("1. CAMBIAR NOMBRE DEL USUARIO ");
        Console.WriteLine("2. CAMBIAR EL EMAIL DEL USUARIO");
        Console.WriteLine("3. CAMBIAR EL CONTRASEÑA DEL USUARIO");
        Console.WriteLine("4. NO QUIERO HACER NINGUN CAMBIO MAS ");
    }

    public void decidirelinputadmin(int op)
    {
        
        
       
        switch (op)
            {
                case 1:
                    if (user.rol.prive.puedeverinventario == true)
                    {
                        MostrarInventario();
                    }
                    else Console.WriteLine("ERROR DE ACCESO");
                    break;
                case 2 :
                    if (user.rol.prive.puedeagregarproductos == true)
                    {
                        string i, n;
                        double p;
                        int cant = 1;
                        Console.WriteLine("ingrese el producto con sus especificaciones en el siguiente orden: ");
                        Console.Write("Codigo : ");
                        i = Console.ReadLine();
                        Console.Write(" nombre : ");
                        n = Console.ReadLine();
                        Console.Write("precio (usar . en vez de coma para los decimales) : ");
                        p = double.Parse(Console.ReadLine());
                        do
                        {
                            if (cant <= 0)
                            {
                                Console.WriteLine("ingrese porfavor una cantidad mayor a cero");
                            }

                            Console.Write("ingrese la cantidad del producto : ");
                            cant = int.Parse(Console.ReadLine());
                        } while (cant <= 0);




                        Producto prod = new Producto(i, n, p);

                        if (inventario.AgregarProducto(prod, cant))
                        {
                            Console.WriteLine("se agrego de manera exitosa");
                        }
                        else Console.WriteLine("ERROR no se pudo agregar producto porque ya existia en el inventario");
                    }
                    else Console.WriteLine("ERROR DE ACCESO");
                    break;
                case 3:
                    if (user.rol.prive.puedeeditarinventario == true)
                    {
                        string cn;
                        
                        Console.Write("Codigo o Nombre del producto : ");
                        cn = Console.ReadLine();
                        int cant=1;
                        do
                        {
                            if (cant <= 0)
                            {
                                Console.WriteLine("ingrese porfavor una cantidad mayor a cero");
                            }

                            Console.Write("ingrese la cantidad del producto : ");
                            cant = int.Parse(Console.ReadLine());
                        } while (cant <= 0);

                        if (inventario.CambiarStock(cn, cant))
                        {
                            Console.WriteLine("se actualizo el stock del producto con exito ");
                        }
                        else Console.WriteLine("se encontro algun error no se pudo actualizar");
                        
                        Console.WriteLine("ingrese el nuevo precio del producto");
                        double precio2 = double.Parse(Console.ReadLine());
                        if (inventario.CambiarPrecio(cn,precio2))
                        {
                            Console.WriteLine("se ha cambiado el precio correctamente");
                        }
                        else Console.WriteLine("se encontro algun error no se pudo actualizar");
                    }
                    else Console.WriteLine("ERROR DE ACCESO");

                    break;
                case 4:
                    if (user.rol.prive.puedeeliminarproductos == true)
                    {
                        string c;
                        Console.WriteLine("Ingrese el nombre del producto que quieres eliminar :");
                        c = Console.ReadLine();
                        List<Inventario.stock> newinventario=inventario.EliminarProducto(c , inventario.GetStock() );
                        if (newinventario!=null)
                        {
                            inventario.cambiarinvetario(newinventario );
                            Console.WriteLine("se elimino con exito el producto : ", c);
                        }
                        else Console.WriteLine("no se encontro el producto ",c);
                    }
                    
                    else Console.WriteLine("ERROR DE ACCESO");
                    break;
                case 5:
                    
                    listar_usuario();
                    
                    
                    break;
                case 6:
                    string  nom, rol ,em,con;
                    con = " ";
                    Console.Write("ingrese su nombre:");
                    nom = Console.ReadLine();
               
                    Console.WriteLine();
                    Console.WriteLine(" Ingrese su email:");
                    em = Console.ReadLine();
                    Console.WriteLine("introduzca su contraseña");
                    con= Console.ReadLine();
                    Console.WriteLine("Intruduzca su rol:");
                    rol = Console.ReadLine();
                    usuario us = new usuario( nom, em, con, rol);

                    if (registr.IniciarSesionCnueva(us))
                    {
                        Console.WriteLine("SE AGREGO EL USUARIO ");
                        listar_usuario();
                    }
                    else
                    {
                        Console.WriteLine("No se agrergo porque su email ya existia con anterioridad ");
                    }
                    
                    break;
                case 7:
                    listar_usuario();
                    Console.WriteLine("Ingrese el ID del usuario");
                    string cn2;
                    cn2 = Console.ReadLine();
                    usuario encontrado = registr.EncontrarUsuario(cn2);
                    if (encontrado == null)
                    {
                        Console.WriteLine("el ID oque ha sido ingresado nadie lo ocupa ");
                        break;
                    }

                    int choice99 = 0;
                    

                    while (choice99 != 4)
                    {
                        Console.WriteLine(encontrado.conseguirInfoUSER(), encontrado.conseguiremail());
                        mostrarintruccionesparacambiarusario();
                        Console.WriteLine("input : ");
                        choice99 = int.Parse(Console.ReadLine());

                        switch (choice99)
                        {
                            case 1 :
                                Console.WriteLine("INGRESE EL NUEVO NOMBRE");
                                string nombrecambiado = Console.ReadLine();
                                encontrado.cambiarestadodenombre(nombrecambiado);
                                break;
                                
                            case 2:
                                Console.WriteLine("INGRESE EL NUEVO email");
                                string emailcambiado = Console.ReadLine();
                                encontrado.cambiardeestadoemail(emailcambiado);
                                break;
                                    
                            case 3:
                                
                                string nuevacontra = "A";
                                bool error = false;
                                while (nuevacontra.Length < 8)
                                {
                                    if (error == true)
                                    {
                                        Console.WriteLine("NO SE ESTA RESPETANDO LAS CONDICIONES");
                                        error = false;
                                    }
                                    
                                    Console.WriteLine("INGRESE LA NUEVA CONTRASEÑA , QUE SEA MAYOR DE 8 CARACTERES");
                                    nuevacontra = Console.ReadLine();

                                    error = true;
                                }

                                break;
                                    
                            case 4:
                                 Console.WriteLine("CHAU");
                                break;
                                    
                            default :
                                Console.WriteLine("ESAS OPCIONES NO EXISTEN , DEBE ELEGIR DE ACUERDO A LOS NUMEROS DE OPCIONES");
                            break;
                        }
                    }
                    
                    registr.guardarinfodeusario(encontrado);
                    Console.WriteLine($"la actualizacion de datos del usuario :  {encontrado.conseguirInfoUSER()}  , se hecho correctamente");
                    
                    break;
                case 8:
                    Console.WriteLine("Ingrese el ID o email del usuario para eliminarlo");
                    string cn3;
                    cn3 = Console.ReadLine();

                    usuario eliminar = registr.EncontrarUsuario(cn3);

                    if (eliminar == null)
                    {
                        Console.WriteLine("el ID o email que ha sido ingresado nadie lo ocupa ");
                        break;
                    }
                    
                    eliminar.cambiarelestado();
                    
                    registr.guardarinfodeusario(eliminar);
                    
                    Console.WriteLine("se eliminado de manera suave el usuario ",eliminar.conseguirInfoUSER());
                    
                    break;
                case 9:
                    Console.WriteLine("Gracias por visitar nuestra tienda virtual");
                      registr.CerrarSesion(user);
                    
                    break;
                case 10 :
                    Console.WriteLine("Hasta luego cerramos el programa");
                    cerrartienda = true;
                    
                    break;
                default:
                    Console.WriteLine("Opcion no valida, por favor ingrese una opcion valida");
                    break;
            }
    }

    public void mostrarinstruccionesdecuenta()
    {
        Console.WriteLine("Instrucciones : \n");
        Console.WriteLine("1.  Ya tienes cuenta registrada ");
        Console.WriteLine("2. Eres nuevo y estas queriendo crear nueva cuenta");
    }
    public void decidirinputdecuenta(int d)
    {
        //cerrarsesion = false;
        cerrartienda = false;
        switch (d)
        {
            case 1:
                string em, c;
                Console.WriteLine("ingrese su email:");
                em = Console.ReadLine();
                Console.WriteLine("ingrese contraseña :");
                c = Console.ReadLine();
                int re = registr.verificaremailycontraseña(em,c);
                if (re==0)
                {
                    Console.WriteLine("Inicio de sesion sin problemas");
                    registr.pasardatosusuario(out user);
                    break;
                }
                 if (re == 1)
                {
                    Console.WriteLine("La constraseña no es la correcta");
                    break;
                }
                 if (re == -1)
                {
                    Console.WriteLine(" Tu email no es el correcto");
                    break;
                }
                
                

                break;
                
            case 2 :
                
                string  nom, rol;
                Console.Write("ingrese su nombre:");
                nom = Console.ReadLine();
               
                Console.WriteLine();
                Console.WriteLine(" Ingrese su email:");
                em = Console.ReadLine();
                Console.WriteLine("introduzca su contraseña");
                c = Console.ReadLine();
                Console.WriteLine("Intruduzca su rol:");
                rol = Console.ReadLine();
                usuario us = new usuario( nom, em, c, rol);

                if (registr.IniciarSesionCnueva(us))
                {
                    ingresarUsuario(us);
                    Console.WriteLine("agrego su cuenta de manera exitosa");
                }
                else Console.WriteLine("error ");
                
                
                break;
                
            default :
                Console.WriteLine("error desconocido intentelo de nuevo");
                break;
            
        }
    }


    public void mostrarcarrito()
    {
        if (carrito.estavacio())
        {
            Console.WriteLine("No tiene nada aun en tu carrito");
            return;
        }

        List<Carrito.carrito> mostrar = carrito.GetCarrito();

        foreach (Carrito.carrito p in mostrar)
        {
            Console.WriteLine($" PRODUCTO : {p.producto.conseguirnombre()} | CANTIDAD  :  {p.cantidad}  | PRECIO TOTAL : {(p.producto.conseguirprecio()*p.cantidad)}  ");
        }

    }

    public void mostrarfactura()
    {
        Console.WriteLine($"fecha: { cp.devolvertiempo()} ");
        
        Console.WriteLine($"Nombre : {carrito.devolverprocedencia()}");

        foreach (var item in carrito.GetCarrito())
        {
            Console.WriteLine($"{item.producto.conseguirnombre()} x{item.cantidad} - ${item.producto.conseguirprecio() * item.cantidad}");
        }
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"TOTAL A PAGAR: ${cp.devolvertotal()}");
        Console.WriteLine("=================================");
        
    }

    public void dedicidirparaeluser(int ch)
    {
        cerrartienda = false;
        switch (ch)
        {
            case 1:
                MostrarCatalogousuario();
                break;
                case 2:
                    mostrarcarrito();
                break;
                case 3:
                string prodagregar;
                int cantidadagre;
                    Console.WriteLine("ingrese el nombre del producto que quiere agregar a su carrito y su cantidad : ");
                    prodagregar = Console.ReadLine();
                    cantidadagre = int.Parse(Console.ReadLine());
                    Producto agregar = inventario.encontrarproducto(prodagregar);
                
                // aqui debe ir un verificador de cantidad pero no lo he hecho aun 
                
                    int resp = carrito.AgregarAlCarrito(agregar, cantidadagre);

                    if (resp == 1)
                    {
                        Console.WriteLine("SE ACTUALIZO EL PRODUCTO QUE YA TENIAS EN EL CARRITO");
                    }
                    if(resp==0)
                    {
                        Console.WriteLine("SE AGREGO NUEVO PRODUCTO AL CARRITO");
                    }
                
                
                    
                break;
                case 4:
                    
                Console.WriteLine("ingrese el nombre del producto que quiere agregar a su carrito y la cantidad a eliminar del producto : ");
                Console.WriteLine("(si ingresa 0 como cantidad , lo sacara de su carrito)");
                prodagregar = Console.ReadLine();
                cantidadagre = int.Parse(Console.ReadLine());
                agregar = inventario.encontrarproducto(prodagregar);

                resp = carrito.EliminarProducto(agregar, cantidadagre);

                if (resp == -2)
                {
                    Console.WriteLine("ese producto no existia en su carrito");
                }

                if (resp == 2)
                {
                    Console.WriteLine("SE ELIMINO DE MANERA COMPLETA EL PRODUCTO DE SU CARRITO");
                }

                if (resp == -1)
                {
                    Console.WriteLine("cantidad que usted ingreso a restar era mayor que la cantidad que tenia en el carrito");
                }

                if (resp == 1)
                {
                    Console.WriteLine("se le resto la cantidad sin ningun problema ");
                }

                if (resp == 0)
                {
                    Console.WriteLine("NO SE REALIZO NADA POR ALGUNA INCONSISTENCIA");
                }
                
                
                break;
                case 5:
                    // COMPRA
                    if (carrito.estavacio())
                    {
                        Console.WriteLine("tu carrito esta vacio no puedes llevar esta funcion");
                        break;
                    }

                    cp = new Compra(carrito);
                    
                    mostrarfactura();
                    
                break;
                case 6:
                    registr.CerrarSesion(user);
                break;
                case 7:
                cerrartienda = true;
                break;
                
                default:
                break;
        }
    }
    public void mostrardecidir()
    {
        if (user == null)
        {
            Console.WriteLine("error desconocido ");
            return;
        }
        if (user.rol.conseguirrol() == "ADMIN")
        {
            int choice = 0;
            while(choice != 9 ){
                mostrarinstruccionesadmin();
                Console.WriteLine("input : ");
                choice = int.Parse(Console.ReadLine());
                decidirelinputadmin(choice);
                if (choice == 10)
                {
                    break;
                }
            }
        }
        else
        {
            carrito = new Carrito(user.conseguirID());
            carrito.nombrarcliente(user.devolvernombre());
            int choice2 = 0;
            while (choice2 != 6)
            {
                mostrarinstruccionesuser();
                Console.WriteLine("input : ");
                choice2 = int.Parse(Console.ReadLine());
                dedicidirparaeluser(choice2);
                
                if (choice2 == 7) break;
            }
        }
    }

    
   

}