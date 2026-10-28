# Snipe-IT Asset Management Automation

## Project Overview

This project automates asset creation, checkout, and verification workflows in the Snipe-IT demo application using C#, .NET 10, Microsoft Playwright, and NUnit.

## Technologies Used

- C#
- .NET 10
- Microsoft Playwright for .NET (1.64.1)
- NUnit
- Visual Studio Code

## Test Scenarios

The automated workflow performs the following steps:

1. Log in to the Snipe-IT demo application.
2. Navigate to the asset creation page.
3. Create a new MacBook Pro 13" asset with a unique asset tag and serial number.
4. Set the asset status to "Ready to Deploy".
5. Save the asset.
6. Locate the newly created asset in the Assets list.
7. Check out the asset to a randomly selected user.
8. Navigate to the asset details page.
9. Verify the asset information, including asset tag, model, and status.
10. Open the History tab and perform basic history verification.

## Prerequisites

- .NET 10 SDK
- Visual Studio Code or another compatible IDE
- Internet connection
- Playwright Chromium browser
- Valid Snipe-IT demo login credentials

## Installation

Clone the repository and navigate to the project directory.

Restore the dependencies:

```powershell
dotnet restore
```

Build the project:

```powershell
dotnet build
```

Install the Playwright Chromium browser:

```powershell
pwsh bin/Debug/net10.0/playwright.ps1 install chromium
```

If `pwsh` is not installed, install PowerShell 7 or run the Playwright installation script using an available compatible PowerShell environment.

## Environment Variables

The application reads login credentials from environment variables.

Set the following variables in PowerShell:

```powershell
$env:SNIPE_USERNAME="assets"
$env:SNIPE_PASSWORD="password"
```

Replace the placeholders with valid demo credentials.

Do not commit credentials or other secrets to the repository.

## Running the Tests

Run all tests:

```powershell
dotnet test
```

Run the main asset automation test:

```powershell
dotnet test --filter "Name=VerifyAssetsSearch"
```

## Expected Results

The main automation test should:

- Create a unique MacBook Pro 13" asset.
- Assign the Ready to Deploy status.
- Check out the asset to a randomly selected user.
- Locate the asset in the Assets list.
- Validate relevant asset information.
- Open the History tab and check for checkout-related text.

## Notes

- The project uses the public Snipe-IT demo environment.
- Asset tags and serial numbers are generated dynamically.
- The demo application contains shared test data that may change between executions.
- The History check is basic and does not verify every individual activity record.
- The main automated test is implemented in `UnitTest1.cs`.

## Author

Automation assessment submission.