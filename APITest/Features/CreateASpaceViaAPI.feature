Feature: CreateASpaceViaAPI

A logged in user create a space using API

@API		@loggedInUser		@successful		@createSpace
Scenario: Create a space with logged in user _ successful _ API
	When The logged in user requests the first api in oreder to call spaces
	And  The logged in user requests the second api in oreder to call spaces
	And  The logged in user requests the third api in oreder to call spaces
