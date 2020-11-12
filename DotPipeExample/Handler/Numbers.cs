using System;
using DotPipe;

namespace DotPipeExample
{
    public class Numbers
    {

        public DotPipe.Pipeline.Handler PrintNumber(int num) 
        {
            return (ref PipeContext context) =>
            {
                if (num >= 10)
                {  
                    context.Abort("Number was greater than 10.");
                }
                Console.Write("Number: " + num.ToString() +"\n");
            };
        }
    }
}