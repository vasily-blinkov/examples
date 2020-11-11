# Technologies

1. _Windows_
1. _PowerShell Core_
1. _YAML_
1. _Nodist_
1. _Node.js_
1. _NPM_
1. _Azure CLI_
1. _Brunch_
1. _Jade_
1. _CSS_

# What I've Done

## Project initialization

### Installing the toolchain

**Common note:** use elevated shell to run commands performing global installations.

1. Install _nodist_ via [installer](https://github.com/nullivex/nodist/releases) (not _choco_).
   **Note:** If installer warns "_PATH not updated, original length ???? > 1024_" then after installation
   you will have to add `"C:\Program Files (x86)\Nodist\bin\"` directory to the `%Path%` environment
   variable of the current user manually.
   **NB:** Installation of _nodist_ may reset your previous _Node.js_ installation including globally
   installed packages.
1. Look for the latest LTS version of _Node.js_: [Download | Node.js](https://nodejs.org/en/download/).
1. Install the latest LTS version of _Node.js_ via _nodist_. Example: `nodist + 14.15.0`.
1. Select the installed Node.js version: `nodist global 14.15.0`.
1. Install the appropriate version of NPM: `nodist npm match`.
1. Install package manager/build tool: `npm install -g brunch`.
1. For deployments [Install the Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli).

### Creating the project

1. Run a _PowerShell_ and use `set-location` to navigate to the project root directory.
1. Create an app with _brunch_: `brunch new src -s simple`.
1. Go to the project source code directory: `set-location "src"`.
1. Install brunch plugins and app dependencies: `npm install`.

## Initial right-click deployment

It is possible to deploy the application via Visual Studio Code using the next walkthrought:
[Create a Node.js web app in Azure](https://docs.microsoft.com/en-us/azure/app-service/quickstart-nodejs?pivots=platform-windows).

This creates _.vscode\settings.json_ at the project root directory (the directory opened in VS Code) and adds next settings:

1. `appService.defaultWebAppToDeploy` - you will have to change the subscription key, resource group's and site's names;
1. `appService.deploySubpath` - you need to leave this setting unchanged (directory where Brunch puts compiled web app).

**Notes**: _1)_ The directory for deployment is nothing else than _src/public_.
_2)_ You should run `npm run build` before deploy _src/public_.

Use this deployment method only to see if the project is able to work in a cloud.

# Usage

## Preparational actions before using automated deployment scripts

Execute actions below once for a machine.

### Install PSYaml

1. Download code in a ZIP archive from the [Phil-Factor/PSYaml](https://github.com/Phil-Factor/PSYaml) project.
1. Extract the _PSYaml_ folder from the archive into _"$HOME\Documents\PowerShell\Modules"_.

## Build the application for deployment

```PowerShell
PS ...\src> npm run build
```

## Deploying to Azure App Service

Use the next PowerShell script which uses Azure CLI.

Full form:

```PowerShell
PS ...\src> & '.\deployment\Azure CLI\Deploy-WebApp.ps1' -SkipLogin -SkipModules
```
or short form:

```PowerShell
PS ...\src> & '.\deployment\Azure CLI\Deploy-WebApp.ps1'
```

Here

1. `-SkipLogin` is an optional switch to skip `az login`; if you're already logged in to Azure it makes the script execution faster
1. `-SkipModules` is an optional switch to skip PowerShell modules check and loading; I recommend you to not omit this for a first run

## Starting the application

```PowerShell
PS ...\src> npm start
```

# Abstracts

## Azure CLI

### Web app

#### Write a list of your web apps into a file

```PowerShell
az webapp list | out-file "tmp.json"
```

#### Open a web app in a browser

```PowerShell
az webapp browse --name SwallowTheDictionary --resource-group SwallowTheDictionary-rg
```
