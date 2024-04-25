Feature: AddToCart

@UI
Scenario: Find aa monitor and verify its price
	Given I am on Amazon India Website
	And I search for the product "Monitor"
	When I click on the position "1" in result for product as "Monitor"
	And I click on Add to cart
	And I opened cart
	And I verify the price of the item
	Then I verify the subtotal of the cart

@UI
Scenario: Find a laptop and verify its price
	Given I am on Amazon India Website
	And I search for the product "Laptop"
	When I click on the position "2" in result for product as "Laptop"
	And I click on Add to cart
	And I opened cart
	And I verify the price of the item
	Then I verify the subtotal of the cart

@UI
Scenario: Find a Headphone and Keyboard and verify its price
	Given I am on Amazon India Website
	And I search for the product "Headphones"
	When I click on the position "1" in result for product as "Headphones"
	And I click on Add to cart
	And I hide the alert box
	Given I search for the product "Keyboard"
	When I click on the position "1" in result for product as "Keyboard"
	And I click on Add to cart
	And I opened cart
	And I verify subtotal of cart should match sum of item price
