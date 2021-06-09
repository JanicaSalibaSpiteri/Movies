#!/usr/bin/env pwsh

dotnet ef database drop -f
dotnet ef migrations remove
dotnet ef migrations add CreateMovies
dotnet ef database update