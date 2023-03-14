using ClassTracking.Domain.Interfaces;
using ClassTracking.Domain.Interfaces.ModelBase;
using ClassTracking.EFCore.Context;
using ClassTracking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.EFCore.Repositories.ModelBase
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
