Feature: api_productSearch


Scenario: Find a product and verify its price
	Given I search for a phone on amazon using api
	When I get the response success
	Then I copy the product price 
