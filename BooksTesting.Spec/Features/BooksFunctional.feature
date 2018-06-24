Feature: BooksFunctional
	in this feature file we will explore some functional tests

@functinal
Scenario: deleted books should not be returend from all endpoint
	Given I have books 
	| Author      | Title       | Id | Description          |
	| SomeoneTest | SomeTitleForDelete | 15 | book about something |
	And I delete a book with id '15'
	Then book should not be present in get all endpoint
	| Author      | Title       | Id | Description          |
	| SomeoneTest | SomeTitleForDelete | 15 | book about something |


@functinal
Scenario: deleted books should not be returend from search endpoint
	Given I have books 
	| Author      | Title       | Id | Description          |
	| OscardWild | TitleNotFound | 16 | book about something |
	And I delete a book with id '16'
	Then book should not be present in search by title "TitleNotFound"

@functinal
Scenario: I can search by Author for book
# fail due to author null bug
	Given I search for the books author 'InitialGeneratedAuthor'
	Then the book should be found by author
	| Author				 | Title                 | Id| Description                 |
	| InitialGeneratedAuthor | InitialGeneratedTitle | 2 | InitialGeneratedDescription |

@functinal
Scenario: I can search by Id for book
# fail due to author null bug
	Given I search for the books id '2'
	Then the book should be found by id
	| Author				 | Title                 | Id| Description                 |
	| InitialGeneratedAuthor | InitialGeneratedTitle | 2 | InitialGeneratedDescription |

@functinal
Scenario: I can search by description for book
# fail due to author null bug
	Given I search for the books description 'InitialGeneratedDescription'
	Then the book should be found by description
	| Author				 | Title                 | Id| Description                 |
	| InitialGeneratedAuthor | InitialGeneratedTitle | 2 | InitialGeneratedDescription |