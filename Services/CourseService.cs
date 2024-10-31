using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using utsfrontend72220586.Models;

public class CourseService
{
    private readonly HttpClient httpClient;

    public CourseService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    // Read (Get All Courses)
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Course>>("api/courses");
    }

    // Create
    public async Task AddCourseAsync(Course course)
    {
        await httpClient.PostAsJsonAsync("api/courses", course);
    }

    // Update
    public async Task UpdateCourseAsync(Course course)
    {
        await httpClient.PutAsJsonAsync($"api/courses/{course.Id}", course);
    }

    // Delete
    public async Task DeleteCourseAsync(int id)
    {
        await httpClient.DeleteAsync($"api/courses/{id}");
    }
}
