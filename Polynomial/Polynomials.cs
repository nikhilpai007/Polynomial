public class Polynomials
{
    private List<Polynomials> P;
   
    private int capacity;
    private T[] A;
    private int count;

    //Creates an empty list of polynomials
    public Polynomials()
    {
        count == 0; 

    }


    //Retrives the polynomial stored at position i-1 in the list
    public Polynomial Retrieve(int i)
    {
        if (i >= 0 && i <= count - 1)
            return A[i];
        else
            return default(Polynomial);
    }

    //Inserts polynomial p into the list of polynomials ordered by degree
    public void Insert(Polynomial p)
    {
        int i;
        if (count < capacity && (p >= 0 && p <= count))
        {
            for (i = count - 1; i >= p; i--)
            {
                A[i + 1] = A[i];
            }
            A[p] = i;
            count++;

        }
        //else do nothing 
    }

    //Deletes the polynomial at index i-1 
    public void delete (int i)
    {
        int j;

        if (i >= 0 && i <= count-1)
        {
           for (j = i+1; j <= count-1; j++ )
                {
                A[j - 1] = A[j];
            }
            count--;
        }
    }

    // Prints out the list of polynomials (beginning with the polynomial 1)
    public void Print()
    {
        Console.WriteLine(/*some method */);
    }
}