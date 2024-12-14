using Ds.Implementation;

public class DoubleLinkedListNode<T>
{
    public T Data { get; set; }
    public DoubleLinkedListNode<T>? Next { get; set; }
    public DoubleLinkedListNode<T>? Prev { get; set; }

    public DoubleLinkedListNode(T data)
    {
        this.Data = data;
        this.Next = null;
        this.Prev = null;
    }
}

public class DoubleLinkedList<T>
{
    private DoubleLinkedListNode<T> head;
    private DoubleLinkedListNode<T> tail;

    public DoubleLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new DoubleLinkedListNode<T>(data);
        if (head == null)
        {
            head = tail = newNode;
        }

        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new DoubleLinkedListNode<T>(data);
        if (tail == null)
        {
            head = tail = newNode;
        }

        else
        {
            tail.Next=newNode;
            newNode.Prev= tail;
            tail= newNode;
        }
    }
    public void Delete (T data)
    {
        var current= head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    tail = current.Prev;
                }

                return;
            }

            current = current.Next;
        }
    }

}