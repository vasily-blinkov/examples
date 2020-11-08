Param(
    [switch] $SkipLogin = $false, # `.\Deploy-WebApp.ps1 -SkipLogin` if logged in already
    [switch] $SkipModules = $false # `.\Deploy-WebApp.ps1 -SkipModule` if modules installed
)

If (!$SkipLogin) {
    az login
}

If (!$SkipModules) {
    Set-Variable YAMLModuleName "PSYaml"
    If ((Get-Module | Where-Object Name $YAMLModuleName -EQ | Measure-Object).Count -EQ 0) {
        Install-Module $YAMLModuleName
    }
}

<#az webapp deployment source config `
 --branch master `
 --git-token df1d5fbcf2981ea970145c153c88937ee4b4de4a `
 --manual-integration `
 --name SwallowTheDictionary `
 --repo-url https://github.com/vasily-blinkov/examples/tree/master/node.js/masterpiece/src `
 --resource-group SwallowTheDictionary-rg#>
