Feature: CreateASpace

An authorized user creates a public space 

@launchBrowser		@authorizedUser		@successful		@creatSpace
Scenario: Create a space with authorized user - succesful - Chrome
	#At first execute test prerequisite which are in HookInitialization.cs
	When  The user clicks on create a new public space
	Then  Create a new public space page and successful creation message are displayed
	When  The user return to his space page
	Then  The created space is visible
	
