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
    // If the value matches the current node's data, do nothing (ignore duplicate)
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
    if (value == Data)
    {
        return true;
    }
    else if (value < Data)
    {
        return Left != null && Left.Contains(value);
    }
    else
    {
        return Right != null && Right.Contains(value);
    }
}

    public int GetHeight()
{
    int leftHeight = Left != null ? Left.GetHeight() : 0;
    int rightHeight = Right != null ? Right.GetHeight() : 0;

    return 1 + Math.Max(leftHeight, rightHeight);
    }
}