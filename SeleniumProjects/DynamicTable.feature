Feature: DynamicTable

@mytag
Scenario: Check content of dynamic tables 
	Given the web page with links is displayed
	When I check the content of a table
	Then the data table should be displayed