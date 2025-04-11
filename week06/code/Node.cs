public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // IF THE VALUE EXISTS, DO NOTHING
        if (value == Data)
        {
            return;
        }


        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // IF THE VALUE EXISTS, RETURN TRUE
        if (value == Data)
        {
            return true;
        }

        // IF THE VALUE IS LESS THAN THE CURRENT NODE, CHECK THE LEFT SUBTREE
        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        else
        {
            // IF THE VALUE IS GREATER THAN THE CURRENT NODE, CHECK THE RIGHT SUBTREE
            return Right != null && Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0; // Replace this line with the correct return statement(s)
    }
}