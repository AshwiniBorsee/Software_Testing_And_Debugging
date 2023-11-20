// cypress/integration/datausa_spec.js

describe('DataUSA Website Tests', () => {
  beforeEach(() => {
    // Open the DataUSA website before each test
    cy.visit('https://datausa.io');
  });

  it('should perform a search', () => {

      cy.get('.bp3-input-group.bp3-fill.active .bp3-icon.bp3-icon-search input.bp3-input[placeholder="Search reports"]').type('Washington');

    // Optionally, you can press Enter after typing
      cy.get('input.bp3-input[placeholder="Search reports"]').type('{enter}');
    // Validate the URL after the search
    cy.url().should('include', '/profile/geo/washington');
  });
});

