using StringCalculator.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            string delimiter = ",";

            if (numbers == string.Empty)
                return 0;

            if (numbers.StartsWith("//"))
            {
                int idx = numbers.IndexOf('\n');
                delimiter = numbers.Substring(2, idx - 2);
                numbers = numbers.Substring(numbers.IndexOf($"{delimiter }\n") + 2);
            }

            if (numbers.Contains("--")) {
                throw new ArgumentException("-3");
            }

            var num = numbers
                .Split(new string[] { delimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    return int.Parse(x);
                });

            var negativos = num.Where(x => x < 0);
            if (negativos.Count() > 0)
                throw new ArgumentException($"{string.Join(",", negativos)}");

            return num.Sum();
        }
    }
}
