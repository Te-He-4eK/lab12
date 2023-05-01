using System;
using System.IO;

class Stack<T>
{
    private T[] data;
    private int top;

    public Stack(int size)
    {
        data = new T[size];
        top = -1;
    }

    public int Count
    {
        get { return top + 1; }
    }

    public void Push(T item)
    {
        if (top == data.Length - 1)
            throw new InvalidOperationException("Stack is full");

        data[++top] = item;
    }

    public T Pop()
    {
        if (top == -1)
            throw new InvalidOperationException("Stack is empty");

        return data[top--];
    }

    public T Peek()
    {
        if (top == -1)
            throw new InvalidOperationException("Stack is empty");

        return data[top];
    }

    public string StackToString()
    {
        if (top == -1)
            return "";

        string result = data[top].ToString();
        for (int i = top - 1; i >= 0; i--)
            result += "\n" + data[i].ToString();

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:\\vsvs\\lab12\\lab12-1\\bin\\Debug\\net7.0\\input.txt");

        Stack<string> stack = new Stack<string>(lines.Length);

        for (int i = 0; i < lines.Length; i++)
            stack.Push(lines[i]);

        Console.WriteLine("Stack contents:");
        Console.WriteLine(stack.StackToString());

        int shortestLineIndex = -1;
        int shortestLineLength = int.MaxValue;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length < shortestLineLength)
            {
                shortestLineIndex = i;
                shortestLineLength = lines[i].Length;
            }
        }

        Console.WriteLine("Shortest line:");
        Console.WriteLine($"Line {shortestLineIndex + 1}: {lines[shortestLineIndex]}, Length: {shortestLineLength}");
    }
}
