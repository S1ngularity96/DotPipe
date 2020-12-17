using System.Collections.Generic;
using DotPipe.Exceptions;

namespace DotPipe
{
    public class PipeContext
    {
        private Dictionary<string, object> data;
        
        public PipeContext()
        {
            data = new Dictionary<string, object>();
        }

        /// <summary>
        /// Adds Data to the current context of running pipeline
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, object value)
        {
            data.Add(key,value);
        }
        
        /// <summary>
        /// Returns Data from current context of running pipeline
        /// </summary>
        /// <param name="key">Name of data</param>
        /// <returns>Data as Object</returns>
        public object Get(string key)
        {
            return data[key];
        }
        
        /// <summary>
        /// Returns Data from current context of running pipeline
        /// </summary>
        /// <param name="key">Name of data</param>
        /// <returns>Data as Object</returns>
        /// <exception cref="PipeDataException">Throws if Data does not exist</exception>
        public object TryGet(string key)
        {
            if (data.ContainsKey(key))
            {
                return data[key];
            }
            throw new PipeDataException($"Data with Key {key}  does not exist");
        }
        
        public void Abort()
        {
            throw new PipeAbortException();
        }

        public void Abort(string message){
            throw new PipeAbortException(message);
        }

        public void ClearContext(){
            this.data.Clear();
        }
    }
}