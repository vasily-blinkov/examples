Param(
    [switch] $SkipLogin = $false, # `.\Deploy-WebApp.ps1 -SkipLogin` if logged in already
    [switch] $SkipModules = $false # `.\Deploy-WebApp.ps1 -SkipModule` if modules installed
)

If (!$SkipLogin) {
    az login
}

If (!$SkipModules) {
    function Import-STDModule {
        Param (
            [Parameter(Mandatory = $true)]
            [string] $ModuleName,

            [string] $ModuleNotAvailableRecommendedAction = $null
        )
        Set-Variable ModuleImported ((Get-Module | Where-Object Name $ModuleName -EQ | Measure-Object).Count -NE 0)
        If ($ModuleImported) {
            Return
        }
        Set-Variable ModuleAvailable ((Get-Module | Where-Object Name $ModuleName -EQ | Measure-Object).Count -NE 0)
        If (!$ModuleAvailable) {
            Write-Error "Module '$ModuleName' is not available. $ModuleNotAvailableRecommendedAction."
            Return
        }
        write-host "import module"
    }

    Import-STDModule "PSYaml" `
     -ModuleNotAvailableRecommendedAction "Follow 'One time setup' instructions from 'https://github.com/Phil-Factor/PSYaml/blob/master/README.md'"
}

<#az webapp deployment source config `
 --branch master `
 --git-token df1d5fbcf2981ea970145c153c88937ee4b4de4a `
 --manual-integration `
 --name SwallowTheDictionary `
 --repo-url https://github.com/vasily-blinkov/examples/tree/master/node.js/masterpiece/src `
 --resource-group SwallowTheDictionary-rg#>
