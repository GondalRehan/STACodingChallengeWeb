
Feature: TfL Journey Planner Widget

  Scenario: Verify a valid journey can be planned from Leicester Square Underground Station to Covent Garden Underground Station
    Given the user is on the TfL homepage
    When they enter "Leicester Square Underground Station" in the "From" field and select it from autocomplete
    And they enter "Covent Garden Underground Station" in the "To" field and select it from autocomplete
    Then the system should display results for the journey
    And it should show the estimated journey times for both walking and cycling options
"""
 Scenario: Validate journey time when preferences are edited
    Given a valid journey is planned from "Leicester Square Underground Station" to "Covent Garden Underground Station",
    When the user selects "Edit preferences" and chooses "Routes with least walking"
    And updates the journey
    Then the journey plan should update to reflect the new preference
    And display an updated journey time accordingly

  Scenario: Validate access information for the destination station
    Given a valid journey is planned to "Covent Garden Underground Station"
    When the user clicks on "View Details"
    Then the system should display complete access information for "Covent Garden Underground Station"
    And this information should include step-free access, escalators, lifts, and any other accessibility details

  Scenario: Verify that an invalid journey is not processed
    Given the user enters an invalid location in either the "From" or "To" field
    When they attempt to plan a journey
    Then the widget should not provide journey results
    And it should display an appropriate error message indicating an invalid location

  Scenario: Verify journey cannot be planned with empty "From" and "To" fields
    Given the "From" and "To" fields are both empty
    When the user attempts to plan a journey
    Then the widget should not process the journey request
    And it should display a message prompting the user to enter valid locations
"""
