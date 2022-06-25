using System;
using System.Collections.Generic;

namespace Domain
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}