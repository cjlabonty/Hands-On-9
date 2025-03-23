using System;

class LoggerSingleton
{
    public enum Level {Comment, Warning, Error}
    static LoggerSingleton? instance;

    protected LoggerSingleton() {}

    public static LoggerSingleton Instance() {
        if(instance == null) {
            instance = new LoggerSingleton();
        }
        return instance;
    }

    public void Log(Level level, string message) {
        switch (level)
        {
            case Level.Comment:
                Console.WriteLine($"Comment: {message}");
                break;
            case Level.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case Level.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;
        }
    }
}

class LoggerStatic
{
    public enum Level {Comment, Warning, Error}
    static LoggerStatic() {}

    public static void Log(Level level, string message) {
        switch (level)
        {
            case Level.Comment:
                Console.WriteLine($"Comment: {message}");
                break;
            case Level.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case Level.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        LoggerSingleton loggerSingleton = LoggerSingleton.Instance();
        loggerSingleton.Log(LoggerSingleton.Level.Comment, "Singleton Comment");
        LoggerStatic.Log(LoggerStatic.Level.Comment, "Static Comment");
        loggerSingleton.Log(LoggerSingleton.Level.Warning, "Singleton Warning");
        LoggerStatic.Log(LoggerStatic.Level.Warning, "Static Warning");
        loggerSingleton.Log(LoggerSingleton.Level.Error, "Singleton Error"); // comment out to test static error
        LoggerStatic.Log(LoggerStatic.Level.Error, "Static Error");
    }
}