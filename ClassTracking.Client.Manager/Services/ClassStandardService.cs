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
    public class ClassStandardService : IClassStandardService
    {
        private readonly HttpClient _httpClient;
        public ClassStandardService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task AddAsync(ClassStandard classStandard)
        {
            await _httpClient.PostAsJsonAsync<ClassStandard>("api/ClassStandard", classStandard);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/ClassStandard/{id}");
        }

        public async Task<IEnumerable<ClassStandard>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<ClassStandard[]>("api/ClassStandard");
        }

        public async Task<ClassStandard> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClassStandard>($"api/ClassStandard/{id}");
        }

        public async Task UpdateAsync(ClassStandard classStandard)
        {
            await _httpClient.PutAsJsonAsync<ClassStandard>("api/ClassStandard", classStandard);
        }

        public async Task<Boolean> HasClassStandardByTeacherAsync(int teacherId, int classId)
        {
            return await _httpClient.GetFromJsonAsync<Boolean>($"api/ClassStandard/exist-teacher/{teacherId}/{classId}");
        }
    }
}
