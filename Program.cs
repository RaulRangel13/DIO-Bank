using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
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

            Console.WriteLine("Obrigado por utilizar nossos servicos");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite a conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("digite a conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de transferencia");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("digite o valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Despositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("digite o valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 - para conta fisica ou 2 - para juridica");
            int entaradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            string entradaNome = Console.ReadLine();
            
            Console.WriteLine("Digite o Saldo inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o credito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entaradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static void ListarContas(){
            if (listContas.Count == 0){
                Console.Write("Nunhuma cont aencontrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Rangel Bank bem vindo");
            Console.WriteLine("Informe  aopcao desejada");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
