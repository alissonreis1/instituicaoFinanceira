using System;
using controleContas;
using static controleContas.Conta;

public class Program
{
    static void Main(string[] args)
    {
        try
        {

            Banco banco1 = new Banco { Numero = 1, Nome = "Banco XYZ" };
            Agencia agencia1 = new Agencia { Numero = 123, CEP = "12345-678", Telefone = "123-456-7890", Banco = banco1 };
            Cliente cliente1 = new Cliente("Alfredo", 2003, "12345678910");
            Cliente cliente2 = new Cliente("Pedro", 2000, "78942587652");
            Conta conta1 = new Conta(123456, 1000, cliente1, agencia1);
            Conta conta2 = new Conta(654321, 11, cliente2, agencia1);
            Console.WriteLine("O saldo inicial da conta {0} é {1}", conta1.Numero, conta1.Saldo);
            Console.WriteLine("O saldo inicial da conta {0} é {1}", conta2.Numero, conta2.Saldo);

            conta1.Depositar(1000);
            Console.WriteLine("O saldo atual da conta {0} é {1}", conta1.Numero, conta1.Saldo);
            Console.WriteLine("O saldo atual da conta {0} é {1}", conta2.Numero, conta2.Saldo);

            conta1.Transferir(conta2, 300m);
            Console.WriteLine("O saldo atual da conta {0} é {1}", conta1.Numero, conta1.Saldo);
            Console.WriteLine("O saldo atual da conta {0} é {1}", conta2.Numero, conta2.Saldo);
            Console.WriteLine("O cliente da conta {0} é {1}", conta1.Numero, conta1.Titular.Nome);

            decimal saldoTotal = conta1.Saldo + conta2.Saldo;
            Console.WriteLine("O saldo total das duas contas é {0}", saldoTotal);

            long numeroContaComMaiorSaldo = Conta.ObterNumeroContaComMaiorSaldo();
            Console.WriteLine("O número da conta com o maior saldo é {0}", numeroContaComMaiorSaldo);

            decimal saldoInicialTotalGeral = Conta.ObterSaldoTotalGeral();
            Console.WriteLine("O saldo inicial total geral é {0}", saldoInicialTotalGeral);

            
            Console.WriteLine("Informações da Conta:");
            Console.WriteLine($"Número da Conta: {conta1.Numero}");
            Console.WriteLine($"Saldo da Conta: {conta1.Saldo:C}");
            Console.WriteLine($"Titular da Conta: {conta1.Titular.Nome}");

            
            Console.WriteLine("\nInformações da Agência:");
            Console.WriteLine($"Número da Agência: {conta1.GetAgencia().Numero}");
            Console.WriteLine($"CEP da Agência: {conta1.GetAgencia().CEP}");
            Console.WriteLine($"Telefone da Agência: {conta1.GetAgencia().Telefone}");

            
            Console.WriteLine("\nInformações do Banco:");
            Console.WriteLine($"Nome do Banco: {conta1.GetAgencia().Banco.Nome}");
            Console.WriteLine($"Número do Banco: {conta1.GetAgencia().Banco.Numero}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}