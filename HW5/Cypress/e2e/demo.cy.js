/// <reference types="cypress-xpath" />

describe('DataUSA Website Tests', () => {

     it('should perform a search', () => {
	
		//Step 1: Visit URL
		cy.visit('https://datausa.io')
	
		//Step 2: Find Search tool
		cy.xpath('(//input[@placeholder="Search reports"])[2]').as('element');
	
		//Step 3: Type a query
		cy.get("@element").type("Washington")
	
		//Step 4: Find out click button and click a query
		cy.xpath("//div[@class='home-right']//a[@class='bp3-button'][normalize-space()='Search']").click()
	
		//Step5: Validate URL
		cy.url().should('include', 'https://datausa.io/search/?q=');
	
    });


     it('should perform redirection', () => {
	
		//Step 1: Visit to URL
		cy.visit('https://datausa.io')
	
		//Step 2: Find xpath of Report hyperlink
    		cy.xpath('//a[@href="/search"][normalize-space()="Reports"]').as("input")
	
		//Step 3: Click on link
		cy.get("@input").should('be.visible').click()
	
		//Step 4: Validate URL
		cy.url().should('include', 'https://datausa.io/search');

		//Step 5: Exit
		// Validate the URL after the search
        	//cy.url().should('include', '/profile/geo/washington');
     });

});

