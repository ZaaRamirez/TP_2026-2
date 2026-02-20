//Programa principal banco

Banco banco = new Banco();
char repetir = 'n';
do 
{
    try {
        CuentaBancaria cuentaOrigen = banco.BuscarCuenta("123456");

        Console.WriteLine("Bienvenido al banco, selecciona:");
        Console.WriteLine("1- Depositar");
        Console.WriteLine("2- Retirar");
        Console.WriteLine("3- Transferir");
        int sel = int.Parse(Console.ReadLine() ?? "");

        switch (sel) 
        {
            case 1:

                Console.WriteLine($"Saldo inicial: ${cuentaOrigen.Saldo}");
                Console.WriteLine("Escribe el saldo a depositar");
                decimal deposito = decimal.Parse(Console.ReadLine() ?? "");
                cuentaOrigen.Depositar(deposito);

                break;
            case 2:
                Console.WriteLine($"Saldo inicial: ${cuentaOrigen.Saldo}");
                Console.WriteLine("Escribe el saldo a retirar");
                decimal retiro = decimal.Parse(Console.ReadLine() ?? "");
                cuentaOrigen.Depositar(retiro);

                break;
            case 3:
                //Tranferencia
                Console.WriteLine($"Saldo inicial: ${cuentaOrigen.Saldo}");
                Console.WriteLine("Escribe la cuenta destino para transferir:");
                CuentaBancaria cuentaDestino = banco.BuscarCuenta(Console.ReadLine() ?? "");
                Console.WriteLine("Escribe la cantidad para transferir:");
                decimal cantidad = decimal.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Haciendo transferencia:");
                cuentaOrigen.Transferir(cuentaDestino, cantidad);
                Console.WriteLine($"Saldo final: ${cuentaOrigen.Saldo}");
                break;

            default:
                Console.WriteLine("Operacion no valida");
                break;
        }

        Console.WriteLine("Escribe Y para realizar más operaciones:");
        repetir = char.Parse(Console.ReadLine()??"");

    } 
    catch (CuentaNoEncontradaException ex) {
        Console.WriteLine(ex.Message);
    } 
    catch (SaldoInsuficienteException ex) {
        Console.WriteLine(ex.Message);
    } 
    catch (DepositoInvalidoException ex) {
        Console.WriteLine(ex.Message);
    } 
    catch (Exception ex) 
    {
        Console.WriteLine(ex.Message);
    }

} while (repetir == 'y' || repetir == 'Y');
    



class SaldoInsuficienteException : Exception 
{
    //Construtor
    public SaldoInsuficienteException(string mensaje) : base(mensaje) { }
}
class CuentaNoEncontradaException : Exception 
{
    //Construtor
    public CuentaNoEncontradaException(string mensaje) : base(mensaje) { }
}
class DepositoInvalidoException : Exception 
{
    //Construtor
    public DepositoInvalidoException(string mensaje) : base(mensaje) { }
}

//Clases del Banco

public class CuentaBancaria 
{
    //Atributos

    public string NumeroCuenta { get; }
    public decimal Saldo { get; set; }

    //Constructor

    public CuentaBancaria(string numeroCuenta, decimal saldo) 
    {
        NumeroCuenta = numeroCuenta;
        Saldo = saldo;
    }

    //Metodos

    public void Depositar(decimal cantidad) 
    {
        if (cantidad <0) 
        {
            throw new DepositoInvalidoException("No puedes depositar " +
                "cantidades negativas");
        }

        Saldo += cantidad;
        //Saldo = Saldo + cantidad;
    }

    public void Retirar(decimal cantidad) 
    {
        if (cantidad > Saldo) 
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para" +
                " la operacion");
        }

        Saldo -= cantidad;
        //Saldo = Saldo + cantidad;
    }

    public void Transferir(CuentaBancaria destino,decimal cantidad) 
    {
        if (destino == null) 
        {
            throw new CuentaNoEncontradaException("Cuenta no encontrada");
        }

        Retirar(cantidad);
        destino.Depositar(cantidad);
    }
}

public class Banco 
{
    //Atributos
    private CuentaBancaria[] cuentas;

    //Constructor

    public Banco() 
    {
        cuentas = new CuentaBancaria[]
        {
            new CuentaBancaria("123456",6),
            new CuentaBancaria("789456",20),
            new CuentaBancaria("741852",10000),
        };
    }

    //Metodos

    public CuentaBancaria BuscarCuenta(string numeroCuenta) 
    {
        foreach (CuentaBancaria cuenta in cuentas) 
        {
            if (cuenta.NumeroCuenta == numeroCuenta) 
            {
                return cuenta;
            }
        }

        throw new CuentaNoEncontradaException("Cuenta no encontrada");
    }

}
