using System.ComponentModel;
using ModelContextProtocol.Server; // Updated MCP NameSpace

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
}