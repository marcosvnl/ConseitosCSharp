using System;
using System.Globalization;

namespace CaixaEletronico
{
    class Program
    {
        private static object resposta;

        static void Main(string[] args)
        {
            double saldo = 0;
            
            Console.Write("Entre o número da conta: ");
            int conta = int.Parse(Console.ReadLine());

            Console.Write("Entre o Titular da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Haverá depósito inicial (S/N)? ");
            string resposta = Console.ReadLine();

            ContaBancaria c = new ContaBancaria(conta, nome, resposta);
            c.Resposta = resposta;
            c.VerificarResposta();
            if (resposta[0].ToString().ToUpper() == "S")
            {
                Console.Write("Entre com o valor de depósito inicial: ");
                saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }
            c.DepositoInicial(saldo);

            Console.WriteLine($"Dados da conta: \n{c}");

            Console.Write("Entre um valor para depósito: ");
            saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            c.Deposito(saldo);

            Console.WriteLine($"Dados atualizados: \n{c}");

            Console.Write("Entre um valor para saque: ");
            saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            c.Saque(saldo);

            Console.WriteLine($"Dados atualizados: \n{c}");
        }
    }
}
