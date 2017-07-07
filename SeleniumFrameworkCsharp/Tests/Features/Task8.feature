@task8
Feature: Payment with different credit cards



@positive
Scenario Outline: User pays with different credit cards: 
When I select credit card type "<cardType>"
And I type name "Jan Kowalski"
And I type credit card number "<cardNumber>"
And I type CVV code "123"
And I select expiration date "July", "2020"
And I click pay button
Then Payment confirmation is displayed

Examples:
      | cardType                   | cardNumber       |
      | American Express           | 371449635398431  |
      | American Express Corporate | 378734493671000  |

Scenario Outline: Card expiration date expired
When I select credit card type "<cardType>"
And I type name "Jan Kowalski"
And I type credit card number "<cardNumber>"
And I type CVV code "123"
And I select expiration date "February", "2017"
And I click pay button
Then Payment expiration date message "Upłynął termin ważności karty" is displayed

Examples:
      | cardType         | cardNumber      |
      | American Express | 371449635398431 |