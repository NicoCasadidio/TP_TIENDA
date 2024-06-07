using System;

class Program
{
    static void Main(string[] args)
    {
        Tienda tienda = new Tienda();
        Carrito carrito = new Carrito();

        tienda.AgregarNuevoProducto("Manzana", 1.0, 50);
        tienda.AgregarNuevoProducto("Naranja", 1.5, 30);
        
        bool continuar = true;
        
        while (continuar)
        {
            Console.WriteLine("1. Mostrar productos");
            Console.WriteLine("2. Agregar producto al carrito");
            Console.WriteLine("3. Eliminar producto del carrito");
            Console.WriteLine("4. Ver carrito");
            Console.WriteLine("5. Cobrar");
            Console.WriteLine("6. Agregar nuevo producto a la tienda");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            
            switch (opcion)
            {
                case 1:
                    tienda.MostrarProductos();
                    break;
                case 2:
                    tienda.MostrarProductos();
                    Console.Write("Seleccione el número del producto a agregar: ");
                    int numProducto = int.Parse(Console.ReadLine());
                    Producto productoSeleccionado = tienda.SeleccionarProducto(numProducto);
                    Console.Write("Indique la cantidad a agregar: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    carrito.AgregarProducto(productoSeleccionado, cantidad);
                    break;
                case 3:
                    carrito.MostrarCarrito();
                    Console.Write("Seleccione el número del producto a eliminar: ");
                    int numProductoEliminar = int.Parse(Console.ReadLine());
                    Producto productoEliminar = carrito.ObtenerProductos()[numProductoEliminar - 1].Item1;
                    Console.Write("Indique la cantidad a eliminar: ");
                    int cantidadEliminar = int.Parse(Console.ReadLine());
                    carrito.EliminarProducto(productoEliminar, cantidadEliminar);
                    break;
                case 4:
                    carrito.MostrarCarrito();
                    break;
                case 5:
                    Console.Write("Ingrese la cantidad de dinero del cliente: ");
                    double dineroCliente = double.Parse(Console.ReadLine());
                    tienda.Cobrar(carrito, dineroCliente);
                    break;
                case 6:
                    Console.Write("Ingrese el nombre del nuevo producto: ");
                    string nombreNuevo = Console.ReadLine();
                    Console.Write("Ingrese el costo del nuevo producto: ");
                    double costoNuevo = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese el stock del nuevo producto: ");
                    int stockNuevo = int.Parse(Console.ReadLine());
                    tienda.AgregarNuevoProducto(nombreNuevo, costoNuevo, stockNuevo);
                    break;
                case 7:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
