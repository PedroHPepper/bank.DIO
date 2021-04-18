using DIO.bank.Classes;
using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        static List<Account> accounts = new List<Account>();
        static void Main(string[] args)
        {
            Account account = new Account(name: "Pedro", balance: 0, credit: 0, accountType: Enum.AccountType.IndividualEntity);
            Console.WriteLine(account.ToString());
            string userOption = ObtainUserOptions();
            while(userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transference();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = ObtainUserOptions();
            }
            
        }


        private static string ObtainUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void Withdraw()
        {
            Console.WriteLine("Digite o índice da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            if(accounts.Count < accountIndex)
            {
                Console.WriteLine("Conta não encontrada!!");
                return;
            }

            Console.WriteLine("Digite o valor a ser sacado: ");
            double value = double.Parse(Console.ReadLine());
            accounts[accountIndex].Withdraw(value);
        }
        private static void Deposit()
        {
            Console.WriteLine("Digite o índice da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            if (accounts.Count < accountIndex)
            {
                Console.WriteLine("Conta não encontrada!!");
                return;
            }

            Console.WriteLine("Digite o valor a ser depositado: ");
            double value = double.Parse(Console.ReadLine());
            accounts[accountIndex].Deposit(value);
        }


        private static void Transference()
        {
            if(accounts.Count < 2)
            {
                Console.WriteLine("Favor, adicionar mais contas!");
                Console.WriteLine("Total de contas: {0}", accounts.Count);
                return;
            }
            Console.WriteLine("Digite o índice da conta de origem: ");
            int originAccountIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o índice da conta destino: ");
            int accountDestinyIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double value = double.Parse(Console.ReadLine());

            accounts[originAccountIndex].Transference(value, accounts[accountDestinyIndex]);
        }

        private static void ListAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada");
            }
            else
            {
                for (int i = 0; i < accounts.Count; i++)
                {
                    Console.WriteLine("#ID {0}: - ", i);
                    Console.WriteLine(accounts[i]);
                }
            }
        }

        private static void InsertAccount()
        {

            Console.WriteLine("Inserir nova da conta!");
            Console.WriteLine("Digite 1 para conta física ou 2 para jurídica:");
            int accountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:");
            string name = Console.ReadLine();

            Console.WriteLine("Saldo inicial: ");
            double inicialBalance = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito ");
            double credit = double.Parse(Console.ReadLine());

            Account account = new Account(accountType: (Enum.AccountType)accountType,
                                            name: name,
                                            balance: inicialBalance,
                                            credit: credit
                                        );
            accounts.Add(account);
        }
    }
}
