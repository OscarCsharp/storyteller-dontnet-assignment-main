# Storyteller take-home assignment: Todo-list application

## Overview

Welcome! This technical assignment is designed to assess your .NET skills in a practical and realistic way. You’ll be working on a multi-user todo-list web application written in C# using [.NET 8.0](https://get.asp.net).

Your goal is to improve the application incrementally, starting from familiarization and progressing toward more complex features and enhancements. The tasks simulate real-world challenges relevant to our day-to-day work at Storyteller.

We estimate the assignment should take **3–5 hours** to complete. Please do not exceed 5 hours — we're interested in seeing how you prioritize and structure your work under time constraints.

---

## Setup instructions

The app runs cross-platform and can be built using Visual Studio, Visual Studio Code, Rider, or the command line.

```bash
# Build the project
dotnet build

# Run the unit tests
dotnet test Todo.Tests

# Run the application
dotnet run --project Todo
```

> One test has been intentionally left failing — part of your task is to fix it.

---

## Repository guidelines

- Create a **new private Git repository** for your submission.
- Each commit should be atomic and related to a single logical change.
- Use a `SOLUTION.md` file to describe your implementation, design decisions, trade-offs, and anything you'd like us to know.

---

## Deliverables

- Functional code, committed to your private Git repository.
- A `README.md` describing how to run your project and any setup steps.
- A `SOLUTION.md` explaining your approach, decisions, and assumptions.

> Submissions without a `SOLUTION.md` will not be considered complete.

---

## Time estimate

**3–5 hours total**

If you cannot complete everything, that’s okay — quality over quantity. We’re more interested in your approach, clarity, and decision-making.

---

## Task breakdown

### Section 1: Setup and core bug fix

These tasks help you get familiar with the codebase, fix a known issue, and improve onboarding for future developers.

1. Set up the project and get it running. Register a user, create todo-lists and items to explore the app.
2. Improve the project’s documentation to make it easier for new developers to get the app running. Add setup steps, platform requirements, and common troubleshooting tips to the `README.md`.
3. Fix the failing unit test related to mapping `TodoItem → TodoItemEditFields` where the `Importance` is missing.

---

### Section 2: UI enhancements and feature fixes

This section focuses on improving the user experience and implementing useful UI tweaks and fixes.

4. Update `Views/TodoList/Detail.cshtml` to display items sorted by importance (`High > Medium > Low`).
5. Replace "ResponsiblePartyId" with friendly display text on the item edit/create pages.
6. On the details page, allow users to toggle visibility of completed items.
7. Update the `/TodoList` page to include lists where the user is marked as the responsible party on at least one item.

---

### Section 3: Advanced enhancements and APIs

These are more complex tasks that involve schema changes, external APIs, or JavaScript enhancements.

8. Add a `Rank` property to `TodoItem`. Migrate the schema and allow rank setting/editing in the UI.
9. Enhance user identification: use the Gravatar API to fetch and display a user’s name alongside their email. Handle potential Gravatar downtime gracefully.
10. Improve UX: Replace the “Add New Item” navigation with an inline form using JavaScript and a custom API.
11. Build an API to update item rank and enable drag-and-drop reordering with JavaScript on the list detail page.
