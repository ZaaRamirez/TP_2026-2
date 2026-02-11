public class Persona
{
    //Atributos
    public string Nombre { get; set; } //Encapsulamiento
    public int Edad { get; set; }
    /*public string Nombre2 
    {
        get { return Nombre; }
        set { Edad = Edad; }
    }*/

    //Constructor
    public Persona(string nombre, int edad) 
    {
        Nombre = nombre;
        Edad = edad;
    }
    //Metodos

}
