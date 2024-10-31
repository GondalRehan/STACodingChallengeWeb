
Feature: TfL Journey Planner Widget

  Scenario: Verify a valid journey can be planned from Leicester Square Underground Station to Covent Garden Underground Station
    Given the user is on the TfL homepage
    When they enter "Leicester Square Underground Station" in the "From" field and select it from autocomplete
    And they enter "Covent Garden Underground Station" in the "To" field and select it from autocomplete
    Then the system should display results for the journey
    And it should show the estimated journey times for both walking and cycling options