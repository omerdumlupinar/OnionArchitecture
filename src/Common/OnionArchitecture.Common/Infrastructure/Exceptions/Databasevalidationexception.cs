using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Common.Infrastructure.Exceptions
{
    public class Databasevalidationexception:Exception
    {
        public Databasevalidationexception()
        {
            
        }
        public Databasevalidationexception(string? message) : base(message) 
        {

        }

        public Databasevalidationexception(string? message,Exception? innerException) : base(message, innerException)
        {

        }
        public Databasevalidationexception(SerializationInfo serializationEntries,StreamingContext streamingContext ) : base(serializationEntries, streamingContext)
        {

        }
    }
}
