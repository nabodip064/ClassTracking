using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClassTracking.Client.Bases.ClassStandardInfo
{
    public class ClassStandardSaveBase:ComponentBase
    {
        protected ClassStandard classStandard { get; private set; } = new ClassStandard();
        [Inject]
        private IClassStandardService _classStandardService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        [Inject]
        private ITeacherService _teacherService { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Parameter]
        public int? Id { get; set; }
        protected IEnumerable<Teacher> teachers { get; private set; } = new List<Teacher>();
        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
                classStandard = await _classStandardService.GetByIdAsync((int)Id);
            teachers = await _teacherService.GetAllAsync();
        }
        protected async Task HandleValidSubmit()
        {
            if (await IsValidAsigingTeacher())
            {
                if (classStandard.Id != 0)
                    await _classStandardService.UpdateAsync(classStandard);
                else
                    await _classStandardService.AddAsync(classStandard);
                _navigationManager.NavigateTo("/class/list");
            }
            else
                await _js.InvokeVoidAsync("alert", "This Teacher has already assigned!");
        }
        private async Task<Boolean> IsValidAsigingTeacher()
        {
            bool notValid = false;
            if ((classStandard.TeacherId != null) && (classStandard.TeacherId != 0))
                notValid = await _classStandardService.HasClassStandardByTeacherAsync((int)classStandard.TeacherId, classStandard.Id);
            return !notValid;
        }
    }
}
