Feature: CreateASpaceViaAPI

A logged in user create a space using API

@API		@loggedInUser		@successful		@createSpace
Scenario: Create a space with logged in user _ successful _ API
	When The logged in user requests the first api in oreder to call spaces
	Then The logged in user requests create a new space first api
	And  The logged in user requests create a new space second api
	And  The logged in user requests create a new space third api
	And  The logged in user requests create a new space fourth api
