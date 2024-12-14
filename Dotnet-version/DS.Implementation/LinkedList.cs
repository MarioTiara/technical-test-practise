namespace Ds.Implementation;


public class LinkedListNode <T>
{
    public T Data {get;set;}
    public LinkedListNode<T>? Next {get;set;}

    public LinkedListNode(T data)
    {
        this.Data= data;
        this.Next=null;
    }
}

public class SinglyLinkedList<T>
{
  private LinkedListNode<T>? head;
  public SinglyLinkedList()
  => this.head=null;

  public void InsertAtBeginning (T data)
  {
    var newNode= new LinkedListNode<T>(data);
    newNode.Next= this.head;
    this.head= newNode;
  }

  public void InsertAtEnd (T data)
  {
    var newNode = new LinkedListNode<T>(data);
     if (this.head==null)
     {
        head= newNode;
        return;
     }

    LinkedListNode<T> currentNode= this.head;
    while (currentNode.Next != null)
    {
        currentNode= currentNode.Next;
    }

    currentNode.Next=newNode;
  }
    public void Delte(T data)
    {
        if (head==null)
            return;
        
        if (head.Data.Equals(data))
        {
            head=head.Next;
            return;
        }

        var current = head;
        while(current.Next != null && !current.Next.Data.Equals(data))
        {
            current= current.Next;
        }

        if (current.Next!=null)
        {
            current.Next= current.Next.Next;
        }
    }

}

