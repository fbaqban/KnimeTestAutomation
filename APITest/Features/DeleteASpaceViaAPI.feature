Feature: DeleteASpaceViaAPI

A logged in user delete a created space using api

@tag1
Scenario: Delete a space with logged in user _ successful _ API
	When The logged in user requests the first api in oreder to call spaces
	Then The logged in user requests create a new space first api
	And  The logged in user requests create a new space second api
	And  The logged in user requests create a new space third api
	And  The logged in user requests create a new space fourth api
	When The logged in user requests the first api in oreder to call spaces

