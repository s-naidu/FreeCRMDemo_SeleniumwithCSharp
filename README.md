# FreeCRMDemo
# Automation Framework Selenium with CSharp #
This framework is created in Selenium and CSharp. It uses Page Object model design pattern.

Folder structure :-

1. Pages  -> contains page objects and Web element descriptions.
2. Tests -> contains test class with Nunit style test cases.
3. Utilities -> contains Base classe for managing test data from app.config and common functions for managing driver for chrome,Firefox and Edge , taking screenshots for failed tests,reporting and teardown

app.config contains data e.g.browser,url, username and password

## Gettign started

Clone this project and run to build the project. 

```
dotnet build FreeCRMDemo.csproj 
```

To run the tests from CLI;
```
dotnet test FreeCRMDemo.csproj --filter TestCategory=Smoke -- TestRunParameters.Parameter(name=\"browserName\", value=\"Chrome\")
```
Test results available in (index.html)

How to Install Visual Studio in windows?
Let’s download and install visual studio in following steps.

Step 1: Download the latest Visual Studio from the following link https://www.visualstudio.com/downloads/.Download Visual StudioIts preferable to download Visual Studio Community 2017 or Visual Studio Professional 2017 (30days free trail). 

Step 2: Once its downloaded, click on the executable(.exe) file.save exe

Step 3: Next, click on continue.Click On Continue

Step 4: Visual Studio will start downloading the initial files.Installer

Step 5: In next screen, click on install.Community Edition  

Step 6: In next screen select .NET desktop development and click on install.  select dot net

Step 7: Visual Studio will download .NET desktop development related files.Wait for download

Step 8: Once download is completed. It will ask for Reboot.reboot required

Step 9: After Reboot Open Visual Studio  (It will ask for sign in or sign up. If you Microsoft account sign in else click on Not now, may be later link.Sign in Required

Step 10: In next screen, Select General from dropbox and select the color theme of your choice and click on Start Visual Studio button.theme select

Step 11: Visual Studio is ready to use. You can now create C# Project by clicking on new Project and by giving name to it.

get started Install Selenium Webdriver With C#
Let’s see how to write “Hello World!!” Program in C#. 

Step 1: Launch Visual Studio. Start->Visual Studio ->click. It will launch Visual Studio. 

Step 2: Click on File-> New -> Project.new project

Step 3: Next screenproject name 1.Give project name. 2.Select the folder where you want project to be saved. 3.Click on OK button. Project will be created with name HelloWorld.   

Step 4: After creation of project sample project first lookKeywords:

using – using keyword is used to include namespace in the program.
namespace – namespace is a collection of classes. HelloWorld namespace contains the class Program.
class – class contains different data and method definitions.
Main – Main method is an entry point for C# programs. Execution starts from Main method.
  
Step 5: Add Console.WriteLine(“Hello World!!”) to the above project.console write line Console.WriteLine() is used to print message in console. Save the program and press F5 to execute the program. A command prompt window will appear that contains the line Hello Word!! The execution of the program will be too fast. To see console output Debug-> Start Without Debugging or Ctrl+F5. Check Output Screen 
How to Install Selenium to Visual Studio?
There are two ways of installing Selenium to Visual Studio.
Downloading Selenium libraries from seleniumhq.org.
Downloading Selenium via NuGet Package Manager.
Let’s see installation of selenium with Visual studio by downloading via NuGet Package Manager with an example. 

Create C# project by using steps mentioned in Section 7. 

Step 1: Create a new project called FirstProgram using above mentioned steps.create selenium project  

Step 2: Navigate to Tools-> NuGet Package Manager-> Manager NuGet Packages for Solution…NuGet package manager  

Step 3: In next screensearch for selenium

Select Browse tab.
Enter Selenium in search field.
Selenium latest Selenium.WebDriver available.
Select the project created in step 1(i.e FirstProgram)
Click on Install.

Step 4: In next screen click on OK button.preview

Step 5: Once WebDriver is installed. We should get following message.downloading confirm

Step 6: Once WebDriver is installed let’s install ChromeDriver. Tools-> NuGet Package Manager-> Manager NuGet Packages for Solution…NuGet package manager for Chrome Driver
Enter ChromeDriver in search field.
Select the ChromeDriver.
Select the project created.
Click on Install.
search for Chrome DriverIn Next screen click on OK button.chromedriver confirmationOnce ChromeDriver is installed. We will get the following message.chromedriver download  Step 7: Selenium is installed to FirstProgram. Now let’s write code to perform goggle search. Code Explanation.
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver();

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.google.com");

            //Maximize the window
            driver.Manage().Window.Maximize();

            //Find the Search text box using xpath
            IWebElement element = driver.FindElement(By.XPath("//*[@title='Search']"));

            //Enter some text in search text box
            element.SendKeys("learn-automation");

            //Close the browser
            driver.Close();
Install Selenium Webdriver With C#Navigate to Start button on the top and click on it. It will launch console 1st and after few seconds it will launch ChromeDriver and will perform action mentioned in the code.run Selenium ProgramWe will get output as shown below.final output
