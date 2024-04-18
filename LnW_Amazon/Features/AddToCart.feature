Feature: AddToCart

Scenario: Find a product and verify its price
	Given I am on Amazon India Website
	And I search for the product "Monitor"
	When I click on the first product in result
	And I click on Add to cart
	And I opened cart
	And I verify the price of the item
	Then I verify the subtotal of the cart
