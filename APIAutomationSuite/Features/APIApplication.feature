Feature: APIApplication


@mytag
# http://services.groupkt.com/state/get/USA/
Scenario Outline: Get API response for a state using state abbrevation
	Given I have a endpoint /endpoint/
	When I call get method to get state details using <stateAbbrevation>
	Then I get state information in response
	
Examples: state abbrevations
| stateAbbrevation |
| AL               |
