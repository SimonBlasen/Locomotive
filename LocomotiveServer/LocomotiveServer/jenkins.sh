#!/bin/bash
rm CubeRacer2Server.csproj
mv CubeRacer2Server.csproj.jenkins CubeRacer2Server.csproj
dotnet build -c Release
cd bin/Release/netcoreapp3.1
tar -czf ../../CubeRacer2Server.tar.gz *
