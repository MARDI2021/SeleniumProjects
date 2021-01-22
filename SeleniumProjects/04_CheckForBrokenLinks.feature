Feature: 04_CheckForBrokenLinks

@mytag
Scenario: Check for broken Link
	Given the web page with links is displayed
	When I check all the links
	Then there should be no broken links
