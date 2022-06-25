using System;
using System.Collections.Generic;

namespace Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public DateTime Deadline { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<TimeLog> Logs { get; set; }
    }
}
