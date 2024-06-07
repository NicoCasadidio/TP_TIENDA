using System;

class Producto
{
    // Atributos de la clase Producto
    private string nombre;
    private double costo;
    private double precioVenta;
    private int stock;

    // Constructor de la clase Producto
    public Producto(string nombre, double costo, int stock)
    {
        // Verificar que el nombre y el costo no estén vacíos o sean negativos
        if (string.IsNullOrEmpty(nombre))
        {
            throw new ArgumentException("El nombre del producto no puede ser nulo o vacío.");
        }
        if (costo <= 0)
        {
            throw new ArgumentException("El costo del producto debe ser mayor que cero.");
        }

        this.nombre = nombre;
        this.costo = costo;
        this.stock = stock;
        // Calcular el precio de venta como costo + 30% del costo
        this.precioVenta = costo * 1.3;
    }

    // Propiedades para acceder a los atributos privados
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public double Costo
    {
        get { return costo; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("El costo del producto debe ser mayor que cero.");
            }
            costo = value;
        }
    }

    public double PrecioVenta
    {
        get { return precioVenta; }
    }

    public int Stock
    {
        get { return stock; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("El stock del producto no puede ser negativo.");
            }
            stock = value;
        }
    }
}
