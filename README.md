Para compilar y probar el programa utilizamos Mono C# Compiler.

Para generar el archivo ejecutable llamado "MiTienda.exe":
mcs -out:MiTienda.exe Producto.cs Carrito.cs Tienda.cs Main.cs

Para ejecutar el archivo ejecutable previamente generado:
mono MiTienda.exe
