using System.ComponentModel;
using ModelContextProtocol.Server; // Updated MCP NameSpace
using System.Net.Http.Json;
using System.Text.Json; // This helps with JsonElement too

namespace FluxPortfolioServer.Tools;

[McpServerToolType]

public class PortfolioTools // Remove "static" here
{
    [McpServerTool, Description("Returns the professional resume of KlayTT from the local storage.")]
    public static async Task<string> GetResume()
    {
        // This looks for Resume.md in your project folder
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resume.md");
    
        if (!File.Exists(path))
        {
            return "Resume file not found. Please ensure Resume.md exists.";
        }

        return await File.ReadAllTextAsync(path);
    }
    [McpServerTool, Description("Lists the names and descriptions of KlayTT's public GitHub repositories.")]
    public static async Task<string> GetGithubRepos()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "MCP-Server-Flux");

        try 
        {
            // This hits the /repos endpoint instead of the /user endpoint
            var repos = await client.GetFromJsonAsync<List<JsonElement>>("https://api.github.com/users/KlayTT/repos?sort=updated&per_page=5");
        
            var repoList = string.Join("\n", repos.Select(r => 
                $"- {r.GetProperty("name").GetString()}: {r.GetProperty("description").GetString() ?? "No description"}"));

            return $"KlayTT's Recent Repositories:\n{repoList}";
        }
        catch (Exception ex)
        {
            return $"Failed to fetch repos: {ex.Message}";
        }
    }
    [McpServerTool, Description("Provides KlayTT's professional contact information and social media links.")]
    public static string GetContactInfo()
    {
        return """
               📧 Email: klaythacker11@gmail.com
               🔗 LinkedIn: www.linkedin.com/in/k-thacker/
               🖥️ Portfolio: KTFlux@Whatever site it will be
               🗨️ Want to Chat?: Simply send me and email and I will respond as soon as possible!
               """;
    }
}