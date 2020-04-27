Feature: CorporateRegistryServices
	In order to do business
	As a newbie
	I want to register a business name

@CRS
Scenario: Important message read successfully
	Given I am on the Register Business Name screen
		And I click the checkbox button
		And I click the save button
		And I am redirected to Home screen
	When I click the register button
		And I am redirected to Register Business Name screen
	Then I should see the checkbox is checked

@CRS
Scenario: Fill general details successfully
	Given I am on the Register Business Name screen
		And I click the checkbox button
		And I click the next button
	When I fill all the required fields
	Then I click the next button

@GeneralDetails
Scenario: Fill non existing name
	Given I on the General Details Tab
		And I enter My Company to proposed name field
	When I click the validate button
	Then Radio button visibility should be false
		And Upload consent visibility should be false

@GeneralDetails
Scenario: Fill existing name
	Given I on the General Details Tab
		And I enter Your Company to proposed name field
	When I click the validate button
	Then Radio button visibility should be true
		And Upload consent visibility should be false

@GeneralDetails
Scenario: Fill existing name with consents
	Given I on the General Details Tab
		And I enter Your Company to proposed name field
		And I click the validate button
	When I click the consent button
	Then Upload consent visibility should be true

@GeneralDetails
Scenario: Fill all general details successfully
	Given I on the General Details Tab
		And I enter Your Company to proposed name field
		And I click the validate button
		And I select entity type
		And I enter my activity to bussiness activity field
		And I click the consent button
		And I enter C:\Users\omar.ibrahim\Pictures\Saved Pictures\skaterbui.png to upload consents field
		And I scroll down for 1000 pixel
		And I enter C:\Users\omar.ibrahim\Pictures\Saved Pictures\skaterbui.png to upload letter field
	When I click the next button
	Then I click the next button

@Address
Scenario: Add primary address successfully
	Given I on the Address Tab
		And I enter home to address1 field
	When I click the add address button
	Then I should see new address is added