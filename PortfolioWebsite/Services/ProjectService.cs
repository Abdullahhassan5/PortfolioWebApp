using PortfolioWebsite.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PortfolioWebsite.Services
{
    public class ProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all projects
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Project>>("Projects");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching projects: {ex.Message}");
                return new List<Project>();
            }
        }

        // Get a single project by ID
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Project>($"Projects/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching project with ID {id}: {ex.Message}");
                return null;
            }
        }

        // Add a new project
        public async Task AddProjectAsync(Project newProject)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("projects", newProject);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error adding project: {response.StatusCode} - {errorContent}");
                    throw new Exception($"Failed to add project: {response.StatusCode}");
                }

                Console.WriteLine("Project added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddProjectAsync: {ex.Message}");
                throw;
            }
        }

        // Update an existing project
        public async Task UpdateProjectAsync(Project updatedProject)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Projects/{updatedProject.Id}", updatedProject);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error updating project: {response.StatusCode} - {errorContent}");
                    throw new Exception($"Failed to update project: {response.StatusCode}");
                }

                Console.WriteLine("Project updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateProjectAsync: {ex.Message}");
                throw;
            }
        }

        // Delete a project by ID
        public async Task DeleteProjectAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Projects/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error deleting project: {response.StatusCode} - {errorContent}");
                    throw new Exception($"Failed to delete project: {response.StatusCode}");
                }

                Console.WriteLine("Project deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteProjectAsync: {ex.Message}");
                throw;
            }
        }
    }
}
