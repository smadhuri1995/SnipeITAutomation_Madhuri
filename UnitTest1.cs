using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SnipeITAutomation;

public class Tests : PageTest
{
    [Test]
    public async Task LoginToSnipeIT()
    {
        // Open Snipe-IT
        await Page.GotoAsync("https://demo.snipeitapp.com");

        // Get login credentials
        string username = Environment.GetEnvironmentVariable("SNIPE_USERNAME")
            ?? throw new Exception("SNIPE_USERNAME is missing");

        string password = Environment.GetEnvironmentVariable("SNIPE_PASSWORD")
            ?? throw new Exception("SNIPE_PASSWORD is missing");

        // Enter username
        await Page.Locator("input[name='username']").FillAsync(username);

        // Enter password
        await Page.Locator("input[name='password']").FillAsync(password);

        // Click Login
        await Page.Locator("button[type='submit']").ClickAsync();
        Console.WriteLine("Current URL: " + Page.Url);

Console.WriteLine("Page title: " + await Page.TitleAsync());

await Page.ScreenshotAsync(new()
{
    Path = "login-result.png",
    FullPage = true
});

        // Verify successful login
await Expect(Page.GetByText("Dashboard", new() { Exact = true }))
    .ToBeVisibleAsync();

Console.WriteLine("Snipe-IT dashboard loaded successfully!");

    }
    // second code test starts here
    [Test]
public async Task VerifyAssetsPage()
{
    // Navigate to Snipe-IT login page
    await Page.GotoAsync("https://demo.snipeitapp.com/login");

    // Read login credentials
    string username = Environment.GetEnvironmentVariable("SNIPE_USERNAME")
        ?? throw new Exception("SNIPE_USERNAME is missing");

    string password = Environment.GetEnvironmentVariable("SNIPE_PASSWORD")
        ?? throw new Exception("SNIPE_PASSWORD is missing");

    // Enter username
    await Page.Locator("input[name='username']").FillAsync(username);

    // Enter password
    await Page.Locator("input[name='password']").FillAsync(password);

    // Click Login
    await Page.Locator("button[type='submit']").ClickAsync();

    // Verify login succeeded
    await Expect(Page.GetByText("Dashboard", new() { Exact = true }))
        .ToBeVisibleAsync();

    Console.WriteLine("Login successful!");

    // Verify Assets menu is visible
    await Expect(Page.GetByText("Assets", new() { Exact = true }).First)
        .ToBeVisibleAsync();

    Console.WriteLine("Snipe-IT Assets navigation is visible!");
}
[Test]
public async Task OpenAssetsPage()
{
    // Navigate to login page
    await Page.GotoAsync("https://demo.snipeitapp.com/login");

    // Get login credentials
    string username = Environment.GetEnvironmentVariable("SNIPE_USERNAME")
        ?? throw new Exception("SNIPE_USERNAME is missing");

    string password = Environment.GetEnvironmentVariable("SNIPE_PASSWORD")
        ?? throw new Exception("SNIPE_PASSWORD is missing");

    // Enter login details
    await Page.Locator("input[name='username']").FillAsync(username);
    await Page.Locator("input[name='password']").FillAsync(password);

    // Click Login
    await Page.Locator("button[type='submit']").ClickAsync();

    // Verify dashboard
    await Expect(Page.GetByText("Dashboard", new() { Exact = true }))
        .ToBeVisibleAsync();

    Console.WriteLine("Login successful!");

   // Click Assets menu
await Page.GetByText("Assets", new() { Exact = true })
    .First.ClickAsync();

Console.WriteLine("Assets menu clicked!");

// Take screenshot to check the expanded menu
await Page.ScreenshotAsync(new()
{
    Path = "assets-menu.png",
    FullPage = true
});
// Verify Assets page is displayed
await Expect(Page.GetByText("Assets", new() { Exact = true }).Last)
    .ToBeVisibleAsync();

Console.WriteLine("Snipe-IT Assets page opened successfully!");

}
[Test]
public async Task VerifyAssetsSearch()
{
    // Open login page
    await Page.GotoAsync("https://demo.snipeitapp.com/login");

    // Get login credentials
    string username = Environment.GetEnvironmentVariable("SNIPE_USERNAME")
        ?? throw new Exception("SNIPE_USERNAME is missing");

    string password = Environment.GetEnvironmentVariable("SNIPE_PASSWORD")
        ?? throw new Exception("SNIPE_PASSWORD is missing");

    // Login
await Page.Locator("input[name='username']").FillAsync(username);
await Page.Locator("input[name='password']")
    .FillAsync(password);
    await Page.Locator("button[type='submit']").ClickAsync();

    // Verify successful login
    await Expect(Page.GetByText("Dashboard", new() { Exact = true }))
        .ToBeVisibleAsync();

    // Navigate to Assets page
    await Page.GotoAsync("https://demo.snipeitapp.com/hardware");
// Navigate to Create New Asset page
await Page.GotoAsync("https://demo.snipeitapp.com/hardware/create");

// Verify the asset creation form is displayed
// Verify Create New Asset page is opened
await Expect(Page.GetByText("Create New", new() { Exact = true }).Last)
    .ToBeVisibleAsync();

Console.WriteLine("Create New Asset page opened successfully!");
    // Generate unique asset details
string assetTag = "MAC-" + DateTime.Now.ToString("yyyyMMddHHmmss");
string serialNumber = "SN-" + Guid.NewGuid().ToString("N")[..10];

// Enter asset tag and serial number
await Page.Locator("input[name='asset_tags[1]']").FillAsync(assetTag);

await Page.Locator("#serial_1").FillAsync(serialNumber);

Console.WriteLine("Asset Tag: " + assetTag);
Console.WriteLine("Serial Number: " + serialNumber);
// Select MacBook Pro 13 model
await Page.Locator("#select2-model_select_id-container").ClickAsync();

await Page.Locator("input.select2-search__field")
    .FillAsync("MacBook Pro 13");

await Page.GetByRole(AriaRole.Option, new() { Name = "MacBook Pro 13" })
    .ClickAsync();

Console.WriteLine("MacBook Pro 13 selected successfully!");
// Select Ready to Deploy status
await Page.Locator("#select2-status_select_id-container").ClickAsync();

await Page.GetByRole(AriaRole.Option, new()
{
    Name = "Ready to Deploy"
}).ClickAsync();

Console.WriteLine("Ready to Deploy status selected successfully!");
// Enter asset notes
await Page.Locator("textarea[name='notes']")
    .FillAsync("MacBook Pro 13 - Automation Testing");

Console.WriteLine("Asset notes entered successfully!");
// Open Location dropdown
//await Page.Locator("#select2-rtd_location_id_location_select-container")
  //  .ClickAsync();

// Search for Cumberland
//await Page.Locator("input.select2-search__field")
   // .FillAsync("Cumberland");

// Select Cumberland
//await Page.Locator(".select2-results__option")
  //  .Filter(new() { HasText = "Cumberland" })
    //.First
    //.ClickAsync(new() { Timeout = 10000 });

//Console.WriteLine("Cumberland location selected successfully!");
// Save asset
await Page.Locator("#submit_button").ClickAsync();

// Open asset
//await Page.GetByText(assetTag, new() { Exact = true }).First.ClickAsync();
// Navigate to Assets page
await Page.GotoAsync("https://demo.snipeitapp.com/hardware");

// Search for created asset
await Page.Locator("input[type='search']").First.FillAsync(assetTag);
await Page.Keyboard.PressAsync("Enter");

// Wait for asset to appear
await Page.Locator("table tbody tr")
    .Filter(new() { HasText = assetTag })
    .First
    .WaitForAsync(new() { Timeout = 30000 });

// Find the newly created asset
var assetRow = Page.Locator("table tbody tr")
    .Filter(new() { HasText = assetTag });

// Wait for the asset
await assetRow.First.WaitForAsync(
    new() { Timeout = 30000 });

// Click Checkout directly from the asset row
await assetRow.First
    .GetByText("Checkout", new() { Exact = true })
    .ClickAsync(new() { Timeout = 30000 });

Console.WriteLine("Checkout clicked successfully!");
// Open user dropdown
await Page.Locator("[id^='select2-assigned_user'][id$='-container']").ClickAsync();

// Select a random available user
var users = Page.Locator(".select2-results__option[aria-selected='false']");
await users.First.WaitForAsync();

int count = await users.CountAsync();
int randomIndex = Random.Shared.Next(count);

await users.Nth(randomIndex).ClickAsync();

// Confirm checkout
await Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" }).ClickAsync();

Console.WriteLine("Asset checked out successfully!");

// STEP 1: Navigate to Assets list
await Page.GotoAsync("https://demo.snipeitapp.com/hardware");

// Search for the newly created asset
var searchBox = Page.Locator("input[type='search']").First;

await searchBox.FillAsync(assetTag);
await Page.Keyboard.PressAsync("Enter");

// Verify asset exists in the list
var createdAssetRow = Page.Locator("table tbody tr")
//var assetRow = Page.Locator("table tbody tr")
    .Filter(new() { HasText = assetTag })
    .First;

await createdAssetRow.WaitForAsync(new() { Timeout = 30000 });

await Expect(createdAssetRow).ToContainTextAsync(assetTag);
await Expect(createdAssetRow).ToContainTextAsync("Macbook Pro 13");
//await Expect(createdAssetRow).ToContainTextAsync("MacBook Pro 13");

Console.WriteLine("Asset found and verified in Assets list!");


// STEP 2: Open the asset details page
await createdAssetRow.Locator("a").First.ClickAsync();

// Verify asset details
await Expect(Page.Locator("body")).ToContainTextAsync(assetTag);

await Expect(Page.Locator("body")).ToContainTextAsync("MacBook Pro 13");

await Expect(Page.Locator("body")).ToContainTextAsync("Ready to Deploy");

Console.WriteLine("Asset details verified successfully!");


// STEP 3: Open History tab
await Page.Locator("a[href='#history']")
    .ClickAsync();

// Verify History tab is visible
await Expect(Page.Locator("body")).ToContainTextAsync("History");

// Verify asset creation and checkout history
await Expect(Page.Locator("body")).ToContainTextAsync("Checkout");

Console.WriteLine("Asset history verified successfully!");
}

}