
public class Rectangulo 
{
    //Atributos
    public float Base {  get; set; }
    public float Altura { get; set; }

    //Constructor

    public Rectangulo(float base_, float altura) 
    {
        Base = base_;
        Altura = altura;
    }

    //Metodos

    public void Perimetro() 
    {
        Console.WriteLine($"El perimetro es:{Base * 2f + Altura * 2f}");
    }

    public void Area() 
    {
        float calculoArea = Base* Altura;
        Console.WriteLine($"El area es: {calculoArea}");
    }
}

