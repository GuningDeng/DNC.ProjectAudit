﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNC.ProjectAudit.Domain.Entities.AuditManagement.Questions
{
    public class MultipleChoiceQuestion : QuestionBase
    {
        public string? OptionText { get; set; }

    }
}
