Feature: patch method testing

@tag1
Scenario: Update a resource 
	Given the user sends a patch request with URL as "https://reqres.in/api/users/2"
	Then user should recieve a success response