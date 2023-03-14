using ClassTracking.Domain.Interfaces.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IClassStandardRepository ClassStandards { get; }
        Task<int> Complete();
    }
}
