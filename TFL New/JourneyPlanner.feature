Feature: JourneyPlanner

#1.	Verify that a valid journey can be planned using the widget. (A valid journey will consist of a valid locations entered into the widget)
Scenario: Validate the Journey 
	Given I am on the TFL journey planning page "https://tfl.gov.uk/plan-a-journey/"
	When I enter a valid start location "Bank"       
	And I enter the valid destination location "Ealing Broadway"  
	And I click the Enter 
	Then I see Journey results



Scenario: Unable to Provide Result when In-Valid Journey 
	Given  I am on the TFL journey planning page "https://tfl.gov.uk/plan-a-journey/"
	When I enter the wrong start location "xdf"
	And I enter the wrong destination "dft"
	And I click the button "plan-journey-button"
	Then I see "Sorry, we can't find a journey matching your criteria"


Scenario: Unable to Plan when no information entered
	Given I am on the TFL journey planning page "https://tfl.gov.uk/plan-a-journey/"
	When I entered no information in start location 
	And I entered no information in the destination 
	And I click the Enter
	Then I see error to fill the required field

	Scenario: Edit Journey
	Given I am on the TFL journey planning page "https://tfl.gov.uk/plan-a-journey/"
	When I enter a valid start location "Bank"
	And I enter the valid destination location "Ealing Broadway"   
	And I click the Enter
	And I see Journey results
	And I can click "Edit Journey" to change journey details 
	And I click the arrow to reverse the Journey details 
	And I click the button "plan-journey-button"
	Then I see Journey results


	Scenario: Recent Tab 
	Given I am on the TFL journey planning page "https://tfl.gov.uk/plan-a-journey/"
	When I enter a valid new start location "27 Cornell Way, Romford"       
	And I enter the valid new destination location "45 Cornell Way, Romford"  
	And I click the Enter 
	And I see Journey results
	And I click Plan a journey
	And I click "Recents" text 
	Then I can see the recent Jounrey result for "27 Cornell Way to 45 Cornell Way"


