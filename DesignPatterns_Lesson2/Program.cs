namespace SRP_Before
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public void UpdateCustomerInfo(string newName, string newEmail)
        {
            Name = newName;
            Email = newEmail;
        }

        public void SendEmailNotification(string message)
        {
            // SendEmailNotification

        }
    }
}

namespace SRP_After
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CustomerManager
    {
        public void UpdateCustomerInfo(Customer customer, string newName, string newEmail)
        {
            customer.Name = newName;
            customer.Email = newEmail;
        }
    }

    public class EmailSender
    {
        public void SendEmailNotification(Customer customer, string message)
        {
            // SendEmailNotification
        }
    }
}

namespace OCP_Before
{
    public class PaymentProcessor
    {
        public void ProcessPayment(string paymentMethod, double amount)
        {
            if (paymentMethod.Equals("CreditCard", StringComparison.OrdinalIgnoreCase))
            {
                // Process creditcard payment
            }
            else if (paymentMethod.Equals("PayPal", StringComparison.OrdinalIgnoreCase))
            {
                // Process PayPal payment
            }
            else
            {
                throw new Exception("Error payment method");
            }
        }
    }
}

namespace OCP_After
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            // Process creditcard payment
        }
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            // Process PayPal payment
        }
    }

    public class PaymentProcessor
    {
        public void ProcessPayment(IPaymentProcessor paymentProcessor, double amount)
        {
            paymentProcessor.ProcessPayment(amount);
        }
    }
}

namespace Liskov
{
    class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("A bird can fly");
        }

        public virtual void Eat()
        {
            Console.WriteLine("A bird can eat");
        }
    }

    // Derived class 1
    class Sparrow : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("A sparrow is flying");
        }

        public override void Eat()
        {
            Console.WriteLine("A sparrow is eating");
        }
    }

    // Derived class 2
    class Penguin : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Penguins can't fly");
        }

        public override void Eat()
        {
            Console.WriteLine("A penguin is eating");
        }
    }
}

namespace ISP
{
    using System;

    // SOLID-in I prinsipine esasen interfacein daxilindeki metodlardan biri eger implemet edilmis classlarin 
    //birinde no Exception gotururse onda o interfacei parcalamaq lazimdi.

    //Ona gore ICaDo interfaceni 2 interface-e parcaladiq.

    //public interface ICanDo
    //{
    //    void Fly();
    //    void Swim();
    //}
    public interface ICanFly
    {
        void Fly();
    }

    public interface ICanSwim
    {
        void Swim();
    }

    public class Bird : ICanFly
    {
        public void Fly()
        {
            Console.WriteLine("The bird is flying.");
        }
    }

    public class Fish : ICanSwim
    {
        public void Swim()
        {
            Console.WriteLine("The fish is swimming.");
        }
    }


    class Program
    {
        static void Main()
        {
            Bird bird = new Bird();
            bird.Fly();

            Fish fish = new Fish();
            fish.Swim();

        }
    }
}

namespace DIP
{
    public interface IMessage
    {
        string GetMessage();
    }

    public class EmailMessage : IMessage
    {
        public string GetMessage()
        {
            return "Email message";
        }
    }

    public class SMSMessage : IMessage
    {
        public string GetMessage()
        {
            return "SMS message";
        }
    }

    public class Notification
    {
        private readonly IMessage message;

        public Notification(IMessage message)
        {
            this.message = message;
        }

        public void SendNotification()
        {
            string messageContent = message.GetMessage();
            Console.WriteLine($"Notification: {messageContent}");
        }
    }
    class Program
    {
        static void Main()
        {
            IMessage emailMessage = new EmailMessage();
            Notification emailNotification = new Notification(emailMessage);
            emailNotification.SendNotification();

            IMessage smsMessage = new SMSMessage();
            Notification smsNotification = new Notification(smsMessage);
            smsNotification.SendNotification();
        }
    }
}