using System;

public class Node<T>
{
    private T item;      
    private Node<T> next { set; } 

    public Node (T item, Node<T> next)
    {
        this.item = item;
        this.next = next;

    }


}
