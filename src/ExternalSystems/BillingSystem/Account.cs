using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class Account
    {

        public Account(string license, Owner owner)
        {
            this.License = license;
            this.Owner = owner;
        }

        public Owner Owner { get; private set; }

        public string License { get; }

        public string State => License[^2..];

    }
}

