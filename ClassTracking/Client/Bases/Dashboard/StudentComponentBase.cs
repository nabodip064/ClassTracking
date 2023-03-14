using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace ClassTracking.Client.Bases.Dashboard
{
    public class StudentComponentBase:ComponentBase
    {
        protected IEnumerable<Student> students { get; private set; }
        [Parameter]
        public int? ClassId { get; set; }
        [Inject]
        private IStudentService _studentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (ClassId != null)
                students = await _studentService.GetAllByClassIdAsync((int)ClassId);
        }
    }
}
