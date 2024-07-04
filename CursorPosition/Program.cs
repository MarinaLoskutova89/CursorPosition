namespace CursorPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static string[] options = new[]
        {
            "a:",
            "b:",
            "c:",
        };

        public static Dictionary<string, string> slslsl = new Dictionary<string, string>();
        private static int columnPosition = 0;
        private static int rowPosition = 0;

        private static void PrintMenu()
        {
            string a = !slslsl.ContainsKey("a") ? "a" : slslsl["a"];
            string b = !slslsl.ContainsKey("b") ? "b" : slslsl["b"];
            string c = !slslsl.ContainsKey("c") ? "c" : slslsl["c"];

            string aa = !slslsl.ContainsKey("a") ? string.Empty : slslsl["a"];
            string bb = !slslsl.ContainsKey("b") ? string.Empty : slslsl["b"];
            string cc = !slslsl.ContainsKey("c") ? string.Empty : slslsl["c"];


            Console.WriteLine($"{a} * x ^ 2 + {b} * x + {c} = 0");
            Console.WriteLine($" {options[0]}{aa}");
            Console.WriteLine($" {options[1]}{bb}");
            Console.WriteLine($" {options[2]}{cc}");
        }
        private static void WriteCursor(int column, int row)
        {
            Console.SetCursorPosition(column, row);
            Console.Write(">");
            column += 3;
            Console.SetCursorPosition(column, row);
        }
        private static void WriteAnotherCursor(int column, int row)
        {
            Console.SetCursorPosition(column, row);
            Console.Write(">");
            column += 3;
            Console.SetCursorPosition(column, row);
            string? input = Console.ReadLine();
            CountSmth(input, row);
            Console.Write(input);
            Console.SetCursorPosition(column, row);
        }
        private static Dictionary<string, string> CountSmth(string input, int row)
        {
            if (row == 1)
            {
                if (slslsl.ContainsKey("a")) slslsl["a"] = input;
                else slslsl.Add("a", input);
            }
            else if (row == 2)
            {
                if (slslsl.ContainsKey("b")) slslsl["b"] = input;
                else slslsl.Add("b", input);
            }
            else
            {
                if (slslsl.ContainsKey("c")) slslsl["c"] = input;
                else slslsl.Add("c", input);
            }
            return slslsl;
        }
        private static void ClearCursor(int column, int row)
        {
            Console.SetCursorPosition(column, row);
            Console.Write(" ");
            Console.SetCursorPosition(column, row);
        }
        private static void Start()
        {
            ConsoleKeyInfo ki;

            rowPosition = 1;

            PrintMenu();
            WriteCursor(columnPosition, rowPosition);
            do
            {
                ki = Console.ReadKey();
                ClearCursor(columnPosition, rowPosition);
                switch (ki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (rowPosition > 1) rowPosition--;
                        else rowPosition = 3;
                        WriteCursor(columnPosition, rowPosition);

                        break;
                    case ConsoleKey.DownArrow:
                        if (rowPosition < options.Length) rowPosition++;
                        else rowPosition = 1;
                        WriteCursor(columnPosition, rowPosition);

                        break;
                    default:
                        WriteAnotherCursor(columnPosition, rowPosition);
                        Console.Clear();
                        PrintMenu();
                        WriteAnotherCursor(columnPosition, rowPosition);
                        break;
                }
            } while (ki.Key != ConsoleKey.Escape);
        }
    }
}
