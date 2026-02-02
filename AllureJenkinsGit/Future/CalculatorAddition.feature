@Regression @Smoke @Epic:Calculator @Feature:Addition @Story:BasicMath @Severity:critical
Feature: CalculatorAddition
    As a user
    I want to add two numbers
    So that I can get the sum

Scenario: Add two numbers via BDD
    Given I have entered 2 into the calculator
    Given I have entered 3 into the calculator
    When I press add
    Then the result should be 5 on the screen