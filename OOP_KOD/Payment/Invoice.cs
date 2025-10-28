using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Payment
{
    public sealed class Invoice : Payment
    {
        public string InvoiceNumber { get; } = "F" + Random.Shared.Next(1000, 9999);

        public Invoice(double amount) : base(amount) { }

        public override void Pay()
        {
            Console.WriteLine($"Invoice {InvoiceNumber} created for {Amount} SEK. Pay later.");
        }
    }
}
