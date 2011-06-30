Feature: Provide caching
	In order to make caching easy
	As a programmer
	I want to inherit from a cache object that handles caching in memory

Scenario: Calling a method on a cached repository only once
	Given I have an instance of the product repository class
	And I have a cached product repository class
	When I call the GetAll method on the product repository class
	Then the base product repository class should be called 1 time 

Scenario: Calling a method on a cached repository twice
	Given I have an instance of the product repository class
	And I have a cached product repository class
	When I call the GetAll method on the product repository class
	And I call the GetAll method on the product repository class
	Then the base product repository class should be called 1 time 