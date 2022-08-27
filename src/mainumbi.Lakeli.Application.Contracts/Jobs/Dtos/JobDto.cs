using System;
using System.Collections.Generic;
using System.Text;

namespace mainumbi.Lakeli.Jobs
{
    public class JobDto
    {
        public JobState State { get; protected set; }
        public string Comment { get; protected set; }
        public string ContactNumber { get; protected set; }
        public string Adress { get; protected set; }
        public Guid HouseAdminId { get; protected set; }
    }
}
