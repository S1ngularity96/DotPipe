using System;
using System.Collections.Generic;
using DotPipe.Exceptions;

namespace DotPipe
{
    public class Pipeline
    {
        public delegate void Handler(ref PipeContext context);
        private List<Handler> Handlers;
        private List<Action<PipeContext>> PipeHandler;

        public Pipeline()
        {
            this.PipeHandler = new List<Action<PipeContext>>();
            this.Handlers = new List<Handler>();

            Handler test = (ref PipeContext context) => { };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func">Infinite List of Handlers</param>
        public void Use(params Handler[] func)
        {

            foreach (var handler in func)
            {
                Handlers.Add(handler);
            }
        }

        public void Execute()
        {
            PipeContext context = new PipeContext();
            foreach (var handler in Handlers)
            {
                try
                {
                    handler(ref context);
                }
                catch (PipeAbortException ex)
                {
                    if (ex.Message != null)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }finally{
                    //Clear any data that exists in Context
                    context.ClearContext();
                }

            }
        }

    }
}