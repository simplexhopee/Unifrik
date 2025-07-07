﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unifrik.Infrastructure.Shared.Exceptions
{
    [Serializable]
    public class EntityConflictException : Exception
    {
        public EntityConflictException(string entity)
            : base($"{entity} already exists")
        {

        }
    }
}
