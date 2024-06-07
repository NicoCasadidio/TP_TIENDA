using System;
using System.Collections.Generic;

class Tienda
{
    private List<Producto> productos;
    private double dineroEnCaja;

    public Tienda()
    {
        productos = new List<Producto>();
        dineroEnCaja = 0;
    }

    public void AgregarProductoExistente(Producto producto)
    {
        if (producto == null)
        {
            throw new ArgumentException("El producto no puede ser nulo.");
        }

        productos.Add(producto);
    }

    public void AgregarNuevoProducto(string nombre, double costo, int stock)
    {
        Producto nuevoProducto = new Producto(nombre, costo, stock);
        productos.Add(nuevoProducto);
    }

    public void MostrarProductos()
    {
        for (int i = 0; i < productos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - Precio: {productos[i].PrecioVenta:C} - Stock: {productos[i].Stock}");
        }
    }

    public Producto SeleccionarProducto(int indice)
    {
        if (indice < 1 || indice > productos.Count)
        {
            throw new ArgumentException("Índice de producto no válido.");
        }

        return productos[indice - 1];
    }

    public void Cobrar(Carrito carrito, double dineroCliente)
    {
        double subtotal = carrito.CalcularSubtotal();
        if (dineroCliente < subtotal)
        {
            throw new ArgumentException("Dinero insuficiente para realizar la compra.");
        }

        // No es necesario actualizar el stock aquí porque ya se ha actualizado al agregar al carrito

        double vuelto = dineroCliente - subtotal;
        dineroEnCaja += subtotal;
        carrito.VaciarCarrito(); // Vacía el carrito después de cobrar
        Console.WriteLine($"Compra realizada con éxito. El vuelto es: {vuelto:C}");
    }

    public double DineroEnCaja
    {
        get { return dineroEnCaja; }
    }
}
