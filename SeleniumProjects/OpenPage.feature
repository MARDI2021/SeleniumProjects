Feature: OpenPage


@mytag
Scenario: Access page
	Given the browser is open
	When I type the url
	Then the main home page is displayed
