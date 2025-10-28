using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Payment
{
    public sealed class DirectPayment : Payment
    {
        public DirectPayment(double amount) : base(amount) { }

        public override void Pay()
        {
            Console.WriteLine($"Direct payment completed for {Amount} SEK.");
        }
    }
}
