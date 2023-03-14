using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClassTracking.Client.Bases.StudentInfo
{
    public class StudentSaveBase:ComponentBase
    {
        protected Student student { get; private set; } = new Student();
        [Inject]
        private IStudentService _studentService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        [Inject]
        private IClassStandardService _classStandardService { get; set; }
        [Parameter]
        public int? Id { get; set; }
        protected IEnumerable<ClassStandard> classes { get; private set; } = new List<ClassStandard>();
        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
                student = await _studentService.GetByIdAsync((int)Id);
            classes = await _classStandardService.GetAllAsync();
        }
        protected async Task HandleValidSubmit()
        {
            if (await ApplicableWithMaxStudentInClass())
            {
                if (student.Id != 0)
                    await _studentService.UpdateAsync(student);
                else
                    await _studentService.AddAsync(student);
                _navigationManager.NavigateTo("/student/list");
            }
            else
                await _js.InvokeVoidAsync("alert", "The class has already Maximum Student");
        }
        private async Task<Boolean> ApplicableWithMaxStudentInClass()
        {
            bool applicable = true;
            if ((student.ClassId != null) && (student.ClassId != 0))
                applicable = await _studentService.ApplicableWithMaxStudentInClass((int)student.ClassId);
            return applicable;
        }
    }
}
