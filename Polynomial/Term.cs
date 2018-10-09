using System;

public class Term : IComparable
{
    private double Coefficient { get; set; }
    private byte Exponent { get; set; }

    //Creates a term with the given coefficient and exponent 
    public Term(double coefficient, byte exponent)
    {
        Coefficient = coefficient; 
        Exponent = exponent;
    }

    //Evaluates the current term for a given x
    public double Evaluates(double x)
    {
        return this.Coefficient * (Math.Pow(x, this.Exponent));
    }

    // Returns -1,0,or 1 if the exponent of the current term 
    // is less than, equal to, or greater than the exponent of obj
    public int CompareTo(Object obj)
    {
        Term temp = (Term)obj;


        if
            (temp.Exponent == this.Exponent)
        {


            return 0;
        }
        else if (temp.Exponent < this.Exponent)
        {
            return -1;
        }
        else
        {
            return 1;
        }


    }
}

class MainClass{
    public static void Main(string[] args) { 
        Term a = new Term(3, 5);
        Term b = new Term(1, 2);
        a.CompareTo(b);

        Console.WriteLine(a.CompareTo(b));
    
}
}

