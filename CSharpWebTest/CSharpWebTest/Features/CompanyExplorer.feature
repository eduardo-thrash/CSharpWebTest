Feature: CompanyExplorer

@Test
Scenario: Successful addressing to QVision
	Given I have access to QVision page
	When I select Contact link
	Then Page changes URL
@Test
Scenario: Successful addressing to Aranda
	Given I have access to Aranda page
	When I select Contact link
	Then Page changes URL
@Test
Scenario: Successful addressing to PSL
	Given I have access to PSL page
	When I select Contact link
	Then Page changes URL
