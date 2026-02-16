**PortfolioAgentFlux (MCP System)**
Hi I'm Klay, currently working on my MCP .NET 10 based Port project. 
Below is my Project summary start point. This is the root of my project and where everything started.

**Enjoy!**

**Architecture**
graph TD
User[User Input] --> Agent[PortfolioAgentFlux (Client)]
Agent -->|JSON-RPC via Stdio| Server[PortMCPKlayTT2 (Server)]
Server -->|Read File| Resume[Resume.md]
Server -->|API Call| GitHub[GitHub API]
Server -->|JSON Response| Agent
Agent -->|Final Output| User

**Projects**
1. PortfolioAgentFlux (Client/Agent)
- Description: A C# Console Application that manages the lifecycle of the MCP Server.
- Role: Acts as the "orchestrator," connecting to the server and executing tool requests.
- Technology: .NET 10, ModelContextProtocol.Client.

2. PortMCPKlayTT2 (Server/Tools)
- Description: A C# project that implements the MCP Server interface.
- Role: Provides the actual capabilities (Tools) for the agent to use.
- Tools Available:
- get_contact_info: Retrieves social links.
- get_github_repos: Lists GitHub repositories.
- get_resume: Reads the local Resume.md file.
- Technology: .NET 10, ModelContextProtocol.Server.

**Running the System**
Ensure the serverProjectPath in PortfolioAgentFlux points to the correct location of PortMCPKlayTT2. Running the client will automatically start the server process.