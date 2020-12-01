using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class Account
    {
        private static readonly Random _random = new();

        public Account(string license, Owner owner)
        {
            this.License = license;
            this.Owner = owner;
        }

        public Owner Owner { get; private set; }

        public string License { get; }

        public string State => License[^2..];

        public static string GenerateTestLicense()
        {
            var states = new string[] { "BC", "CA", "ID", "OR", "WA" };

            var builder = new StringBuilder();
            var numberLength = _random.Next(4, 8);

            for (int i = 0; i < numberLength; i++)
            {
                RandomAlphaNumeric(builder);
            }

            builder.Append('-');

            builder.Append(states[_random.Next(1, states.Length) - 1]);

            return builder.ToString();

            static void RandomAlphaNumeric(StringBuilder builder)
            {
                if (Convert.ToBoolean(_random.Next(0, 2)))
                {
                    builder.Append((char)('0' + _random.Next(0, 10)));
                }
                else
                {
                    builder.Append((char)('A' + _random.Next(0, 26)));
                }
            }
        }

        public static string GenerateTestLicenseViaLinq()
        {
            var states = new string[] { "BC", "CA", "ID", "OR", "WA" };

            var range = Enumerable.Range(0, _random.Next(4, 8));
            return string.Join("", range.Select(x => RandomAlphaNumeric()))
                      + $"-{states[_random.Next(1, states.Length) - 1]}";

            static string RandomAlphaNumeric()
            {
                return Convert.ToBoolean(_random.Next(0, 2))
                    ? ((char)('0' + _random.Next(0, 10))).ToString()
                    : ((char)('A' + _random.Next(0, 26))).ToString();
            }
        }
    }
}

