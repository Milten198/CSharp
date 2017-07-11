@task4
Feature: Filling form in seperate window

Background: 
Given I open task 4 page
And I click on apply button
And Form in new window opens

@positive
Scenario: User fill form with correct data
When I fill name field with "Jan Kowalski"
And I fill email field with "kowalski@gmail.com"
And I fill phone field with "600-100-200"
And I save this form
Then I can see message "Wiadomość została wysłana"