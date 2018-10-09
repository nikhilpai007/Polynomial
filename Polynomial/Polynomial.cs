interface IDegree
{
    bool Order(Object obj);
}

public class Polynomial : IDegree
{
    //A reference to first node of a singly-listed list 
    private Node<Term> front;

    //Creates the polynomial 0
    public Polynomial()
    {
        this.front = new Node<Term>(null, null);

    }

    //Inserts the given term t into current polynomial in its proper order
    public void AddTerm(Term t)
    {
        Node<Term> current = this.front;

        while (current.Next != null && current.Next.Item.CompareTo(t) == 1 && current.Next.Item.Exponent != t.Exponent)
            current = current.Next;
        if (current.Next != null && current.Next.Item.Exponent == t.Exponent)
            current.Next.Item.Coefficient += t.Coefficient;
        else
            current.Next = new Node<Term>((Term)t.Clone(), current.Next);
    }
    // Adds the given polynomials p and q to yeild a new polynomial
    public static Polynomial operator +(Polynomial p, Polynomial q)
    {
        Polynomial result = new Polynomial();
        Node<Term> currentP = p.front.Next, currentQ = q.front.Next;

        while (currentP != null || currentQ != null)
        {
            if (currentP == null || (currentQ != null && currentQ.Item.CompareTo(currentP.Item) >= 0))
            {
                result.AddTerm((Term)currentQ.Item.Clone());
                currentQ = currentQ.Next;

            }
            else if (currentQ == null || (currentP != null && currentP.Item.CompareTo(currentQ.Item) >= 0))
            {
                result.AddTerm((Term)currentP.Item.Clone());
                currentP = currentP.Next;
            }
        }

        return result;
    }

    //Multiplies the given polynomials p and q to yield a new polynomial 
    public static Polynomial operator *(Polynomial p, Polynomial q)
    {
        Polynomial result = new Polynomial();
        Node<Term> currentP = p.front.Next, currentQ = q.front.Next;

        while (currentP != null)
        {
            Polynomial temporary = new Polynomial();
            while (CurrentQ != null)
            {
                Term newTerm = new Term(currentP.Item.Coefficient * currentQ.Item.Coefficient, (byte)(currentP.Item.Exponent + currentQ.Item.Exponent));
                temporary.AddTerm(newTerm);

                currentQ = currentQ.Next;
            }

            result = result + temporary;

            currentP = currentP.Next;
            currentQ = q.front.Next;

        }
        return result;
    }

    //Evaluates the current polynomial for a given x 
    public double Evaluate(double x)
    {
        double result = 0.0;

        Node<AddTerm> current = this.front.Next;

        while (current != null)
        {
            result += current.Item.Evaluate(x);
            current = current.Next;
        }

        return result;
    }

    //Prints the current polynomial 
    public void Print()
    {
        string result = "";
        Node<Term> current = this.front.Next;

        if (current == null)
            result = "0";
        else
        {
            while (current != null)
            {
                result += current.Item.ToString();
                current = current.Next;

                if (current != null && current.Item.Coefficient > 0)
                    result += "+";
            }

            System.Console.WriteLine(result);
        }
    }

    public bool Order(Object obj)
    {
        if (obj is Polynomial)
        {
            Polynomial p = (Polynomial)obj;

            Node<Term> currentNew = this.front.Next, currentNow = p.front.Next;

            while (currentNew != null && currentNow != null)
            {
                if (currentNew.Item.CompareTo(currentNow.Item) == 1)
                    return true;
                else if (currentNew.Item.CompareTo(currentNow.Item) == -1)
                    return false;

                currentNew = currentNew.Next;
                currentNow = currentNow.Next;
            }
            if (currentNow == null)
                return true;
            return false;
        }
        else
        {
            throw new Exception("Compare Not Possible");
        }
    }

    public void Trim()
    {
        Node<Term> current = this.front;

        while (current != null && current.Next != null)
        {
            if (current.Next.Item.Coefficient == 0.0)
            {
                current.Next = current.Next.Next;
            }
            current = current.Next;
        }
    }
}