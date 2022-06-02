Feature: DeleteASpace

An authorized user deletes a public space 

@launchBrowser		@authorizedUser		@successful		@deleteSpace
Scenario: Delete a space with authorized user - succesful - Chrome
	#Given The user opens the browser and launch the application
	#	| Browser | BrowserVersion | OS        |
	#	| Chrome  | 102.0.5005.63  | Winows 10 |
	#When  The user accepts the cookies
	#And   The user clicks on sign in button
	#Given The user login with username fbaqban and password BaghbanF@123
	#When  The user sign in
	#When  The user clicks on his profile picture
	#And   The user clicks on spaces item
	#Then  The spaces page is displayed 
	When  The user clicks on create a new public space
	Then  Create a new public space page and successful creation message are displayed
	When  The user clicks on More button
	And   The user clicks on Delete the space button
	Then  The Delete this space popup is displayed
	When  The user enter the space name in the textbox
	Then  The user checks if the Delete space button is enabled
	And   The user clicks on the Delete space button
	And   The spaces page is displayed
	And   The successful deletion message is displayed
	And   The user checks existance of the deleted space

