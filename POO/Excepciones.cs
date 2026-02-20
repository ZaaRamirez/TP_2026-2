//Programa para ver excepciones

/*int divisor = 0;
//int resultado = 10 / divisor; //Lanza excepcion


try 
{
    int resultado = 10 / 5;
} 
catch (DivideByZeroException ex) 
{ 
    Console.WriteLine(ex.Message);
    Console.WriteLine("Noi se puede divir/ elige otro numero");
}
finally 
{
    Console.WriteLine("Bloque que siempre se ejecuta");
}*/


try 
{
    Console.WriteLine("Introduce un numero entero positivo: ");
    int numero = int.Parse(Console.ReadLine() ?? "");

    if (numero <0) 
    {
        throw new ArgumentException("El numero no puede ser negativo");
    }
} 
catch (FormatException ex) 
{ 
    Console.WriteLine("Escribiste algo que no es un numero");
} 
catch (Exception ex) 
{
    Console.WriteLine(ex.Message);
}
finally 
{
    Console.WriteLine("Siempre se ejecuta");
}
