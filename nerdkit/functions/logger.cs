namespace nerdkit.functions
{
    internal class logger
    {
        // Logging function
        public static void Log(string one, string two)
        {
            Console.ForegroundColor = ConsoleColor.Gray; Console.Write(DateTime.Now.ToString() + " ");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("["); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("+");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("]"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" - "); Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(one); Console.ForegroundColor = ConsoleColor.Red; Console.Write(" -> "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine(two);
        }

        public static void Out(string one)
        {
            Console.ForegroundColor = ConsoleColor.Gray; Console.Write(DateTime.Now.ToString() + " ");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("["); Console.ForegroundColor = ConsoleColor.Gray; Console.Write("+");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("]"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" - "); Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(one);
        }
    }
}
