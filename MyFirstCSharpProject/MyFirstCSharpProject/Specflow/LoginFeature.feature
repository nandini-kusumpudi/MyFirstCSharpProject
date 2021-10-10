Feature: LoginFeature
As a user to login
I would like to login the page
So that I can see the home page successfully

@mytag
Scenario: Login the page with valid details
	Given I launch the website 
	And I enter valid username and password details
	When the two numbers are added
	Then the result should be 120