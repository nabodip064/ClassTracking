using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClassTracking.Client.Bases.StudentInfo
{
    public class StudentListBase:ComponentBase
    {
        [Inject]
        private IStudentService _studentService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        protected IEnumerable<Student> students { get; set; } = Enumerable.Empty<Student>();
        protected override async Task OnInitializedAsync()
        {
            students = (await _studentService.GetAllAsync());
        }
        protected async Task ActionDeleteSelectedItem(int id)
        {
            bool isConfirm = await _js.InvokeAsync<bool>("confirm", "Do you sure to delete this?");
            if (isConfirm)
            {
                await _studentService.DeleteAsync(id);
                await OnInitializedAsync();
            }
        }
        protected async Task ActionUpdateSelectedItem(int id)
        {
            _navigationManager.NavigateTo($"student/save/{id}");
        }
    }
}
