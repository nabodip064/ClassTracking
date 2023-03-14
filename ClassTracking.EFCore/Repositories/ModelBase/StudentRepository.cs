using ClassTracking.Domain.Interfaces.ModelBase;
using ClassTracking.EFCore.Context;
using ClassTracking.EFCore.Repositories;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.EFCore.Repositories.ModelBase
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
