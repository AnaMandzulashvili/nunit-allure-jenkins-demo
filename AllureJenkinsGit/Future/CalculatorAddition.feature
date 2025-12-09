Feature: CalculatorAddition

Scenario: Add two numbers via BDD 
    Given I have entered 2 into the calculator
    And I have entered 3 into the calculator
    When I press add
    Then the result should be 5 on the screen
