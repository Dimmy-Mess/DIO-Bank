using System;
using System.Collections.Generic;
using DIO.Bank.Classes;

namespace DIO.Bank
{
    class Program
    {
        static List<Account> listAccount = new List<Account>(); 
        static void Main(string[] args)
        {
            string userOption = ObtainUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccount();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        AccountTransfer();
                        break;
                    case "4":
                        AccountWithdraw();
                        break;
                    case "5":
                        AccountDeposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Digite uma opção válida!");
                }

                userOption = ObtainUserOption();
            }
            Console.WriteLine("Obrigado por utilizar os nossos serviços!");
            Console.ReadLine();



        }

        private static void InsertAccount()
        {
            Console.WriteLine("Inserir Conta");

            Console.WriteLine("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica:");
            int enterType = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Digite o nome do Cliente:");
            string enterName = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial");
            double enterBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito Inicial do Cliente:");
            double enterCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(typeAccount: (TypeAccount)enterType,
                                             balance: enterBalance,
                                             credit: enterCredit,
                                             name: enterName);

            listAccount.Add(newAccount);

        }

        private static void ListAccount()
        {
            Console.WriteLine("CONTAS:");

            if (listAccount.Count == 0)
            {
                Console.WriteLine("Não existem contas disponíveis");
                return;
            }

            for (int i = 0; i < listAccount.Count; i++)
            {
                Account account = listAccount[i];
                Console.WriteLine($"#{i} - {account}");
            }
        }

        private static void AccountWithdraw()
        {
            Console.WriteLine("SAQUE");
            
            Console.WriteLine("Digite o número da conta da qual deseja sacar: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a ser sacado: ");
            double value = double.Parse(Console.ReadLine());

            listAccount[accountNumber].Withdraw(value);
        }

        private static void AccountDeposit()
        {
            Console.WriteLine("DEPÓSITO");
            Console.WriteLine("Insira o número da conta para depósito: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o valor a ser depositado: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccount[accountNumber].Deposit(depositValue);
        }

        private static void AccountTransfer()
        {
            Console.WriteLine("TRANSFERÊNCIA:");

            Console.WriteLine("Escolha a Conta de origem:");
            int originAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual valor deseja transferir? ");
            double transferValue = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o número da Conta destino: ");
            int receiveAccount = int.Parse(Console.ReadLine());

            listAccount[originAccount].Transfer(transferValue,listAccount[receiveAccount]);
        }

        private static string ObtainUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank - Tudo para você!");
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Criar uma nova conta");
            Console.WriteLine("3 - Transferência de Valores");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Depósito");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
