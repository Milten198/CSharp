@loginPage
Feature: Login and download file

Background: 
Given I open task 6 page

Scenario: 01 User login to file page
When I am on login page
And I type user name "tester"
And I type password "123-xyz"
And I press login button
Then I am on logged page with file to download