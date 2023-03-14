using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ClassTracking.Client.Bases.Dashboard
{
    public class TeacherComponentBase:ComponentBase
    {
        protected Teacher teacher { get; private set; } = new Teacher();
        [Inject]
        private ITeacherService _teacherService { get; set; }
        [Parameter]
        public int? Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
                teacher = await _teacherService.GetByIdAsync((int)Id);
        }
    }
}
