Feature: WindowsAlert

@mytag
Scenario: Windows Alerts 
	Given the web page with links is displayed
	When I click on windows alerts link
	Then the windows alerts should work
	And theTestConfirmAlert should work
	And the Test Dismiss Alert should work
	And send Alert message should work