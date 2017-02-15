using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop3_EnhancingClassPart2
{
    class BankTest2
    {
        static void Main(string[] args)
        {
            Customer y = new Customer("Tan Ah Kow", "20, Seaside Road", "XXX20", new DateTime(1989, 10, 11));
            Customer z = new Customer("Kim Lee Keng", "2, Rich View", "XXX9F", new DateTime(1993, 4, 25));
            Account a = new Account("001-001-001", y, 2000);
            Account b = new Account("001-001-002", z, 5000);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
            a.Deposit(100);
            Console.WriteLine(a.Show());
            a.Withdraw(200);
            Console.WriteLine(a.Show());
            a.TransferTo(300, b);
            Console.WriteLine(a.Show());
            Console.WriteLine(b.Show());
        }
    }

    class Customer
    {
        //attributes
        string name;
        string address;
        string nric;
        DateTime dob = new DateTime();
        int age;

        //prroperty
        public int GetAge()
        {
            return age;
        }

        //constructor
        public Customer(string name, string address, string nric, DateTime dobIn)
        {
            this.name = name;
            this.address = address;
            this.nric = nric;
            dob = dobIn;
            age = 2017-dob.Year;
        }

        public string Showcustomer()
        {
            return (String.Format(name+"\t"+address+"\t"+nric+"\t"+"{0}",age));
        }

    }

    class Account
    {
        //attributes
        string accountNum;
        double initialAmt, currentAmt;
        Customer data;

        //properties


        //constructor
        public Account(string accountNum, Customer data, double initialAmt)
        {
            this.accountNum = accountNum;
            this.initialAmt = initialAmt;
            this.data = data;
            currentAmt = initialAmt;
        }

        //methods
        public void Deposit(double amount)
        {
            currentAmt = initialAmt + amount;
        }

        public void Withdraw(double amount)
        {
            currentAmt -= amount;
        }

        public void TransferTo(double amount, Account Another)
        {
            Withdraw(amount);
            Another.Deposit(amount);
        }
        public string Show()
        {
            return (String.Format(accountNum + "\t" + data.Showcustomer() + "\t" + "{0}", currentAmt));
        }
    }
}
