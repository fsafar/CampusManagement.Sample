# Campus Management Payment Sample

This sample payment options code was created with a .NET Core 3.0 MVC application.  This solution contains 3 projects, they are:

1. CampusManagement.Data
2. CampusManagement.Payments
3. CampusManagement.Web


# CampusManagement.Data

This project contains queries that can be used to retrieve data/configurations from the applicable data source for Campus Management.  I only hardcoded some values in these query implementations for demonstration purposes.
These queries could clearly be refactored to use common interfaces for code reuse, but I chose to keep as is due to time constraints.


# CampusManagement.Payments

This project contains logic for payment handlers.  I chose to use the strategy design pattern to implement the payment processing portion of this project because it allows for adding new additional payment implementations in the future without needing to modify any of the existing payment logic.


# CampusManagement.Web

This is the application project.  I created 2 controllers, they are: 

1. StudentChargesController: This controller's index action lists charges by student.  A student is also able to pay the charges by clicking the link for the appropriate charge through this page.
2. PaymentOptionsController: This controller controls display of payment option types (credit card, bank, PayPal) and is also responsible for calling the MakePayment method from the PaymentStrategy if payment inputs are valid.


Features weren't included due to time constraints:
1. Payment input validation
2. Endpoint validation on a specific payment option page.  For example, if a user is attempting to access "/studentCharges/2/creditcard", there should be validation to ensure that this payment method is enabled for this customer.

