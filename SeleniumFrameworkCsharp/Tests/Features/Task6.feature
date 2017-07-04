@loginPage
Feature: Login and download file

Background: 
Given I open task 6/logged page


Scenario: 01 User login to file page
When I am on login page
And I type user name "tester"
And I type password "123-xyz"
And I press login button
Then I am on logged page with file to download

Scenario: 02 User logout to login page
When I type user name "tester"
And I type password "123-xyz"
And I press login button
Then I am on logged page with file to download
And I press logout button
And I am on login page

Scenario: 03 User tries to login with incorrect data
When I am on login page
And I type user name "incorrectLogin"
And I type password "incorrectPassword"
And I press login button
Then I can see error with message "Nieprawidłowe dane logowania"