### Version Control
  - Version Control
    - Definition: A category of software tools that help a software team manage changes to source code over time. 
    - Benefits:
      - Protect source code from both catastrophe and the casual degradation of human error adn unintended consequences.
      - Help teams tracking every individual change by each contributor and helping prevent concurrent work from conflicting
    - Outcome:
      - Good version control software supports a developer's preferred workflow without imposing one particular way of working. 
      - Great version control systems facilitate a smooth and continuous flow of changes to the code rather than the frustrating and clumsy mechanism of file locking.
  - Version Control System ( VCS ) such as Git
    - Benefit 
      - A complete long-term change history of every file.
      - Branching and merging
      - Traceability 
### **DVCS** ( Distributed Version Control System) Ex: Git
  - Every developer's working copy of the code is also a repository that can contain the full history change
    - Benefit
      1. Performance 
        - Committing new changes
        - Branching
        - Merging 
        - Comparing past versions
      2. Security 
        - The content of the files as well as the true relationships between files and directories, versions, tags and commits, all of these objects in the Git repository are secured with a cryptographically secure hashing algorithm called SHA1. 
      3.  Flexibility 
        - in support for various kinds of nonlinear development workflow, in its efficiency in both small and large projects and in its compatibility with many existing systems and protocols.

### Basic Usage
#### 1. Setting up a repository
  - Initialising a new repository 
    - Versioning an existing project with a new git repository [Advanced Topic `git bare`](https://www.atlassian.com/git/tutorials/setting-up-a-repository/git-init)
    ```
    cd /path/to/your/existing/code
    git init  
    ``` 
  - Cloning an existing repository [Advanced Topic with other config options](https://www.atlassian.com/git/tutorials/setting-up-a-repository/git-clone)
    - ` git clone <repo url> `
  - `git clone` versus `git init`
    - both can be used to initialise a new repository. 
    - `git clone` is dependent on `git initi`
    - `git clone` first calls `git init` to create a new repository. It then copies the data from the existing repository, and checks out a new set of working files.

#### 2. Saving changes to the repository
  - Steps
    1. Change directories to `/path/to/project`
    2. `git add` the file to the repository staging area
    3. Create a new commit with a message
  - `git add` and `git commit` commands mean to record versions of a project into the repository's history
  - Git add
    - The git add command adds a change in the working directory to the staging area. It tells Git that you want to include updates to a particular file in the next commit.
    - Staging area
      - it can be a buffer between the working directory and the project history.
      - you can make all sorts of edits to unrelated files, then go back and split them up into logical commits by adding related changes to the stage and commit them piece-by-piece. 
    - Common options
      - `git add <file>`
      - `git add <directory>`
  - Git commit
    -  Commits can be thought of as snapshots or milestones along the timeline of a Git project. 
    - Common option
      - `git commit -a` : Commit a snapshot of all changes in the working directory. This only includes modifications to tracked files
      - `git commit -m` : A shortcut command that immediately creates a commit with a passed commit message. 
  - Git diff
    - Comparing changes with `git diff`
    - The git diff command is often used along with git status and git log to analyze the current state of a Git repo.
    - **Highlighting changes**
      - `git diff --color-words`
      - `git diff`: By default git diff will show you any uncommitted changes since the last commit.
      - `git diff branch1..other-feature-branch`: Comparing two branches
        - The two dots in this example indicate the diff input is the tips of both branches. 
        - The three dot operator initiates the diff by changing the first input parameter branch1. 
      - `git diff master new_branch ./diff_test.txt`: Comparing files from two branches
  - [Git stash](https://www.atlassian.com/git/tutorials/saving-changes/git-stash)
    - `git stash`: takes your uncommitted changes (both staged and unstaged), saves them away for later use, and then reverts them from your working copy.
    - Re-applying your stashed changes
      -`git stash pop` :Popping your stash removes the changes from your stash and reapplies them to your working copy
      -` git stash apply` : Reapply the changes to your working copy and keep them in your stash
    - Adding the `-u` option (or `--include-untracked`) tells git stash to also stash your untracked files:
    - `git stash list`
    - ` git stash save "message":`
    - `git stash show` :Viewing stash diffs
    - `git stash drop stash@{1}` or `git stash clean `: cleaning up your stash
  - Ex.
    ```
    cd /path/to/project
    git add test.c
    git commit -m "add test.c"
    ```

#### 3. Repo-to-repo collaboration
  - Configuration & Set up
    - Once you have a remote repo setup, you will need to add a remote repo url to local git config
    `git remote add <remote_name> <remote_repo_url>`
    - Once you mapped the remote repo you can push local branches
    `git push -u <remote_name> <local_branch_name> `
    - Set global Git configuration options
      1. Define the author name to be used for all commits
        `git config --global user.name <name>`
      2. Define the author email to be used for all commits ( --local option or not passing a config level option at all)
        `git config --global user.email <email>`
  
### Working Tree
  - Working Tree in Git is a directory on your file system that is associated with a repository.
  - it's full of the files you edit, where you add new files, and from which you remove unneeded files. 
  - Any changes to the Working Tree are noted by the Index, and show up as modified files.

When you open the files for a project that is being managed as a Git repository then you are access the Working Tree. 

### [.gitignore](https://www.atlassian.com/git/tutorials/saving-changes/gitignore)
#### 1.File ignored
  - **dependency caches**, such as the contents of /node_modules or /packages
  - **compiled code** , such as .o, .pyc, and .class files
  - **build output directories**, such as /bin, /out, or /target
  - **files generated at runtime**, such as .log, .lock, or .tmp
  - **hidden system files**, such as .DS_Store or Thumbs.db
  - **personal IDE config files**, such as .idea/workspace.xml

#### 2. Patterns
  - globbing patterns [**More patterns see here**](https://www.atlassian.com/git/tutorials/saving-changes/gitignore)
  |Pattern                             | Example                |
  |:---                                | :---:                  | 
  |`**/logs`                           | logs/debug.log         | 
  |`**/logs/debug.log`                 | build/logs/debug.log   |
  |`*.log`                             | debug.log or .log      |
  |`*.log !important.log`              | debug.log or trace.log |
  |`*.log !important.log/*.log trace.*`| debug.log or important/trace.log |

  - **Ignore previously committed file**
  ``` 
    git rm --cached debug.log
    git commit -m "Start ignoring debug.log"
  ```
  - **Committing an ignored file** (-f Force to add)
  ```
    git add -f debug.log
    git commit -m "Force adding debug.log"
  ```
  - **Debugging .gitignore files**
   - `git check-ignore -v debug.log`
   - output: `<file containing the pattern> : <line number of the pattern> : <pattern> <file name>`



### Github issue
1. [History Different](https://medium.com/@kihoonkang/git-master-and-branch-name-are-entirely-different-commit-histories-fda3bf37bd2)