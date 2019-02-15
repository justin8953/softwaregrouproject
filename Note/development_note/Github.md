### Version Control
 - Version Control
   - Definition: A category of software tools that help a software team manage changes to source code over time. 
   - Benefits:
      - Protect source code from both catastrophe and the casual degration of human error adn unintended consequences.
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
 - Benfits
   1. Performance 
      - Committing new changes
      - Branching
      - Merging 
      - Comparing past versions
   2. Security 
    - The content of the files as well as the true relationships between files and directories, versions, tags and commits, all of these objects in the Git repository are secured with a cryptographically secure hashing algorithm called SHA1. 
   3.  Flexibility 
    - in support for various kinds of nonlinear development workflows, in its efficiency in both small and large projects and in its compatibility with many existing systems and protocols.

### Basic Usage
 1. Setting up a repository
   - Initialising a new repsitory 
      - Versioning an existing project with a new git repository
      ```
         cd /path/to/your/existing/code
         git init  
      ``` 
      - Cloing an existing repository
      ` git clone <repo url> `
   - Saving changes to the repository
      - Steps
         1. Change directiories to `/path/to/project`
         2. `git add` the file to the repository staing area
         3. Create a new commit with a message
      - 
        ```
        cd /path/to/project
        git add test.c
        git commit -m "add test.c"
        ```
   - Repo-to-repo collaboration
      - Configuration & Set up
         - Once you have a remote repo setup, you will need to add a remote repo url to local git config
         `git remote add <remote_name> <remote_repo_url>`
         - Once you mapped the remote repo you can push local branches
         `git push -u <remote_name> <local_branch_name> `
         - Set global Git configuration options
            1. Define the author name to be used for all commits
            `git config --global user.name <name>`
            2. Define the author email to be used for all commits ( --local option or not passing a config level option at all)
            `git config --local user.email <email>`

      

### Github issue
1. [History Different](https://medium.com/@kihoonkang/git-master-and-branch-name-are-entirely-different-commit-histories-fda3bf37bd2)