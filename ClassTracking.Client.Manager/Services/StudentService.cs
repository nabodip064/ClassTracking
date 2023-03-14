using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Client.Provider.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task AddAsync(Student student)
        {
            await _httpClient.PostAsJsonAsync<Student>("api/Student", student);
        }

        public async Task<bool> ApplicableWithMaxStudentInClass(int classId)
        {
            return await _httpClient.GetFromJsonAsync<bool>($"api/Student/applicable-in-class/{classId}");
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Student/{id}");
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<Student[]>("api/Student");
        }

        public async Task<IEnumerable<Student>> GetAllByClassIdAsync(int classID)
        {
            return await _httpClient.GetFromJsonAsync<Student[]>($"api/Student/class/{classID}");
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"api/Student/{id}");
        }

        public async Task UpdateAsync(Student student)
        {
            await _httpClient.PutAsJsonAsync<Student>("api/Student", student);
        }
    }
}
