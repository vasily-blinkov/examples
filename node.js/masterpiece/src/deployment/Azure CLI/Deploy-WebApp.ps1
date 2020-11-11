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
        Set-Variable ModuleAvailable ((Get-Module -ListAvailable | Where-Object Name $ModuleName -EQ | Measure-Object).Count -NE 0)
        If (!$ModuleAvailable) {
            Write-Error "Module '$ModuleName' is not available. $ModuleNotAvailableRecommendedAction."
            Return
        }
        Import-Module "$ModuleName"
    }

    Import-STDModule "PSYaml" `
     -ModuleNotAvailableRecommendedAction `
      "Install PSYaml by downloading 'https://github.com/Phil-Factor/PSYaml/tree/master/PSYaml' into '$env:USERPROFILE\Documents\PowerShell\Modules\'"
}

$PAT = Read-Host -Prompt "GitHub PAT (will be handled as secure string and won't be saved anywhere)" -AsSecureString
az webapp deployment source config `
 --branch master `
 --git-token ([System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($PAT))) `
 --manual-integration `
 --name SwallowTheDictionary `
 --repo-url https://github.com/vasily-blinkov/examples/tree/master/node.js/masterpiece/src `
 --resource-group SwallowTheDictionary-rg
