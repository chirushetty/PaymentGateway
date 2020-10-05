# PaymentGateway for Credit Card

## Summary

This Payment Gateway currently is mocking the Bank Api integration. The PaymentGateway consist of module:
1) MakePayment : This is post request which takes in the card details. The Card details consist of CardNumber, Amount, Cvv, Currency and ExpiryDate. This module is used by marchant to make payments and it returns unique identifier and status of the payment
2) RetrievePayment: This is a get request. This takes in Unique Identifier of the previous payment and returns the status code of the payment and card details. This module is used by merchant to retreive payment information.

## Requirement

.Net Framework 4.7.2 and more

## Web-Api Calls Example:

1) Process Payment: 
Http Post:</br>
Url : http://localhost:55653/PaymentGateway/ProcessPayments </br>
Example Post Body: </br>
    "cardDetail" : {
        "Amount" : 100,
        "CardNumber" : "1234567891234567",
        "Currency" : "Euro",
        "Cvv" : 123,
        "ExpiryDate" : "07/2022"
    } 
    
2) Retreive Payment:
HttpGet: </br>
Url : http://localhost:55653/PaymentGateway/RetreivePayments </br>
Parameter Identifier : Guid value

## Bussiness Logic:

The web api used the business logic to interact with banking interface. The business logic is a middleware between web-api and the banking service. Currently the Banking service is mocked which should be easily replaced by the actual banking service.

## BankRepository Service:
Take is in 2 method call.
1) Make Payment: This method is called to make payments and returns unique identifier and the status of the payment
2) RetrievePreviousPayment: This methos is called to retrieve previous payment made. This takes in a unique Identifier and returns the status code and the card details.
    

## Validation

Credit Card Expiry Date validation: 
Validating if the credit card is still valid. The expiry should be in MM/yyyy format.

Credit Card Cvv validation:
The Cvv should be 3 digit only .

