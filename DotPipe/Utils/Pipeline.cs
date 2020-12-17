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
        private bool executionFinished = false;

        public Pipeline()
        {
            this.PipeHandler = new List<Action<PipeContext>>();
            this.Handlers = new List<Handler>();
        }

        /// <summary>Append one or many handler to Pipeline</summary>
        /// <param name="func" cref="Handler">Infinite List of Handlers</param>
        public void Use(params Handler[] func)
        {

            foreach (var handler in func)
            {
                Handlers.Add(handler);
            }
        }

        ///<summary>Removes all Handlers from the Pipeline</summary>
        public void Clear()
        {
            this.Handlers.Clear();
        }

        ///<summary>Remove the last inserted Handler from Pipeline</summary>
        public void PopHandler()
        {
            if (this.Handlers.Count > 1)
            {
                this.Handlers.RemoveAt(this.Handlers.Count - 1);
            }
        }

        ///<summary> Executes Pipeline </summary>
        ///<exception>Throws Exception if Pipeline has been aborted</exception>
        public void Execute()
        {
            PipeContext context = new PipeContext();
            ExecPipeline(context);
        }

        ///<summary> Executes Pipeline with given Context </summary>
        ///<exception>Throws Exception if Pipeline has been aborted</exception>
        public void Execute(PipeContext context)
        {
            ExecPipeline(context);
        }

        public bool isFinished(){
            return executionFinished;
        }

        private void ExecPipeline(PipeContext context)
        {
            try
            {
                foreach (var handler in Handlers)
                {
                    handler(ref context);
                }
                executionFinished = true;
            }
            catch (PipeAbortException ex)
            {
                if (ex.Message != null)
                {
                    System.Console.WriteLine(ex.Message);
                }
                executionFinished = false;
            }
            catch (Exception ex)
            {   
                executionFinished = false;
                throw ex;
            }
        }
    }
}