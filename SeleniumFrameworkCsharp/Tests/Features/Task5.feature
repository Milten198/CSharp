@task5
Feature: Uploading files and verifying data in table

Background: 
Given I open task 5 page

@positive
Scenario: User is able to upload file with correct data
	When I upload file "correct.txt"
	Then Data from file are shown in table
