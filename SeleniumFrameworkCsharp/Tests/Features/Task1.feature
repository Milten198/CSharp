@task1
Feature: Add product to basket

Background: 
Given I open task 1 page

Scenario: User is able to add products to basket
When I add product "Okulary" with quantity of "20"
And I add product "Kamera" with quantity of "5"
Then I can see total quantity "25" 
And I can see total price to pay "482.10 zł"

Scenario: User is able to remove products from basket
When I add product "Kubek" with quantity of "10"
And I add product "Aparat" with quantity of "11"
Then I can see "2" products in basket
And I remove product "Kubek" from basket
And I can see "1" products in basket	

Scenario: User tries to add over 100 products to basket
When I add product "Okulary" with quantity of "70"
And I add product "Kamera" with quantity of "31"
Then I can see alert with message "Łączna ilość produktów w koszyku nie może przekroczyć 100."