Feature: CreateASpace

An authorized user creates a public space 

@launchBrowser		@authorizedUser		@successful		@creatSpace
Scenario: Create a space with authorized user - succesful - Chrome
	#Given The user opens the browser and launch the application
	#	| Browser | BrowserVersion | OS        |
	#	| Chrome  | 102.0.5005.63  | Winows 10 |
	#When  The user accepts the cookies
	#When   The user clicks on sign in button
	#Given The user login with username fbaqban and password BaghbanF@123
	#When  The user sign in
	#When  The user clicks on his profile picture
	#And   The user clicks on spaces item
	#Then  The spaces page is displayed 
	When  The user clicks on create a new public space
	Then  Create a new public space page and successful creation message are displayed
	When  The user return to his space page
	Then  The created space is visible
	
