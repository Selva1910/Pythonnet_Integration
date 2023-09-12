using Python.Runtime;

RunScript("pyScript");

static void RunScript(string scriptName)
{
    Runtime.PythonDLL = @"C:\Users\bselv\AppData\Local\Programs\Python\Python311\python311.dll";

    Console.WriteLine("Python Engine Initializing!...\r\n");
    PythonEngine.Initialize();

    using (Py.GIL())
    {
        var pythonScript = Py.Import(scriptName);
        Console.WriteLine("Python Code Executing!...");
        var logResult = pythonScript.InvokeMethod("LogStatement");
        Console.WriteLine(logResult);
        int num1 = 2;
        int num2 = 3;
        var AddResult = pythonScript.InvokeMethod("AddTwo", num1.ToPython(), num2.ToPython());
        Console.WriteLine($"\r\n Passed Values Number 1: <color>{num1} \n Number 2 : {num2} \n Added Value : {AddResult}");
    }
}