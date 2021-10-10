Feature: TMFeature
	As a turnUp portal admin
	I would like to create, edit and delete time and material records
	So that I can manage employee time and materials successfully

@tmtest @regression
Scenario: Create time and material record with valid details
	Given I logged into turn up portal successfully
	And I navigate to time and material page
	When I create time and material record
	Then The record should be created successfully