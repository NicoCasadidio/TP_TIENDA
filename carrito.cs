using System;
using System.Collections.Generic;

class Carrito
{
    private List<Tuple<Producto, int>> productos;

    public Carrito()
    {
        productos = new List<Tuple<Producto, int>>();
    }

    public void AgregarProducto(Producto producto, int cantidad)
    {
        if (producto == null)
        {
            throw new ArgumentException("El producto no puede ser nulo.");
        }
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad debe ser mayor que cero.");
        }
        if (producto.Stock < cantidad)
        {
            throw new ArgumentException("No hay suficiente stock para agregar al carrito.");
        }

        int index = productos.FindIndex(p => p.Item1 == producto);
        if (index != -1)
        {
            productos[index] = new Tuple<Producto, int>(producto, productos[index].Item2 + cantidad);
        }
        else
        {
            productos.Add(new Tuple<Producto, int>(producto, cantidad));
        }

        producto.Stock -= cantidad; // Actualiza el stock del producto
    }

    public void EliminarProducto(Producto producto, int cantidad)
    {
        if (producto == null)
        {
            throw new ArgumentException("El producto no puede ser nulo.");
        }
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad debe ser mayor que cero.");
        }
        int index = productos.FindIndex(p => p.Item1 == producto);
        if (index == -1)
        {
            throw new ArgumentException("El producto no se encuentra en el carrito.");
        }
        if (productos[index].Item2 < cantidad)
        {
            throw new ArgumentException("No hay suficiente cantidad del producto en el carrito para eliminar.");
        }

        producto.Stock += cantidad; // Devuelve el stock del producto

        if (productos[index].Item2 == cantidad)
        {
            productos.RemoveAt(index);
        }
        else
        {
            productos[index] = new Tuple<Producto, int>(producto, productos[index].Item2 - cantidad);
        }
    }

    public double CalcularSubtotal()
    {
        double subtotal = 0;

        foreach (var item in productos)
        {
            subtotal += item.Item1.PrecioVenta * item.Item2;
        }

        return subtotal;
    }

    public List<Tuple<Producto, int>> ObtenerProductos()
    {
        return productos;
    }

    public void MostrarCarrito()
    {
        foreach (var item in productos)
        {
            Console.WriteLine($"{item.Item1.Nombre} - Cantidad: {item.Item2} - Precio Unitario: {item.Item1.PrecioVenta:C} - Total: {item.Item1.PrecioVenta * item.Item2:C}");
        }
        Console.WriteLine($"Subtotal: {CalcularSubtotal():C}");
    }

    public void VaciarCarrito()
    {
        productos.Clear();
    }
}
