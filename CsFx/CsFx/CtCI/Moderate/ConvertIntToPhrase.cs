using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsFx.CtCI.Moderate {
    class ConvertIntToPhrase {
        private static readonly string Negative = "Negative";
        private static readonly string Zero = "Zero";
        private static readonly string Hundred = " Hundred";
        private static readonly string[] Digits = new string[] {
            " One", " Two", " Three", " Four", " Five", " Six", " Seven", " Eight", " Nine"
        };
        private static readonly string[] Teens = new string[] {
            " Eleven", " Twelve", " Thirteen", " Fourteen", " Fifteen", " Sixteen",
            " Seventeen", " Eighteen", " Nineteen"
        };
        private static readonly string[] Tens = new string[] {
            " Ten", " Twenty", " Thirty", " Forty", " Fifty", " Sixty", " Seventy",
            " Eighty", " Ninety"
        };
        private static readonly string[] Thousands = new string[] {
            String.Empty, " Thousand", " Million"
        };

        public static string Convert(int value) {
            if (value == 0) {
                return Zero;
            } else if (value < 0) {
                return Negative + " " + Convert(Math.Abs(value));
            } else if (value > 1000000000) {
                throw new ArgumentException();
            }

            var count = 0;
            var segmentStrings = new Stack<string>();

            while (value > 0) {
                var segment = value % 1000;
                if (segment > 0) {
                    segmentStrings.Push(ToString(segment, count));
                }

                value /= 1000;
                count++;
            }

            return segmentStrings
                .Aggregate((a, b) => a + b)
                .TrimStart();
        }

        private static string ToString(int value, int count) {
            var builder = new StringBuilder();

            if (value >= 100) {
                builder.Append(Digits[value / 100 - 1]);
                builder.Append(Hundred);
                value %= 100;
            }

            if (value >= 20 || value == 10) {
                builder.Append(Tens[value / 10 - 1]);
                value %= 10;
            }

            if (value >= 11 && value <= 19) {
                builder.Append(Teens[value - 11]);

            } else if (value >= 1 && value <= 9) {
                builder.Append(Digits[value - 1]);
            }

            builder.Append(Thousands[count]);

            return builder.ToString();
        }
    }
}
