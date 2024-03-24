using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TracKing.Infrastructure.Query
{
    [Serializable]
    public class QueryHandlerNotFoundException : Exception
    {
        private Type type;
        public QueryHandlerNotFoundException() { }
        public QueryHandlerNotFoundException(string message):base(message) { }
        public QueryHandlerNotFoundException(Type type) {  this.type = type; }
        public QueryHandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueryHandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
