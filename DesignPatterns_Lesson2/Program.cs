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