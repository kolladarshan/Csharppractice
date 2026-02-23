using System;
using System.Collections.Generic; 
namespace Cash
{
class Payment
{
    public double Amount;
 
    public virtual void Pay()
    {
        Console.WriteLine("Processing generic payment...");
    }
} 
class UPI : Payment
{
    public string UpiId;

    public override void Pay()
    {
        Console.WriteLine("Paid ₹" + Amount + " using UPI ID: " + UpiId);
    }
}
 
class Card : Payment
{
    public string CardNumber;

    public override void Pay()
    {
        Console.WriteLine("Paid ₹" + Amount + " using Card ending: " 
                          + CardNumber.Substring(CardNumber.Length - 4));
    }
} 
class Cash : Payment
{
    public override void Pay()
    {
        Console.WriteLine("Paid ₹" + Amount + " using Cash");
    }
}
 
class Program
{
    static void Main(string[] args)
    {
        List<Payment> payments = new List<Payment>();

        Console.WriteLine("Choose Payment Method");
        Console.WriteLine("1. UPI");
        Console.WriteLine("2. Card");
        Console.WriteLine("3. Cash");

        Console.Write("Enter choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter amount: ");
        double amt = Convert.ToDouble(Console.ReadLine());

        if (choice == 1)
        {
            UPI upi = new UPI();
            upi.Amount = amt;

            Console.Write("Enter UPI ID: ");
            upi.UpiId = Console.ReadLine();

            payments.Add(upi);
        }
        else if (choice == 2)
        {
            Card card = new Card();
            card.Amount = amt;

            Console.Write("Enter Card Number: ");
            card.CardNumber = Console.ReadLine();

            payments.Add(card);
        }
        else
        {
            Cash cash = new Cash();
            cash.Amount = amt;

            payments.Add(cash);
        }

        Console.WriteLine("\n--- Processing Payment ---");
  foreach (Payment p in payments)
        {
            p.Pay();    
        }
    }
}
}
