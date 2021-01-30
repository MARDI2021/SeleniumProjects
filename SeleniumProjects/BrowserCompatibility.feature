Feature: BrowserCompatibility
	

@mytag
Scenario: Open Web Page with Different Browsers
	Given a webpage exists
	When i open the webpage in different browsers
	Then The webpage should open in multiple browsers