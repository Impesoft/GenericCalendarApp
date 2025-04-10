Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object {
    $projectPath = $_.FullName
    $content = Get-Content $projectPath
    foreach ($line in $content) {
        if ($line -match '<PackageReference Include="([^"]+)" Version="([^"]+)"') {
            [PSCustomObject]@{
                Package = $matches[1]
                Version = $matches[2]
            }
        }
    }
} | Sort-Object Package -Unique | ForEach-Object {
    "    <PackageVersion Include=""$($_.Package)"" Version=""$($_.Version)"" />"
}
