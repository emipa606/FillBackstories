# GitHub Copilot Instructions for RimWorld Mod: Fill Backstories

## Mod Overview and Purpose

**Mod Name:** Fill Backstories  
**Author:** Mlie  
**Package ID:** Mlie.FillBackstories  

This RimWorld mod, Fill Backstories, addresses the common "Can't find random backstory" error by ensuring an ample supply of custom backstories. The mod iterates through all backstory tags available in the game and ensures there is a configurable total number of backstories by duplicating existing ones when necessary. This helps to enrich the variety of character backstories, enhancing gameplay and storytelling within the RimWorld universe.

## Key Features and Systems

- **Custom Backstory Duplication:** The primary feature of the mod is to duplicate existing backstories to reach a configurable total amount. This prevents errors arising from an insufficient number of backstories.
- **Configurable Settings:** Users have control over the total desired number of backstories through mod settings, allowing for flexibility and customization according to individual preferences.
- **Seamless Integration:** The mod integrates seamlessly with existing backstory systems in RimWorld, ensuring smooth gameplay without disruptions.

## Coding Patterns and Conventions

- **Project Structure:** The mod's source code is organized into distinct C# classes, each serving a specific function.
  - **Settings.cs:** Contains `FillBackstoriesSettings` class with an `ExposeData` member for managing settings data.
  - **Mod.cs:** Contains `FillBackstoriesMod` class responsible for executing core functionality and user interface components through methods like `DoSettingsWindowContents`.
  - **FillBackstories.cs:** Contains `FillBackstories` class with the logic to duplicate backstories through methods like `duplicateBackstoryDef`.

- **Naming Conventions:** Follow C# conventions, such as PascalCase for classes and methods and camelCase for method variables. Class and method names clearly indicate their responsibilities.

## XML Integration

- **Current Project State:** The mod currently does not use XML files or definitions, which is common in many RimWorld mods for defining in-game data. Future expansions may consider adding XML to manage additional data needs, such as defining new default backstories.

## Harmony Patching

- **Patch Approach:** While the current version does not require Harmony patches, consideration for using Harmony may be necessary if future features involve altering core game functionality. Harmony is a recommended tool for such modifications as it allows method swapping and extension without changing the base game code directly.

## Suggestions for Copilot

- **Refactoring Duplicates:** Investigate opportunities where existing lines can be refactored for better code efficiency and readability, such as consolidating similar logic processes.
- **Error Handling:** Implement more robust error handling patterns, leveraging null checks and validation processes to ensure game stability and integrity.
- **Test-Driven Development:** Encourage Copilot to assist in generating unit tests to validate the mod's functionality, especially in `FillBackstories` logic, to safeguard against regression in future updates.
- **Advanced Settings Engagement:** Suggest ways to expand the mod settings for users to choose specific backstories to prioritize or exclude during duplication.
- **Performance Optimization:** Identify any potential performance bottlenecks within methods where iterating through large lists could benefit from optimization techniques.

By following these instructions and utilizing GitHub Copilot's AI capabilities, contributors to the Fill Backstories mod can effectively maintain and enhance the project, ensuring a robust and user-friendly experience.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

