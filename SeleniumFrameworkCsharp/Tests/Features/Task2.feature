@Sorting
Feature: Task2

 As a user
 I want to be able to sort products by category

Background: 
Given I open task 2 page

Scenario Outline: 02 User is able to sort products by category
When I expand dropdown list
And I select category "<category>"
Then I can see products only for this category "<category>"

Examples: 
| category       |
| Sport          |
| Elektronika    |
| Firma i usługi |


Scenario Outline: 01 User is able to search for category
When I expand dropdown list
And I type fragment "<fragment>" of category name
Then I can see products only for this category "<category>"

Examples: 
| fragment | category       |
| ort      | Sport          |
| el       | Elektronika    |
| a i usł  | Firma i usługi |