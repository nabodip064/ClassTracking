using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Client.Provider.Interfaces.ModelBase
{
    public interface IStudentService:IGenericService<Student>
    {
        Task<IEnumerable<Student>> GetAllByClassIdAsync(int classID);
        public Task<Boolean> ApplicableWithMaxStudentInClass(int classId);
    }
}
