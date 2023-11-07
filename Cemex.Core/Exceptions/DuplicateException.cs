using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cemex.Core.Exceptions
{
    [Serializable]
    public class DuplicateException : Exception
    {
        public DuplicateException()
            : base()
        {

        }

        public DuplicateException(string message)
            : base(message)
        {

        }
        protected DuplicateException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
