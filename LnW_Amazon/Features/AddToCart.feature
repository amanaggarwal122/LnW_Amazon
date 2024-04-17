Feature: AddToCart

Scenario: Find a product and verify its price
	Given I am on Amazon India Website
	And I search for product "Monitor"
	When I click on the first product in result
	And I click on Add to cart
	And I verify the price of the item
	And I verify the subtotal of the cart
