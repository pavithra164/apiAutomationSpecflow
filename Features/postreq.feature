Feature: To test post request

@mytag
Scenario: POST request testing
	Given the user sends a post request with URL as "https://reqres.in/api/users"
	Then user should get a success response