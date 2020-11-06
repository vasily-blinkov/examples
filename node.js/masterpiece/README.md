# Technologies

1. _Windows_
1. _PowerShell Core_
1. _Nodist_
1. _Node.js_
1. _NPM_
1. _Brunch_

# What I've Done

## Project initialization

*Common note:* use elevated shell to run commands performing global installations.

1. Run a _PowerShell_ and use `set-location` to navigate to the project root directory.
1. Install _nodist_ via [installer](https://github.com/nullivex/nodist/releases) (not _choco_).
   *Note:* If installer warns "_PATH not updated, original length ???? > 1024_" then after installation
   you will have to add `"C:\Program Files (x86)\Nodist\bin\"` directory to the `%Path%` environment
   variable of the current user manually.
   *NB:* Installation of _nodist_ may reset your previous _Node.js_ installation including globally
   installed packages.
1. Look for the latest LTS version of _Node.js_: [Download | Node.js](https://nodejs.org/en/download/).
1. Install it via _nodist_. Example: `nodist + 14.15.0`
1. Select the installed Node.js version: `nodist global 14.15.0`
1. Install the appropriate version of NPM `nodist npm match`
1. Install package manager/build tool: `npm install -g brunch`
1. Create an app with _brunch_: `brunch new src -s simple`
1. Go to the project source code directory: `set-location "src"`
1. Install brunch plugins and app dependencies: `npm install`

## Initial deployment

It is possible to deploy the application via Visual Studio Code using the next walkthrought:
[Create a Node.js web app in Azure](https://docs.microsoft.com/en-us/azure/app-service/quickstart-nodejs?pivots=platform-windows).

This creates _.vscode\settings.json_ at the project root directory (the directory opened in VS Code) and adds next settings:

1. `appService.defaultWebAppToDeploy` - you will have to change the subscription key, resource group's and site's names;
1. `appService.deploySubpath` - you need to leave this setting unchanged (directory where Brunch puts compiled web app).

# Usage

## Build the application for deployment

```PowerShell
PS ...\src> npm run build
```

## Starting the application

```PowerShell
PS ...\src> npm start
```
