using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bank_Proj
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int iContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int iContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[iContaOrigem].Transferir(valorTransferencia, listaContas[iContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorSaque);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Contas Listadas: ");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhum conta cadastrada.");
                return;
            }
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write($"#{i} -");
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Insira uma nova conta:");

            Console.Write("Digite 1 para onta fisica ou 2 para conta jurídica: ");
            int entradaConta = int.Parse(Console.ReadLine());
            while (entradaConta != 1 && entradaConta != 2)
            {
                Console.WriteLine("Número invalido!");
                Console.WriteLine("Por favor, digite 1 para conta física ou 2 para conta jurídica: ");
                entradaConta = int.Parse(Console.ReadLine());
            }

            Console.Write("Digite o nome do cliente com pelo menos 3 digitos: ");
            string entradaNome = Console.ReadLine();
            if (entradaNome == " " || entradaNome.Length < 3)
            {
                Console.WriteLine("Nome inválido!");
                Console.WriteLine("Por favor, digite o nome do cliente com pelo menos 3 digitos: ");
                entradaNome = (Console.ReadLine());
            }

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            if (entradaSaldo < 0)
            {
                Console.WriteLine("Saldo não pode ser negativo!");
                Console.WriteLine("Por favor, digite um valor maior do que ZERO.");
            }

            Console.Write("Digite o crédito desejado: ");
            double entradaCredito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao seu banco!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }
    }
}
