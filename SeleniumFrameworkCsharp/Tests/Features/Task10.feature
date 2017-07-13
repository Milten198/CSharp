@task10
Feature: Dynamically loading content

Background: 
Given I open task 10 page

@positive
Scenario: User is able to scroll to the bottom
    When I scroll the page to the bottom
    Then I can see footer

  Scenario: Fragments are loaded 6 times
    When I scroll the page to the bottom
    Then Loaded fragments are equal to 6