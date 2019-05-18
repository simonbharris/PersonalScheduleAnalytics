# PersonalScheduleAnalytics

_This will probably need to be updated to include working with a dotnet project, for instance, may need to do a dotnet restore along with npm install_

### Getting Started

1. Fork the project.
2. Clone your fork.
3. Make sure you are in the right directory: `cd PersonalScheduleAnalytics`.
4. Add an `upstream` remote for keeping your local repository up-to-date:
   > `git remote add upstream git@github.com:CIS470GroupTwo/PersonalScheduleAnaltics.git`
5. Run `npm install` to install the project dependencies.
6. Run `npm start` to start your dev environment.
7. See the app running on [localhost:3000](http://localhost:3000).

### Creating a new PR

1. Make sure you are on the `master` branch, and you have pulled the latest changes.

   > `git checkout master && git pull upstream master`

2. Install any new dependencies: `npm install`.

3. Create a new branch off of the `master` branch.

   > `git checkout -b [NEW BRANCH NAME]`

   > **Branch naming conventions:** `fix/[BRANCH]` for bug fixes, `feat/[BRANCH]` for new features, `doc/[BRANCH]` for changes to documents. The `[BRANCH]` portion should be kebab case. For example, if you want to update the README.md file, your branch could be called `doc/update-readme`.

4. Make changes and fix any warnings and/or errors that arise in the console.
5. Commit your changes: `git add . && git commit -m [YOUR COMMIT MESSAGE]`.

   > The subject of a commit message (the first line) should be 72 characters or less. If you need more room for a longer explanation of your changes, you can add a blank line below the subject and write a commit body. The commit message should be in present-imperative tense ("update README.md" rather than "updates" or "updated").

6. Push your branch to your fork: `git push -u origin [BRANCH NAME]`.
7. Open a new PR against the `master` branch from your fork using the GitHub user interface.
