using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unifrik.Common.Shared.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {


        public EntityNotFoundException(string? message) : base(message)
        {
        }


    }
}
