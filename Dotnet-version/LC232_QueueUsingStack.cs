using System.Text.Json;

namespace Technical_Test_Practice;


    public class MyQueue
    {
        private Stack<int> _stack1;
        private Stack<int> _stack2;

        public MyQueue()
        {
            _stack1 = new Stack<int>();
            _stack2 = new Stack<int>();
        }

        public void Push(int x)
        {
            while(_stack1.Count > 0)
            {
                _stack2.Push(_stack1.Pop());
            }

            _stack2.Push(x);

            while(_stack2.Count > 0)
            {
                _stack1.Push(_stack2.Pop());
            }
            
        }

        public int Pop()
        {
            return _stack1.Pop();
        }

        public int Peek()
        {
            return _stack1.Peek();
        }
        public void Print()
        {
            Console.WriteLine($"stack2: {JsonSerializer.Serialize(_stack2)}");
            Console.WriteLine($"stack1: {JsonSerializer.Serialize(_stack1)}");
        }
    }
