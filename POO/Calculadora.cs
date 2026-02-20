//Programa principal

/*Calculadora calculadora1 = new Calculadora(5,2);
Calculadora calculadora2 = new Calculadora(12,8);

float resultado1 = calculadora1.Division();
float resultado2 = calculadora2.Division();

Console.WriteLine(resultado1);
Console.WriteLine(resultado2);

//Get

Console.WriteLine($"El primer numero de la primer cacluladora : {calculadora1.Numero1}");
Console.WriteLine($"El primer numero de la primer cacluladora : {calculadora2.Numero1}");

//Set
calculadora1.Numero1 = 8;
calculadora2.Numero1 = 6;

Console.WriteLine($"El primer numero de la primer cacluladora : {calculadora1.Numero1}");
Console.WriteLine($"El primer numero de la primer cacluladora : {calculadora2.Numero1}");*/

//Funcion factorial
/*
Calculadora calculadora2 = new Calculadora(6, 8);
CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(5, 2);
Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Suma()}");

Console.WriteLine($"El resultado caculadora Basica : {calculadora2.Suma(3)}");


Calculadora calculadora3 = calculadora2 + calculadora1;

Console.WriteLine($"Calculadora3 ({calculadora3.Numero1}, {calculadora3.Numero2})");
calculadoraCientifica.MensajeC();*/

Console.WriteLine("Ingresa el primer numero a operar: ");
int num1 = int.Parse(Console.ReadLine() ?? "");
Console.WriteLine("Ingresa el segundo numero a operar: ");
int num2 = int.Parse(Console.ReadLine() ?? "");

Console.WriteLine("Presiona 1- Calculadora Basica");
Console.WriteLine("Presiona 2- Calculadora Cientifica");
int sel = int.Parse(Console.ReadLine() ?? "");

if (sel == 1) 
{
    Calculadora calculadora1 = new Calculadora(num1, num2);
    Console.WriteLine("1- Suma");
    Console.WriteLine("2- Resta");
    Console.WriteLine("3- Multiplicar");
    Console.WriteLine("4- Dividir");
    sel = int.Parse(Console.ReadLine() ?? "");

    switch (sel) 
    {
        case 1:
            Console.WriteLine($"El resultado caculadora Basica : {calculadora1.Suma()}");
            break;
        case 2:
            Console.WriteLine($"El resultado caculadora Basica : {calculadora1.Resta()}");
            break;
        case 3:
            Console.WriteLine($"El resultado caculadora Basica : {calculadora1.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"El resultado caculadora Basica : {calculadora1.Division()}");
            break;
        default:
            Console.WriteLine("Seleccion incorrecta");
            break;
    }

} 
else if(sel == 2)
{
    CalculadoraCientifica calculadoraCientifica = new CalculadoraCientifica(num1, num2);
    Console.WriteLine("1- Suma");
    Console.WriteLine("2- Resta");
    Console.WriteLine("3- Multiplicar");
    Console.WriteLine("4- Dividir");
    Console.WriteLine("5- Logaritmo");
    Console.WriteLine("6- Raiz cuadrada");
    Console.WriteLine("7- Factorial");

    sel = int.Parse(Console.ReadLine() ?? "");

    switch (sel) 
    {
        case 1:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Suma()}");
            break;
        case 2:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Resta()}");
            break;
        case 3:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Multiplicacion()}");
            break;
        case 4:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Division()}");
            break;
        case 5:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Logaritmo()}");
            break;
        case 6:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.RaizCuadrada()}");
            break;
        case 7:
            Console.WriteLine($"El resultado caculadora Cientifica : {calculadoraCientifica.Factorial()}");
            break;
        default:
            Console.WriteLine("Seleccion incorrecta");
            break;
    }

}


//Clases

//Calculadora basica que solo opera 2 numeros enteros

public class Calculadora 
{
    //Atributos
    public int Numero1 {  get; set; }
    public int Numero2 { get; set; }

    //Atributo privado
    private int Resultado;
    private string mensaje = "Mensaje privado";
    
    //Constructor
    public Calculadora(int numero1, int numero2) 
    {
        Numero1 = numero1;
        Numero2 = numero2;
    }

    //Metodos

    public virtual int Suma() 
    {
        Resultado = Numero1 + Numero2;
        return Resultado;
    }

    //Metodo privado

    private void MostrarMensaje() 
    {
        Console.WriteLine(mensaje);
    }

    //Metodo protegido

    protected void Mensaje()
    {
        MostrarMensaje();
    }

    //Sobrecarga del metodo Suma
    public virtual int Suma(int num3) 
    {
        return Numero1 + Numero2 + num3;
    }
    public int Resta() 
    {
        return Numero1 - Numero2;
    }
    public int Multiplicacion()
    {
        return Numero1 * Numero2;
    }
    public float Division()
    {
        if (Numero2 == 0) 
        {
            Console.WriteLine("MathError");
            return 0;
        }

        return (float) Numero1 / Numero2;
    }

    //Sobrecarga del operador +

    public static Calculadora operator + (Calculadora calc1, Calculadora cal2) 
    {
        return new Calculadora(calc1.Numero1 + cal2.Numero1,calc1.Numero2 + cal2.Numero2);
    }
}


//Clase Hija

public class CalculadoraCientifica : Calculadora
{
    //Atributos
    
    //Constructor
    public CalculadoraCientifica(int num1, int num2) : base(num1, num2)
    {
    }


    //Metodos

    public double Logaritmo() 
    {
        return MathF.Log(Numero1);
    }

    public double RaizCuadrada() 
    {
        return MathF.Sqrt(Numero2);
    }

    //Override cambia el metodo heredado

    public override int Suma() 
    {
        int resultado = base.Suma();
        return resultado * resultado;
            
    }

    public void MensajeC() 
    {
        base.Mensaje();
    }

    public int Factorial() 
    {
        if (Numero1 == 0 || Numero1 == 1) 
        {
            return 1;
        } 
        else if (Numero1 < 0) 
        {
            Console.WriteLine("No es posible el factorial de numero negativo");
            return 0;
        } 
        else 
        {
            int Fct = 1;

            for (int i = 2; i <= Numero1; i++) {
                Fct = Fct * i;
            }
            return Fct;
        }

    }
}