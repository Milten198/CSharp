@Sorting
Feature: Task2

Background: 
Given I open task 2 page


Scenario Outline: 01 User is able to search for category
When I expand dropdown list
And I type fragment "<fragment>" of category name
Then I can see products only for this category "<category>"

Examples: 
| fragment | category       |
| el       | Elektronika    |
| ort      | Sport          |
| a i usł  | Firma i usługi | 