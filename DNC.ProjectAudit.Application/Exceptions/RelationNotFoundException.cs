﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Application.Exceptions
{
    public class RelationNotFoundException : Exception
    {
        public RelationNotFoundException() : base() { }
        public RelationNotFoundException(string? message) : base(message)
        {
        }
    }
}
