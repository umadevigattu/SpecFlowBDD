Feature: BlueStar Moile App Demo
@LaunchApp
Scenario Outline: Launch application Click on Employee button
    Given User launching BlueStar App
    When User click on "employee_button"
    And User enter "email" address as"abc@gmail.com"
    Then User should verify email address is "[Invalid EmailID]"or not


