Feature: InternetHerokuapp

Scenario: Successful Addition of elements and deleting of elements
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to Add/Remove Elements page
	And I click 6 elements to add
	And I click the half elements to delete
	Then It shows the rest correct quantity of elements
	
Scenario: Successful Login
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to Login Page
	And I diligence username
	And I diligence Password
	And I click login button
	Then It authenticate correctly	
	
Scenario: Successful selection of options
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to Dropdown List page
	And I select one option of dropdown
	Then I shows the option with selected attribute	
	
Scenario: Successful validation of content change
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to Dynamic Content page
	And I click for changing contents
	Then I modify at least one content	
	
Scenario: Successful relink to JQuery page
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to JQueryUI - Menu page
	And I click in JQuery UI Menus link
	Then It relink to JQuery page

Scenario: Validation in menu disable and enabled
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to JQueryUI - Menu page
	And I validate disable option attribute and  enabled option attribute
	Then The disabled option shows disabled
	And The enabled option shows more elements

Scenario: Validation Alerts in browser
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to JavaScript Alerts page
	And I click in for JS Alert and I manage alert
	And I click in Click for JS Confirm and I manage alert
	And I click in Click for JS Prompt and I manage alert
	Then It shows correct printed messages in each alert management

Scenario: Successful validation of new window of browser
	Given I have access to The Internet herokuapp page
	When I validate correct element quantity
	And I access to Page Opening a new window
	And I click in link available
	Then It display one new tab
