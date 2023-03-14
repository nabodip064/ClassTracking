using ClassTracking.Client.Provider.Interfaces.ModelBase;
using ClassTracking.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.Client.Provider.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HttpClient _httpClient;
        public TeacherService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _httpClient.PostAsJsonAsync<Teacher>("api/Teacher", teacher);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Teacher/{id}");
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<Teacher[]>("api/Teacher");
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Teacher>($"api/Teacher/{id}");
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            await _httpClient.PutAsJsonAsync<Teacher>("api/Teacher", teacher);
        }
    }
}
