using System;

namespace DIO.Bank.Classes
{
    public class Account
    {
        private TypeAccount type {get; set;}
        private double Balance {get; set;}
        private double Credit {get; set;}
        public string Name {get; set;}


        public Account(TypeAccount typeAccount, double balance, double credit, string name)
        {
            this.type = (TypeAccount) typeAccount;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw (double withdrawValue)
        {
            //Wtithdraw validation.
            if (this.Balance  - withdrawValue < (this.Credit *-1))
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }
            this.Balance-= withdrawValue;
            Console.WriteLine($"O Saldo da conta de {this.Name} é R$ {this.Balance}.");
            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;
            Console.WriteLine($"O Saldo da conta de {this.Name} é R$ {this.Balance}.");
        }

        public void Transfer(double transferValue, Account otherAccount)
        {
            if (this.Withdraw(transferValue))
            {
                otherAccount.Deposit(transferValue);   
            }            
        }

        public override string ToString()
        {
            string strdata = "";
            strdata += "TipoConta: "+ this.type + " | ";
            strdata += "Nome: "+ this.Name + " | ";
            strdata += "Saldo: "+ this.Balance + " | ";
            strdata += "Crédito Especial: "+ this.Credit;

            return strdata;
        }




    }
}