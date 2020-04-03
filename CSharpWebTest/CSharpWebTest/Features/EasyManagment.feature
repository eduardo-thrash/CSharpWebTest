Feature: EasyManagment

Scenario: Successful diligence of client
	Given I have access to EasyManagment page
	When I select principal menu
	And I access to Clients menu
	And I diligence client name "Miley"
	And I diligence client identification "1018424569"
	And I diligence client phone "3005698564"
	And I diligence client birthday name "12/04/2020"
	And I diligence client surname "Parker"
	And I diligence client email "miley.parker@mailer.com"
	And I diligence client address "calle 45 # 96-89 sur"
	And I select "male" client genre	
	And I click Save
	Then It shows a message with Alert and message "Hello World"

Scenario: Successful diligence of providers
	Given I have access to EasyManagment page
	When I select principal menu
	And I access to Providers menu
	And I diligence provider name	
	And I diligence provider identification
	And I diligence provider contact
	And I diligence provider contact identification
	And I diligence provider contact phone
	And I diligence provider contact email
	And I click Save
	Then It shows a message with Alert and message "Hello World"
