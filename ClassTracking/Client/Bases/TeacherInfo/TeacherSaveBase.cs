using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ClassTracking.Client.Bases.TeacherInfo
{
    public class TeacherSaveBase:ComponentBase
    {
        protected Teacher teacher { get; private set; } = new Teacher();
        [Inject]
        private ITeacherService _teacherService { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Parameter]
        public int? Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
                teacher = await _teacherService.GetByIdAsync((int)Id);
        }
        protected async Task HandleValidSubmit()
        {
            if (teacher.Id != 0)
                await _teacherService.UpdateAsync(teacher);
            else
                await _teacherService.AddAsync(teacher);
            _navigationManager.NavigateTo("/teacher/list");
        }
    }
}
