





var node1 = new Node<int> { Value = 1 };
var node2 = new Node<int> { Value = 2 };

LinkedList<int> linkedList = new LinkedList<int>();

Stack<int> stack = new Stack<int>();
Queue<int> queue = new Queue<int>();

node1.Next = node2;
node2.Next = node1;

class MyQueue<T>
{
    private LinkedList<T> _list = new LinkedList<T>();
    public void Enqueue(T value)
    {
        _list.AddLast(value);
    }
    public T Dequeue()
    {
        if (_list.IsEmpty)
            throw new InvalidOperationException("Queue is empty.");
        var value = _list.Head.Value;
        _list.RemoveFirst();
        return value;
    }
    public bool IsEmpty => _list.IsEmpty;
}

//LinkedList<int> linkedList = new LinkedList<int>();

//linkedList.AddFirst(1);
//linkedList.AddLast(2);
//linkedList.AddLast(87);
//linkedList.AddFirst(-8);

class MyLinkedList<T>
{
    public Node<T>? Head { get; set; }
    public Node<T>? Tail { get; set; }

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public void AddHead(T value)
    {
        var node = new Node<T> { Value = value };

        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            node.Next = Head;
            Head.Prev = node;
            Head = node;
        }
        Count++;
    }

    public void AddTail(T value)
    {
        var node = new Node<T> { Value = value };
        if (Tail == null)
        {
            AddHead(value);
            return;
        }
        else
        {
            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }
        Count++;
    }

    public Node<T>? Find(T value)
    {
        var current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return current;
            }
            current = current.Next;
        }
        return null!;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }
}

class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node<T> Prev { get; set; }
}



//int[] arr = [1, 4, 8, 6, 3];

//int[] arr2 = new int[4000];

//arr2[0] = 1;
//arr2[1] = 8;
//arr2[2] = 0;
//arr2[3] = 8656464;

//long[] arr3 = new long[4];


//var a = arr2[2];
//var b = arr2[3016];

//List<int> ints = new List<int>();
//var u = ints[10000];

//bool Contains(int[] ar, int val)
//{
//    for (int i = 0; i < ar.Length; i++)
//    {   
//        if (ar[i] == val)
//        {
//            return true;
//        }
//    }
//    return false;
//}

//bool Test(int[] ar)
//{
//    for (int i = 0; i < ar.Length; i++)
//    {
//        for (int j = i + 1; j < ar.Length; j++)
//        {
//            if (ar[i] + ar[j] == 10)
//            {
//                return true;
//            }
//        }
//    }

//    return false;
//}