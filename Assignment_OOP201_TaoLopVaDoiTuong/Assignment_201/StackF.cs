public class StackF
{
    #region fields
    private int maxSize, top;
    private int[] stackArray;
    #endregion    

    #region constructors
    public StackF(int maxSize)
    {
        this.maxSize = maxSize;
        stackArray = new int[this.maxSize];
        top = -1;
    }

    public StackF()
    {
        maxSize = 100;
        stackArray = new int[maxSize];
        top = -1;
    }
    #endregion

    #region methods
    public bool IsEmpty()
    {
        return top == -1;
    }

    public bool IsFull()
    {
        return top == maxSize - 1;
    }

    public void Push(int value)
    {
        if (IsFull())
        {
            Console.WriteLine("Stack is full");
            return;
        }
        stackArray[++top] = value;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("stack is empty");
            return -1;
        }
        return stackArray[top--];
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("stack is empty");
            return -1;
        }
        return stackArray[top];
    }
    #endregion    
}