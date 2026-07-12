# CLAUDE.md

## Project Context

This repository contains NexusNova, a personal assistant application built with .NET MAUI and local AI technologies.

Primary technologies:

* .NET MAUI

* C# 13 / .NET 10

* ONNX Runtime

* ONNX Runtime GenAI

* MVVM

* Hugging Face models

## AI Assistant Responsibilities

Claude may help with:

* Generating code

* Writing documentation

* Creating tests

* Refactoring existing code

Claude must NOT assume requirements or implementation details.

If any requirement is unclear, Claude must ask for clarification before proceeding.

## Autonomy Level

Medium autonomy:

* Claude can generate code and propose changes.

* Claude must ask for confirmation before making structural or architectural changes.

## Coding Standards

The following rules are mandatory:

* Use nullable enabled.

* Use file-scoped namespaces.

* Use async/await whenever applicable.

* Do not use #region directives.

* All code comments must be written in English.

* Dependency Injection is mandatory for services and components.

## Testing Standards

The testing framework is xUnit.

When creating tests:

* Prefer unit tests.

* Mock external dependencies.

* Keep tests deterministic.

* Use clear Arrange / Act / Assert structure.

* Do not introduce additional testing frameworks without permission.

## Forbidden Actions

Claude must NOT:

* Add NuGet packages without explicit permission.

* Change the folder structure.

* Modify configuration files.

* Delete existing code.

* Introduce cloud services.

* Create new projects in the solution.

## Communication Rules

* All explanations and technical responses must be written in English.

* Be concise and direct.

* Avoid unnecessary introductions.

* Ask questions when requirements are ambiguous.

* Do not invent missing information.

## Refactoring Rules

When refactoring:

* Preserve existing behavior.

* Explain the reason for the refactor.

* Identify any potential side effects.

* Request confirmation if the refactor affects multiple modules or layers.

## Output Expectations

When generating code:

* Provide complete compilable snippets when possible.

* Include required using statements.

* Respect the existing project conventions.

* Avoid introducing additional dependencies unless approved first.

## Decision-Making Rules

Before proposing changes, Claude should:

* Verify whether the change conflicts with the forbidden actions section.

* Ask for clarification if any requirement is missing.

* Request approval before making architectural or structural modifications.

* Keep the solution aligned with local-first AI execution using ONNX technologies.
