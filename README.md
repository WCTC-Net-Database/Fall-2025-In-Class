# Fall 2025 — In-Class Examples

This repository contains code written live in class each week. After class, you can clone the repo and review or run the examples locally.

> **Repo URL:** `https://github.com/WCTC-Net-Database/Fall-2025-In-Class`
> **Default branch:** `main`
> **Folder convention:** `W1`, `W2`, … for each week

---

## What you’ll need

* **Windows 10/11**
* **Visual Studio 2022** (Community or higher) with:

  * **.NET** workload (e.g., “.NET desktop development” and/or “ASP.NET and web development” as appropriate)
  * **Git** support (included with VS 2022)
* *(Optional)* **GitHub CLI** (`gh`) if you prefer the command line

---

## Option A — Visual Studio 2022 (recommended)

### 1) Clone the repository

1. Open **Visual Studio 2022**.
2. On the start screen, click **Clone a repository** (or: **File → Clone Repository…**).
3. **Repository location:** paste
   `https://github.com/WCTC-Net-Database/Fall-2025-In-Class`
4. Choose a local **Path** (e.g., `C:\Dev\Fall-2025-In-Class`) and click **Clone**.
5. After cloning, VS will show the repo. Open the solution for the week you want (e.g., `W1\Something.sln`).

### 2) Build & run

* Press **F5** to run with debug, or **Ctrl+F5** to run without debugging.
* If prompted to restore NuGet packages, click **Restore**.

### 3) Get updates (new or changed code)

Any time after class, you can pull the latest:

* In VS, open **Git** → **Pull**
  (or open **Git Changes** window and click **Pull**)

> **Tip:** If you made local edits and VS says you need to commit/stash first:
>
> * Click **Stash** in the Git Changes window to temporarily set aside your changes, then **Pull**.
> * Later, use **Pop stash** to re-apply your edits.

---

## Option B — GitHub CLI (terminal)

### 1) Sign in (first time only)

Open **Terminal** (Windows Terminal or PowerShell):

```powershell
gh auth login
# Choose: GitHub.com → HTTPS → "Login with a web browser" and follow prompts
```

### 2) Clone the repository

```powershell
cd C:\Dev
gh repo clone WCTC-Net-Database/Fall-2025-In-Class
cd Fall-2025-In-Class
```

### 3) Open or build

* Open the solution in VS by double-clicking the `.sln`, or:
* Build from CLI (for .NET projects):

```powershell
dotnet restore
dotnet build
```

### 4) Get updates (pull latest)

```powershell
git status           # See if you have local changes
git pull origin main # Get the newest commits
```

If you have local edits you don’t need:

```powershell
git restore .        # Discard uncommitted changes
git pull origin main
```

If you want to keep your edits for later:

```powershell
git stash            # Save your work-in-progress
git pull origin main
git stash pop        # Re-apply your saved changes (may need to resolve merges)
```

---

## Common questions

* **“Which week’s code do I open?”**
  Each week has its own folder (e.g., `W1`, `W2`, …). Open the `.sln` inside that week’s folder.

* **“VS says it can’t restore packages.”**
  In **Visual Studio → Tools → NuGet Package Manager → Package Manager Settings → Package Sources**, ensure the default NuGet source is enabled. Then **Build → Restore NuGet Packages**.

* **“I pulled, but I don’t see new files.”**
  Make sure you’re on the `main` branch:

  * VS: **Git** → **Manage Branches** → check that **main** is bold/checked.
  * CLI: `git branch` (current branch has `*`). Switch if needed: `git switch main`, then `git pull`.

* **“I changed files and now I get merge conflicts.”**

  * In VS, use the **Merge Editor** to keep mine/theirs/both as appropriate.
  * CLI quick path (if you don’t need your local edits):

    ```powershell
    git restore .
    git pull origin main
    ```

---

## Contributing (students)

This repo is primarily for distributing in-class code. If you spot a typo or want to suggest an improvement:

1. **Open an Issue** on GitHub with details, or
2. **Fork** the repo and submit a **Pull Request** with a short description of the change.

---

## Troubleshooting & Help

* If you’re stuck, post in the class forum with:

  * A screenshot of the error
  * Your VS version (Help → About)
  * The command you ran (if using CLI)
  * What you expected vs. what happened

---

*(Happy cloning, and don’t forget to pull updates after each class!)*
