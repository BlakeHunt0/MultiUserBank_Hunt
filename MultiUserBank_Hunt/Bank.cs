using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Hunt
{
    internal class Bank
    {
        //private variables
        private string[] users = { "jlennon", "pmccartney", "gharrison", "rstarr" };
        private string[] pass = { "johnny", "pauly", "georgy", "ringoy" };
        private double[] checking = { 1250, 2500, 3000, 1001 };
        private int i = -1;
        private const double bankMun = 10000;

        public double wBankMun;

        //check login
        public string Login(string User, string Pass)
        {
            int p = 0;
            if (p < 4)
            {
                if (User == users[p] && Pass == pass[p])
                {
                    i = p;
                    p++;
                    return "Login Successful";
                }
            }
            return "Login Failed";
        }

        //give balance
        public double Balance()
        {
            return checking[i];
        }

        //deposit
        public double Deposit(double amount)
        {
            checking[i] = (checking[i] + amount);
            wBankMun = wBankMun + amount;
            return checking[i];
        }

        //withdraw
        public double Withdraw(double amount)
        {
            checking[i] = (checking[i] - amount);
            wBankMun = wBankMun - amount;
            return checking[i];
        }

        public string DisplayName()
        {
            return users[i];
        }

        public int AcctNum()
        {
            return i;
        }

        public double BankBal()
        {
            i = 0;
            double bankBal;
            if (i < 4)
            {
                bankBal = bankMun + checking[i];
                i++;
            }
            return bankMun;
        }
    }
}
