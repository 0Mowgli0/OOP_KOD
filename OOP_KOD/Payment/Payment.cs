using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD.Payment
{
    public abstract class Payment : IPayment
    {
        public double Amount { get; }
        protected Payment(double amount) { Amount = amount; }
        public abstract void Pay();
    }
}
