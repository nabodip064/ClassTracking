using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ClassTracking.Client.Bases.Dashboard
{
    public class HomeClassBase:ComponentBase
    {
        [Inject]
        private IClassStandardService _classStandardService { get; set; }
        protected IEnumerable<ClassStandard> classStandards { get; private set; } = Enumerable.Empty<ClassStandard>();
        protected override async Task OnInitializedAsync()
        {
            classStandards = (await _classStandardService.GetAllAsync());
        }
    }
}
