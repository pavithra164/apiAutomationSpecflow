Feature: put_request
	Simple calculator for adding two numbers

@tag1
Scenario: Update a resource 
	Given the user sends a put request with URL as "https://reqres.in/api/users/2"
	Then user should recieve response with success status code