﻿using ClassTracking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Client.Provider.Interfaces.ModelBase
{
    public interface IClassStandardService:IGenericService<ClassStandard>
    {
        public Task<Boolean> HasClassStandardByTeacherAsync(int teacherId, int classId);
    }
}
