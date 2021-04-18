using DIO.bank.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.bank.Classes
{
    public class Account
    {
        private string Name { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private AccountType AccountType { get; set; }

        public Account(string name, double balance, double credit, AccountType accountType)
        {
            Name = name;
            Balance = balance;
            Credit = credit;
            AccountType = accountType;
        }

        public bool Withdraw(double withdrawValue)
        {
            if ((Balance - withdrawValue) < (Credit*-1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            Balance -= withdrawValue;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", Name, Balance);
            return true;
        }

        public void Deposit(double depositValue)
        {
            Balance += depositValue;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", Name, Balance);
        }

        public void Transference(double transferenceValue, Account accountDestiny)
        {
            if (Withdraw(transferenceValue))
            {
                accountDestiny.Deposit(transferenceValue);
            }
        }

        
        public override string ToString()
        {
            string returnString = "";
            returnString += "Tipo de conta" + AccountType + " | ";
            returnString += "Nome" + Name + " | ";
            returnString += "Saldo" + Balance + " | ";
            returnString += "Crédito" + Credit;


            return returnString;
        }
    }
}
