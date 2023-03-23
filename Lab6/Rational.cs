using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Rational
    {
        private int numerator;
        private int denominator; 

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть нулём");

            int gcd = GreatestCommonDivisor(numerator, denominator);
            this.numerator = numerator / gcd;
            this.denominator = denominator / gcd;

            if (this.denominator < 0)
            {
                this.numerator = -this.numerator;
                this.denominator = -this.denominator;
            }
        }

        public int Numerator
        {
            get { return numerator; }
        }

        public int Denominator
        {
            get { return denominator; }
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            int newNumerator = a.numerator * b.numerator;
            int newDenominator = a.denominator * b.denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            int newNumerator = a.numerator * b.denominator;
            int newDenominator = a.denominator * b.numerator;
            return new Rational(newNumerator, newDenominator);
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return !a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rational))
                return false;

            Rational other = (Rational)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode();
        }

        public int CompareTo(Rational other)
        {
            int thisNumerator = this.numerator * other.denominator;
            int otherNumerator = other.numerator * this.denominator;
            return thisNumerator.CompareTo(otherNumerator);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", numerator, denominator);
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

    }
}
