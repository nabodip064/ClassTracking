using ClassTracking.Domain.Interfaces.ModelBase;
using ClassTracking.EFCore.Context;
using ClassTracking.EFCore.Repositories;
using ClassTracking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.EFCore.Repositories.ModelBase
{
    public class ClassStandardRepository : GenericRepository<ClassStandard>, IClassStandardRepository
    {
        public ClassStandardRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> HasClassStandardByTeacherAsync(int teacherId, int classId)
        {
            return _context.Set<ClassStandard>().Any(c => c.TeacherId == teacherId && c.Id != classId);
        }
    }
}
