using System;

public class LinkedList
{
    private class Node
    {
        public int value;
        public Node Next;

        public Node(int value)
        {
            this.value = value;
            this.Next = null;
        }
    }

    private Node Head;

    // конструктор з одним параметром
    public LinkedList(int initialValue)
    {
        this.Head = new Node(initialValue);
    }

    // Конструктор копіювання
    public LinkedList(LinkedList other)
    {
        if (other.Head != null)
        {
            this.Head = new Node(other.Head.value);
            Node currentOrigin = this.Head;
            Node currentOther = other.Head.Next;//другий вузол
            while (currentOther != null)
            {
                currentOrigin.Next = new Node(currentOther.value);
                currentOrigin = currentOrigin.Next;
                currentOther = currentOther.Next;// стрибок
            }
        }
    }

    // рекурсивний метод додавання нового елемента останнім у список
    public void AddLastRecursive(int newValue)
    {
        this.Head = AddLastRecursive(this.Head, newValue);
    }

    private Node AddLastRecursive(Node node, int newValue)
    {
        if (node == null)
        {
            return new Node(newValue);
        }
        else
        {
            node.Next = AddLastRecursive(node.Next, newValue);
            return node;
        }
    }

    // Метод додавання нового елемента після n ного за рахунком елемента
    public void AddAfter(int index, int newValue)
    {
        Node current = this.Head;
        for (int i = 0; i < index && current != null; i++)
        {
            current = current.Next;
        }
        if (current == null)
        {
            
            Console.WriteLine("індекс перевищює довжину масива");
            return;
        }
        
            Node newNode = new Node(newValue);
            newNode.Next = current.Next;
            current.Next  = newNode;
        
    }

    // Не рекурсивний метод видалення останнього в списку елемента
    public void RemoveLast()
    {
        if (this.Head == null)
            {return;}
        if (this.Head.Next == null)
        {
            this.Head = null;
            return;
        }
        Node current = this.Head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }
        current.Next = null;
    }

    // Метод видалення всіх парних за значенням елементів
    public void RemoveEvenValues()
    {
        Node current = this.Head;
        Node prev = null;
        while (current != null)
        {
            if (current.value % 2 == 0)
            {
                if (prev == null)
                {
                    this.Head = current.Next;
                }
                else
                {
                    prev.Next = current.Next;
                }
            }
            else
            {
                prev = current;
            }
            current = current.Next;
        }
    }

    // Рекурсивний метод друку елементів списку у прямому порядку у рядок
    public void PrintAllRecursive()
    {
        Console.Write("[");
        PrintAllRecursive(this.Head);
        Console.WriteLine("]");
    }

    private void PrintAllRecursive(Node node)
    {
        if (node != null)
        {
            Console.Write(node.value + (node.Next != null ? ", " : ""));
            PrintAllRecursive(node.Next);
        }
    }

    // Метод сортування елементів списку за зростанням числових значень
    public void Sort()
    {
        if (this.Head == null || this.Head.Next == null) return;

        bool swapped;
        do
        {
            Node prev = null;
            Node current = this.Head;
            swapped = false;

            while (current.Next != null)
            {
                if (current.value > current.Next.value)
                {
                    Node temp = current.Next;
                    current.Next = temp.Next;///
                    temp.Next = current;
                    if (prev == null)
                        this.Head = temp;
                    else
                        prev.Next = temp;
                    prev = temp;
                    swapped = true;
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            }
        } while (swapped);
    }

        // Індексатор з двома параметрами
    public int this[int start, int end]
    {
        
        get
        {
            if(start > end)
            {
                int perm; 
                perm = end;
                end = start;
                start = perm;
            }
            int sum = 0;
            int index = 0;
            Node current = this.Head;
            while (current != null && index < start)
            {
                current = current.Next;
                index++;
            }
            while (current != null && index <= end)
            {
                sum += current.value;
                current = current.Next;
                index++;
            }
            return sum;
        }
    }
}



    
class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList(1);

        
        list.AddLastRecursive(10);

        list.AddLastRecursive(3);

        list.AddLastRecursive(4);

        list.AddLastRecursive(14);



        list.PrintAllRecursive();

        Console.WriteLine(list[4,1]);

        list.PrintAllRecursive();



        //    list.PrintAllRecursive();

        //    Console.WriteLine("Сума значень між 0 та 2 індексами: " + list[0, 2]);

        //    list.RemoveEvenValues();

        //    list.PrintAllRecursive();

        //    Console.WriteLine("Сума значень між 0 та 2 індексами: " + list[0, 2]);
        }
    }

