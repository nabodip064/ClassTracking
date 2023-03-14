using ClassTracking.Domain.Interfaces;
using ClassTracking.Domain.Interfaces.ModelBase;
using ClassTracking.EFCore.Context;
using ClassTracking.EFCore.Repositories.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IStudentRepository Students { get; private set; }

        public ITeacherRepository Teachers { get; private set; }

        public IClassStandardRepository ClassStandards { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Students = new StudentRepository(this._context);
            Teachers = new TeacherRepository(this._context);
            ClassStandards = new ClassStandardRepository(this._context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
