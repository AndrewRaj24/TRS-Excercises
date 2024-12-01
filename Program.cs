    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace TRSEvaluation
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                //GetMinValue method
                Console.WriteLine(GetMinimumValue(new int[] { -6, 45, 32, 64, -145, 0, 18, 64 }));
                Console.WriteLine(GetMinimumValue(new int[] { 74, -9, 97, 41, -41, 24, 48, 9, -48, -60, -19}));
                Console.WriteLine(GetMinimumValue(new int[] { -1, -17, 30, 52, -34,-64 }));

                //Multiply Method
                Console.WriteLine(Multiply(3));
                Console.WriteLine(Multiply(-1));
                Console.WriteLine(Multiply(2));
                Console.WriteLine(Multiply(0));
                Console.WriteLine(Multiply(61));

                //Averange and round method
                Console.WriteLine(AverageAndRound(new int[] { 14, -2, 5, 8, 32, 98, 68 }));
                Console.WriteLine(AverageAndRound(new int[] { 28, -52, 4, 12, 31, 1, -2 }));
                Console.WriteLine(AverageAndRound(new int[] { 15, 18, -42, 6, 12, -1 }));
                Console.WriteLine(AverageAndRound(new int[] { 4, 12, 28, -52, 16, -3 }));

                //Count groups method
                CountGroupings(new string[] { "Chocolate ", "Vanilla", "Cherry", "Vanilla", "Cherry"}).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));
                CountGroupings(new string[] { "Cherry ", "Vanilla", "Cherry", "Vanilla", "Cherry" }).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));
                CountGroupings(new string[] { "Chocolate ", "Chocolate", "Orange", "Vanilla", "Orange" }).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));
                CountGroupings(new string[] { "Chocolate ", "Vanilla", "Chocolate", "Vanilla", "Vanilla" }).ForEach(x => Console.WriteLine($"Value: {x.Key} occurred {x.Value} times"));

                //Index Of method
                Console.WriteLine(GetIndexOf(new string[] { "Cat", "Dog", "Bird" }, "Dog"));
                Console.WriteLine(GetIndexOf(new string[] { "Fish", "Hamster", "Snake" }, "Fish"));
                Console.WriteLine(GetIndexOf(new string[] { "Mouse", "Dog", "Bird" }, "Cat"));
                Console.WriteLine(GetIndexOf(new string[] { "Cat", "Hamster", "Cat" }, "Cat"));

                //Get fiscal year methods
                Console.WriteLine(GetFiscalYear(new DateTime(2024, 7, 1)));
                Console.WriteLine(GetFiscalYear(new DateTime(2023, 5, 21)));
                Console.WriteLine(GetFiscalYear(new DateTime(2025, 6, 20)));
                Console.WriteLine(GetFiscalYear(new DateTime(2024, 11, 1)));
                Console.WriteLine(GetFiscalYear(new DateTime(2022, 12, 31)));
            }

            /// <summary>
            /// Should return the lowest value of an array of integers. 
            /// </summary>
            /// <example>an array of [34, 15, 8, 2] returns 2</example>
            /// <param name="values">an array of <c>int[]</c></param>
            /// <returns><c>Int32</c> The lowest value of the array</returns>
            static int GetMinimumValue(int[] values)
            {
                int minValue = values[0];
                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] < minValue)
                    {
                        minValue = values[i];
                    }
                }
                return minValue;
            }
            // Could also leverage linq for the above "return values.Min();"

            /// <summary>
            /// Should return the product of that number and 8 if even. If odd, return the product of that number and 9;
            /// </summary>
            /// <example>32 => (32 * 8)</example>
            /// <example>21 => (21 * 9)</example>
            /// <param name="value"></param>
            /// <returns><c>Int32</c> The product of the number and it's corresponding multiplier</returns>
            static int Multiply(int value)
            {
                if (value % 2 == 0)
                {
                    return value * 8;
                }
                else
                {
                    return value * 9;
                }
            }
            // could also leverage ternary operators "return value % 2 == 0 ? value * 8 : value * 9;"

            /// <summary>
            /// Should return the average of the array and round down to the nearest whole number
            /// </summary>
            /// <example>[5, 1, 2] => 2</example>
            /// <example>[4, 3, 0, 5] => 3<example>
            /// <param name="values"></param>
            /// <returns><c>Int32</c>The rounded average of the given array</returns>
            static int AverageAndRound(int[] values)
            {
                int sum = 0; 

                for (int i = 0; i < values.Length; i++)
                {
                    sum += values[i];
                }
                return sum / values.Length;
            }

            /// <summary>
            /// Should return a <c>List<string, int>/c> of each unique value and the number of times it occurs
            /// </summary>
            /// <example>["Chocolate", "Chocolate", "Orange", "Vanilla"] => [ Chocolate: 2, Oragne: 1, Vanilla: 1 ]</example>
            /// <param name="values">The list to be evaluated</param>
            /// <returns><c>List<string, int></c></returns>
            static List<KeyValuePair<string, int>> CountGroupings(string[] values)
            {
                values = values.Select(v => v.Trim()).ToArray();

                var groupCount = new Dictionary<string, int>();

                foreach (var value in values)
                {
                    if(groupCount.ContainsKey(value))
                    {
                        groupCount[value]++;
                    }
                    else
                    {
                        groupCount[value] = 1;
                    }
                }
                return groupCount.ToList();
            }

            /// <summary>
            /// Should return the index of the fist occurence of the item within the array. Should return -1 if item does not exist.
            /// </summary>
            /// <example>["Cat", "Dog", "Fish"] (Cat) => 0</example>
            /// <example>["Cat", "Dog", "Fish"] (Dog) => 1</example>
            /// <example>["Cat", "Dog", "Fish"] (Fish) => 2</example>
            /// <example>["Cat", "Dog", "Fish"] (Bird) => -1</example>
            /// <param name="values">The array to be searched</param>
            /// <param name="lookupValue">The value to look up</param>
            /// <returns>The index of the item</returns>
            static int GetIndexOf(string[] values, string lookupValue)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == lookupValue)
                    {
                        return i;
                    }
                }
                return -1;
            }

            /// <summary>
            /// A company's fiscal year is offset by 6 months from the calendar year and runs from July 1st to June 30th. So even though it is July 1st, 2024, the fiscal year is 2025.
            /// Write a method that will calculate the fiscal year from the given date.
            /// </summary>
            /// <example>June 30th, 2024 => FY2024</example>
            /// <example>July 1st, 2026 => FY2027</example>
            /// <example>January 1st, 2025 => FY2025</example>
            /// <param name="value">The datetime to be evaluated</param>
            /// <returns>The fiscal year as integer/returns>
            static int GetFiscalYear(DateTime value)
            {
                if(value.Month < 7)
                {
                    return value.Year;
                }
                else
                {
                    return value.Year + 1;
                }
            }
            // Could also use linq/ternary operators. "return value.Month < 7 ? value.Year : value.Year + 1;"
        }
    }
