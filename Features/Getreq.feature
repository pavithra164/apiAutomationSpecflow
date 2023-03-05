Feature: to test methods list users and Single user.

@tag1
Scenario: Get a List of users for page 2(List users)
	Given the user sends a get request with URL as "https://reqres.in/api/users?page=2"
    Then request should be a success with 200 code 
  

Scenario: Get a user with id=2(Single user)
	Given the user sends a get request as "https://reqres.in/api/users/2"
	Then request2 should be a success with 200 code