Feature: Home
	In order to business
	As a business idiot
	I want to register my business

@Home
Scenario: Go to register business name page
	Given I am on the home screen
	When I click the register button
	Then I am redirected to Corporate Registry Services
