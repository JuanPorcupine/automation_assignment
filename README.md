Automation Testing Assignment 🚀

Objective
Your task is to automate test cases using C#, Selenium, and NUnit on DemoQA. This assignment will evaluate your ability to interact with web elements, handle tables, and manage waits effectively.

Getting Started
1. Clone the Repository
- Fork this repository and clone it to your local machine:
- git clone https://github.com/JuanPorcupine/automation_assignment.git
- cd automation-assignment

2. Install Dependencies
Ensure you have the following installed:
• .NET SDK (latest version)
• Selenium WebDriver
• ChromeDriver
• NUnit & NUnit3TestAdapter
Install Selenium and NUnit via NuGet:
dotnet add package Selenium.WebDriver
dotnet add package Selenium.Support
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Selenium.WebDriver.ChromeDriver

4. Project Structure
automation-assignment/
│── Tests/
│   ├── ElementsTests.cs
│   ├── WebTablesTests.cs
│   ├── WaitTests.cs
│── Utils/
│   ├── WebDriverFactory.cs
│── .gitignore
│── README.md
│── AutomationAssignment.sln

Test Cases:

📝 Test Case 1: Text Box Form Validation
Objective: Automate form entry and validation.
Steps:
1. Navigate to DemoQA
2. Click on the “Elements” tab
3. Click on the “Text Box” option
4. Fill in all four fields with test data
5. Click the “Submit” button
6. Validate that the output matches the entered data

📊 Test Case 2: Web Table Data Extraction
Objective: Extract table data dynamically and validate key information.
Steps:
1. Navigate to DemoQA
2. Click on the “Elements” tab
3. Click on the “Web Tables” option
4. Retrieve and print the following:
• Number of rows
• Number of columns
• Email of the person named Alden

⏳ Test Case 3: Handling Dynamic Waits
Objective: Ensure synchronization when waiting for a delayed element.
Steps:
1. Navigate to DemoQA
2. Click on the “Elements” tab
3. Click on the “Web Tables” option
4. Wait for the element “Visible After 5 seconds” to appear
5. Assert that it is displayed

Submission Instructions
1. Create a Feature Branch
git checkout -b feature/your-name  
2. Write Your Tests in the /Tests directory
3. Run Tests Locally
dotnet test  
4. Push Changes & Create a PR
git add .  
git commit -m "Completed automation assignment"  
git push origin feature/your-name  

5. Submit a Pull Request (PR) on GitHub
