# Dependencies

dotnet (.NET) is required to run this project, you can download it at https://dotnet.microsoft.com/en-us/ or your package manager.
Both npm and pnpm are required to run this project.
Install Node.js (which also installs npm).
Install pnpm globally via `npm install -g pnpm` or locally within a directory via `npm install pnpm`.

# Installation

Do either of the following.
1. Download the source code of the repository and unzip it into a directory.
2. Use `git clone https://github.com/HAL703/ecommerce-experiment.git`.

Then perform the following steps:
* `cd ecommerce-experiment/ecommerce-experiment.Server`
* `dotnet run` - this will run the default https profile and serve the main application, go to https://localhost:5173 to view the webpage.

Or, if you are using Visual Studio or Rider:
* `cd ecommerce-experiment`
* Open the `ecommerce-experiment.sln` file with Visual Studio or Rider, then you can run and debug from within either of them.

# Troubleshooting

If you run `dotnet run` and it gets stuck on a prompt like `Building...`, CTRL + C then run it again.
This appears to be a dotnet issue as it gets stuck after installing pnpm packages. This may only be a linux-specific issue.
