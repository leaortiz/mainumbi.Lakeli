using System;
using System.Collections.Generic;
using System.Text;

namespace mainumbi.Lakeli.Jobs
{
    public class CreateJobInput
    {
        public Guid CustomerId { get; set; }
        public string Comment { get; set; }
        public string ContactNumber { get; set; }
        public string Adress { get; set; }
    }
}
