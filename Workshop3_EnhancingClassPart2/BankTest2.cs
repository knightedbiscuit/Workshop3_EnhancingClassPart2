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
        public string Name
        {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string NRIC
        {
            get
            {
                return nric;
            }
        }

        public int Age
        {
            get {
                return age;
            }
        }

        //constructor
        public Customer(string name, string address, string nric, DateTime dobIn)
        {
            this.name = name;
            this.address = address;
            this.nric = nric;
            dob = dobIn;
            age = DateTime.Now.Year-dob.Year;
        }

        public Customer() : this("NoName","NoAddress","NoNRIC", new DateTime(1900,1,1))
        { }

        public string Showcustomer()
        {
            return (String.Format(name+"\t\t"+address+"\t\t"+nric+"\t\t"+"{0}",age));
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

        public Account()
            : this("xxx-xxx-xxx", new Customer(), 0)
        { }

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
            return (String.Format(accountNum + "\t\t" + data.Showcustomer() + "\t\t" + "{0}", currentAmt));
        }
    }
}
