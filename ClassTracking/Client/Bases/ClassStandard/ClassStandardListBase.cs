using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClassTracking.Client.Bases.ClassStandardInfo
{
    public class ClassStandardListBase:ComponentBase
    {
        [Inject]
        private IClassStandardService _classStandardService { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        [Inject]
        private NavigationManager _navigationManager { get; set; }
        protected IEnumerable<ClassStandard> classStandards { get; private set; } = Enumerable.Empty<ClassStandard>();
        protected override async Task OnInitializedAsync()
        {
            classStandards = (await _classStandardService.GetAllAsync());
        }
        protected async Task ActionDeleteSelectedItem(int id)
        {
            bool isConfirm = await _js.InvokeAsync<bool>("confirm", "Do you sure to delete this?");
            if (isConfirm)
            {
                await _classStandardService.DeleteAsync(id);
                await OnInitializedAsync();
            }
        }
        protected async Task ActionUpdateSelectedItem(int id)
        {
            _navigationManager.NavigateTo($"class/save/{id}");
        }
    }
}
