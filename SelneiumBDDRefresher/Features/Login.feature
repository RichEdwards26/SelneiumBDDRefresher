Feature: Login
	In order to grow
	we need to be able to create new accounts

@NewAccount @Login
Scenario: Create a new account
	Given I am not logged in
	When I complete the sign up form
	Then I am logged in
	And my username is displayed
