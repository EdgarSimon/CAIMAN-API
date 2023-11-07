using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cemex.Core.Exceptions
{
    [Serializable]
    public class CreateValidationException: Exception
    {
        public CreateValidationException()
            : base()
        {

        }

        public CreateValidationException(string message)
            : base(message)
        {

        }
        protected CreateValidationException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
