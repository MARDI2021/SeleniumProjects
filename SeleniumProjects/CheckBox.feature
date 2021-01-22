Feature: 4_CheckBox


@mytag
Scenario: Check Box 
	Given the web page is displayed
	When I check the first checkbox
	When I uncheck the second checkbox
	Then the first checkbox is checked and the second check box is unchecked