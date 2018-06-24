Feature: BooksSmoke
	Smoke suite lives here
	to test the basic functionality of product

@smoke
Scenario: Add a Book
# fail due to author null bug
	Given I have books 
	| Author      | Title       | Id | Description          |
	| OscardWild | Dorian gray | 11 | book about something |
	Then The book should be added with
	| Author      | Title       | Id | Description          |
	| OscardWild | Dorian gray | 11 | book about something |

@smoke
Scenario: Update a Book
# fail due to description not updated bug
	Given I have books 
	| Author      | Title           | Id | Description          |
	| UpdateBook  | TitleUpdateBook | 12 | book about something |
	And I update a book with values
	| Author      | Title           | Id | Description          |
	| UpdateBookUpdated  | TitleUpdateBookUpdated | 12 | book about something Updated |
	Then The book should be Updated with values
	| Author      | Title           | Id | Description          |
	| UpdateBookUpdated  | TitleUpdateBookUpdated | 12 | book about something Updated |

@smoke
Scenario: Delete a Book
	Given I have books 
	| Author      | Title       | Id | Description          |
	| OscardWild | Dorian gray | 13 | book about something |
	And I delete a book with id '13'
	Then The book should be Deleted with id '13'

@smoke
Scenario: Get All Books
	Given I Get All Books
	Then All Books should be received

@smoke
Scenario: Search a Book by name
# fail due to author null bug
	Given I have books 
	| Author      | Title       | Id | Description          |
	| OscardWild | Title test | 14 | book about something |
	And I search for the books title 'Title test'
	Then the book should be found
	| Author      | Title       | Id | Description          |
	| OscardWild | Title test | 14 | book about something |
