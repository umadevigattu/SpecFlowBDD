Feature: Login Page

Create form

Background: 
	Given I Enter the Voltas Url
	And I Login to Application

@TestersTalk
Scenario:  Login Page
	When Create form
	Then Logout from App

