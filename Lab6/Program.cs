using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(1, 2);
            Rational b = new Rational(3, 4);

            Rational sum = a + b;
            Rational difference = a - b; 
            Rational product = a * b;
            Rational quotient = a / b;
            bool compare = a == b;
            bool notEqual = a != b;


            Console.WriteLine(sum.ToString());
            Console.WriteLine(difference.ToString());
            Console.WriteLine(product.ToString());
            Console.WriteLine(quotient.ToString());
            Console.WriteLine(compare);
            Console.WriteLine(notEqual);

        }        
    }    
}
