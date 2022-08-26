using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mainumbi.Lakeli
{
    public interface IHouseAdminManager
    {
        Task AssignAsync(Job job, Laborer laborer);
    }
}
