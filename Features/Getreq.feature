Feature: to test the get request

@tag1
Scenario: GET request testing
	Given the user sends a get request with URL as "https://reqres.in/api/users?page=2"
    Then request should be a success with 200 code