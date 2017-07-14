@task7
Feature: Drag and drop product

Background: 
Given I open task 7 page

@positive
Scenario Outline: User drags and drop product to basket
When I set quantity "<quantity>" of product "<product>"
And I drag and drop "<product>" in basket
Then I can see this product "<product>" in basket

Examples: 
| quantity | product |
| 20       | Okulary |
| 30       | Monitor |