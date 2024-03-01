using Microsoft.Playwright;

namespace PlaywrightBackend;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    private IAPIRequestContext Request;

    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        var firefox = Playwright.Firefox;
        var browser = await firefox.LaunchAsync(new() { Headless = false });
        var page = await browser.NewPageAsync(new() { IgnoreHTTPSErrors = true });
        // Given I am on my website
        await page.GotoAsync("https://localhost:5173");

        await page.GetByPlaceholder("username").FillAsync("joh");
        await Expect(page.GetByPlaceholder("username")).ToHaveValueAsync("joh");
        await page.GetByPlaceholder("Enter your email").FillAsync("joh@gmail.com");
        await Expect(page.GetByPlaceholder("Enter your email")).ToHaveValueAsync("joh@gmail.com");

        var data = new Dictionary<string, dynamic>();
        data.Add("userId", 0);
        data.Add("userName", "joh");
        data.Add("email", "joh@gmail.com");
        var newUser = page.APIRequest.PostAsync("https://localhost:7224/user", new() { DataObject = data });
        Console.WriteLine(newUser.Result);
        Assert.That(newUser.Result.Ok);
        //var button = page.Locator("Submit");
        //await Page.APIRequest.PostAsync("https://localhost:5173")
        // Expect an attribute "to be strictly equal" to the value.
        //await Expect(button).ToBeEnabledAsync();
        //var buttonRes = page.GetByRole(AriaRole.Button, new() {NameRegex = new Regex("submit", RegexOptions.IgnoreCase)}).ClickAsync();
        // await page.GetByRole(AriaRole.Button, new() {NameRegex = new Regex("submit", RegexOptions.IgnoreCase)}).ClickAsync();
        //await Expect(page.WaitForResponseAsync())
        await page.GetByRole(AriaRole.Button, new() { NameRegex = new("Submit") }).ClickAsync();
        //Console.WriteLine(buttonRes.IsCompletedSuccessfully);
        //Assert.That(buttonRes.IsFaulted);

        // Click the get started link.
        //await button.ClickAsync();

        // Expects the URL to contain intro.
        //await Expect()
    }
}
