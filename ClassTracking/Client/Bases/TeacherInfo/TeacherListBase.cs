using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClassTracking.Client.Bases.TeacherInfo
{
    public class TeacherListBase:ComponentBase
    {
        [Inject]
        private ITeacherService _teacherService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        protected IEnumerable<Teacher> teachers { get; private set; }
        protected override async Task OnInitializedAsync()
        {
            teachers = (await _teacherService.GetAllAsync());
        }
        protected async Task ActionDeleteSelectedItem(int id)
        {
            bool isConfirm = await _js.InvokeAsync<bool>("confirm", "Do you sure to delete this?");
            if (isConfirm)
            {
                await _teacherService.DeleteAsync(id);
                await OnInitializedAsync();
            }
        }
        protected async Task ActionUpdateSelectedItem(int id)
        {
            _navigationManager.NavigateTo($"teacher/save/{id}");
        }
    }
}
