@calculator @regression
Feature: Calculator Addition
  As a user
  I want to add numbers using the calculator
  So that I can perform mathematical calculations

  @smoke @positive @critical
  Scenario: Add two positive numbers
    Given I have entered 2 into the calculator
    And I have entered 3 into the calculator
    When I press add
    Then the result should be 5 on the screen

  @negative-testing @normal
  Scenario: Add two negative numbers
    Given I have entered -2 into the calculator
    And I have entered -3 into the calculator
    When I press add
    Then the result should be -5 on the screen

  @edge-case @minor
  Scenario: Add with zero
    Given I have entered 0 into the calculator
    And I have entered 5 into the calculator
    When I press add
    Then the result should be 5 on the screen

  @data-driven @normal
  Scenario Outline: Add multiple number combinations
    Given I have entered <first> into the calculator
    And I have entered <second> into the calculator
    When I press add
    Then the result should be <result> on the screen

    Examples:
      | first | second | result |
      | 10    | 20     | 30     |
      | 100   | 200    | 300    |
      | -5    | 5      | 0      |