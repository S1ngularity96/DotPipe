using System;

namespace DotPipeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers();
            
            DotPipe.Pipeline pipe = new DotPipe.Pipeline();
            pipe.Use(numbers.PrintNumber(3), 
            (ref DotPipe.PipeContext context) => {
                Console.WriteLine("This is a second function");
            });
            pipe.Execute();
        }
    }
}
