Feature: Provide caching
	In order to make caching easy
	As a programmer
	I want to inherit from a cache object that handles caching in memory

Scenario: Can call a method on the base product repository
	Given I have an instance of the product repository class
	And I have a cached product repository class
	When I call the GetAll method on the product repository class
	Then the base product repository class should be called once 
