using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClassTracking.Client.Bases.ClassStandardInfo
{
    public class AssignTeacherBase:ComponentBase
    {
        [Inject]
        private IClassStandardService _classStandardService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        [Inject]
        private ITeacherService _teacherService { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        protected IEnumerable<Teacher> teachers { get; private set; } = new List<Teacher>();
        protected IEnumerable<ClassStandard> classStandards { get; private set; } = new List<ClassStandard>();
        private ClassStandard? _classStandard = new ClassStandard();
        private int? _teacherId;
        protected override async Task OnInitializedAsync()
        {
            classStandards = await _classStandardService.GetAllAsync();
            teachers = await _teacherService.GetAllAsync();
        }
        protected async Task OnSelectTeacher(ChangeEventArgs e)
        {
            if (e.Value != null && e.Value != "")
                _teacherId = Convert.ToInt32(e.Value);
            else
                _teacherId = null;
        }
        protected async Task OnSelectClass(ChangeEventArgs e)
        {
            if (e.Value != null && e.Value != "")
            {
                int _classId = Convert.ToInt32(e.Value);
                _classStandard = classStandards.Where(c => c.Id == _classId).FirstOrDefault();
            }
            else
                _classStandard = new ClassStandard();
        }
        protected async Task AssignTeacher()
        {
            if(_teacherId != null && _teacherId != 0 && _classStandard.Id != 0)
            {
                _classStandard.TeacherId = _teacherId;
                if (await IsValidAsigingTeacher())
                {
                    await _classStandardService.UpdateAsync(_classStandard);
                    _navigationManager.NavigateTo("/class/list");
                }
                else
                    await _js.InvokeVoidAsync("alert", "This Teacher has already assigned!");
            }
            else
                await _js.InvokeVoidAsync("alert", "Teacher and Class can't be empty");
        }
        private async Task<Boolean> IsValidAsigingTeacher()
        {
            bool notValid = false;
            if ((_classStandard.TeacherId != null) && (_classStandard.TeacherId != 0))
                notValid = await _classStandardService.HasClassStandardByTeacherAsync((int)_classStandard.TeacherId, _classStandard.Id);
            return !notValid;
        }
    }
}
