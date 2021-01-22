Feature: 3_FormAuthentication


@mytag
Scenario: Login to Form
	Given the login form page is displayed
	When I enter the correct username
	When I enter the correct password
	When I click on the login button
	Then the home page is displayed