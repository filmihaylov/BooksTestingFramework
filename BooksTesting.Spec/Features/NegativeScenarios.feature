Feature: NegativeScenarios
	here we add tests where we wont to check for negative scenario

@negative
Scenario: add book with same id
	Given I have books 
	| Author      | Title       | Id | Description          |
	| OscardWild | Dorian gray | 17 | book about something  |
	Then I should not be able to add the same book
	| Author      | Title       | Id | Description          |
	| OscardWild | Dorian gray | 17 | book about something  |

@negative
Scenario: Search a Book by title for non existing book
	Given I search for the books title 'NotFoundBook'
	Then the book should be not found with title 'NotFoundBook'

