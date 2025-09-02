#!/bin/bash

# Copilot Environment Setup Script
# Pre-installs .NET 10 SDK required for CPTMSDUG MCP Server development

set -e

echo "🔧 Setting up .NET 10 SDK for CPTMSDUG MCP Server development..."

# Check if .NET 10 is already installed
if command -v dotnet >/dev/null 2>&1 && dotnet --list-sdks 2>/dev/null | grep -q "10.0"; then
    echo "✅ .NET 10 SDK is already installed"
    dotnet --version
    exit 0
fi

echo "📦 Installing .NET 10 SDK..."

# Download and install .NET 10 SDK
# Using the official Microsoft installation script
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 10.0 --install-dir ~/.dotnet

# Add .NET to PATH for current session
export PATH="$HOME/.dotnet:$PATH"

# Add .NET to PATH permanently if not already there
if ! grep -q "\.dotnet" ~/.bashrc 2>/dev/null; then
    echo 'export PATH="$HOME/.dotnet:$PATH"' >> ~/.bashrc
fi

# Configure NuGet to handle SSL issues in development environments
mkdir -p ~/.nuget/NuGet
cat > ~/.nuget/NuGet/NuGet.Config << 'EOF'
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <config>
    <add key="http_proxy" value="" />
    <add key="https_proxy" value="" />
  </config>
</configuration>
EOF

# Verify installation
echo "🔍 Verifying .NET installation..."
~/.dotnet/dotnet --version

# List installed SDKs
echo "📋 Installed .NET SDKs:"
~/.dotnet/dotnet --list-sdks

echo "✅ .NET 10 SDK installation completed successfully!"
echo "💡 Notes:"
echo "   - You may need to restart your shell or run: source ~/.bashrc"
echo "   - If you encounter SSL/NuGet issues, the setup has configured basic NuGet settings"
echo "   - For persistent environment issues, consider using: export DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0"