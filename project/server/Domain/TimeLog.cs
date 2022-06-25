using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class TimeLog
    {
        public Guid Id { get; set; }
        public long LoggedMinutes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ProjectId { get; set; }
    }
}
