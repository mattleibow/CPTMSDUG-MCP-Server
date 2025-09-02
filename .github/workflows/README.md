# GitHub Actions Workflows

This directory contains the CI/CD pipelines for the CPTMSDUG MCP Server project.

## Workflows

### 🔄 CI Pipeline (`ci.yml`)
**Trigger:** Push to `main` branch or Pull Requests

**Purpose:** Continuous integration pipeline that builds, tests, and packages the solution.

**Steps:**
1. Sets up .NET 10 (with fallback to .NET 9 if not available)
2. Restores NuGet dependencies
3. Builds the solution in Release configuration
4. Runs unit tests
5. Creates NuGet package for the .NET tool
6. Uploads package artifacts

### 🚀 Release Pipeline (`release.yml`)
**Trigger:** Push of version tags (e.g., `v1.0.0`)

**Purpose:** Automated release pipeline that publishes the .NET tool to NuGet.org and creates GitHub releases.

**Steps:**
1. Sets up .NET environment
2. Extracts version from git tag
3. Updates package version in project file
4. Builds and tests the solution
5. Creates NuGet package
6. Creates GitHub release with package artifacts
7. Publishes to NuGet.org (if `NUGET_API_KEY` secret is configured)

**Usage:**
```bash
# Create and push a release tag
git tag v1.0.0
git push origin v1.0.0
```

### 🛠️ Manual Build (`manual-build.yml`)
**Trigger:** Manual workflow dispatch

**Purpose:** On-demand build for testing and development purposes.

**Features:**
- Can be triggered manually from GitHub Actions UI
- Optional package creation (configurable input)
- Shorter artifact retention (7 days)
- Useful for testing changes without creating releases

## .NET Version Handling

All workflows are designed to work with .NET 10 when it becomes available, with automatic fallback to .NET 9 for current compatibility. The workflows will:

- ✅ Use .NET 10 when available (future-proof)
- 🔄 Fall back to .NET 9 if .NET 10 is not yet released
- 📊 Provide clear status reporting about .NET version compatibility
- ⚠️ Give helpful error messages if builds fail due to target framework issues

## Setup Requirements

### For Release Pipeline
To enable automatic publishing to NuGet.org, add the following repository secret:

- `NUGET_API_KEY`: Your NuGet.org API key with push permissions

**To add the secret:**
1. Go to repository Settings → Secrets and variables → Actions
2. Click "New repository secret"
3. Name: `NUGET_API_KEY`
4. Value: Your NuGet API key from https://www.nuget.org/account/apikeys

## Package Information

The built package will be:
- **Package ID:** `Cptmsdug.McpServer`
- **Tool Command:** `cptmsdug-mcp`
- **Installation:** `dotnet tool install -g Cptmsdug.McpServer`

## Troubleshooting

### .NET 10 Target Framework Issues
If builds fail with "The current .NET SDK does not support targeting .NET 10.0":
- This is expected until .NET 10 preview is released
- The workflows will automatically work once .NET 10 becomes available
- For immediate development, consider temporarily updating project files to target `net9.0`

### Test Failures
The tests make calls to the live CPTMSDUG API at https://cptmsdug.dev/mcp.json:
- Ensure the API is accessible
- Network connectivity issues may cause test failures
- Tests are designed to be resilient to changing data