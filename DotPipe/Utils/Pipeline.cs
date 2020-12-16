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

        ///<summary> Executes Pipeline
        ///<exception>Throws Exception if Pipeline has been aborted</exception>
        public void Execute()
        {
            PipeContext context = new PipeContext();
            ExecPipeline(context);
        }

        ///<summary> Executes Pipeline with given Context
        ///<exception>Throws Exception if Pipeline has been aborted</exception>
        public void Execute(PipeContext context){
            ExecPipeline(context);
        }

        private void ExecPipeline(PipeContext context){
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
                }
                catch (Exception ex){
                    throw ex;
                }
                finally
                {
                    //Clear any data that exists in Context
                    context.ClearContext();
                }

            }
        }

    }
}