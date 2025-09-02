# Copilot Environment Setup

This directory contains setup scripts to pre-install dependencies required for developing the CPTMSDUG MCP Server in GitHub Copilot's environment.

## Setup Script

### `copilot-setup.sh`

Pre-installs .NET 10 SDK required for building and running the CPTMSDUG MCP Server.

**What it does:**
- Downloads and installs .NET 10 SDK to `~/.dotnet`
- Configures PATH environment variables
- Sets up basic NuGet configuration for development environments
- Provides troubleshooting guidance for common issues

**Usage:**
The script runs automatically in GitHub Copilot environments, but can also be run manually:

```bash
./.github/copilot-setup.sh
```

**Verification:**
After running the setup script, you can verify the installation:

```bash
# Check .NET version
dotnet --version

# List installed SDKs
dotnet --list-sdks

# Test build (should no longer show NETSDK1045 errors)
cd src && dotnet build
```

## Requirements

This setup script addresses the requirement that the CPTMSDUG MCP Server targets .NET 10.0, as specified in all project files:

```xml
<TargetFramework>net10.0</TargetFramework>
```

Without this setup, attempting to build the project would result in:
```
error NETSDK1045: The current .NET SDK does not support targeting .NET 10.0
```

## References

- [GitHub Copilot Environment Customization](https://docs.github.com/en/copilot/how-tos/use-copilot-agents/coding-agent/customize-the-agent-environment#preinstalling-tools-or-dependencies-in-copilots-environment)
- [.NET Installation Guide](https://docs.microsoft.com/en-us/dotnet/core/install/)