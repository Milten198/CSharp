@addToBasket
Feature: Add product to basket

	Background: 
		Given I open task 1 page

@positive
Scenario: 01 Add one product to basket
    When I add "Okulary" product to basket in quantity "1"
    Then this product is shown in basket summary


@positive
Scenario: 02 Add negative number of product to basket
    When I add "Okulary" product to basket in quantity "-10"
    Then this product is not shown in basket summary