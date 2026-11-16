using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Enitites
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
