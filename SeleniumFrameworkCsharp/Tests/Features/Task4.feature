@task4
Feature: Filling form in seperate window

Background: 
Given I open task 4 page
And I click on apply button
And Form in new window opens

@positive
Scenario: 01 User fill form with correct data
When I fill name field with "Jan Kowalski"
And I fill email field with "kowalski@gmail.com"
And I fill phone field with "600-100-200"
And I save this form
Then I can see message "Wiadomość została wysłana"

Scenario: 02 User tries to save form with wrong email and phone 
When I fill name field with "Jan Kowalski"
And I fill email field with "wrong email"
And I fill phone field with "600100200"
And I save this form
Then I can see error message "Nieprawidłowy email" for email
And I can see error message "Zły format telefonu - prawidłowy: 600-100-200" for phone number