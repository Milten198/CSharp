@task3
Feature: Filling editable form and uploading photo

Background: 
Given I open task 3 page

@positive
Scenario: User fill form with correct data
When I start the editable mode
And I fill all fields with correct data
And I upload photo
And I click save button
Then Message "Twoje dane zostały poprawnie zapisane" should appears
And All fields have correct data

Scenario: User is not able to fill form before unlock
When I try to modify form in locked mode
Then I am not able to modify data