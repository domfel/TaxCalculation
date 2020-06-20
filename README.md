# TaxCalculation

This service allows to calculate VAT tax reates based on Polish regulations.

## Quick start quide
1. Build solution 
2. Run service 
3. Open browser on https://localhost:44399/swagger

## API usage
Api exposes two controllers one for making the tax calulations, and second for obtainig values of tax rates. 

### Calculating Tax
Enpoint allows to send a collection of products or services with prices and desired tax rates for which we want to calculate tax value. Response contains the same list of products and services together with calulated tax value and the full price (base price and tax value). 

#### Sample request
     POST "https://localhost:44399/api/TaxCalculation"
     {
        "data": [
            {
            "itemName": "cola",
            "basePrice": 2.50,
            "taxRateId": 3
            },
            {
            "itemName": "Book",
            "basePrice": 10,
            "taxRateId": 2
            },
            {
            "itemName": "Postal Service",
            "basePrice": 5.0,
            "taxRateId": 1
            },
            {
            "itemName": "Laptop",
            "basePrice": 2000,
            "taxRateId": 4
            }
        ]
    }

#### Sample response
          [
            {
                "itemName": "cola",
                "basePrice": "2,5 PLN",
                "tax": "0,20 PLN",
                "priceWithTax": "2,70 PLN",
                "error": null
            },
            {
                "itemName": "Book",
                "basePrice": "10 PLN",
                "tax": "0,50 PLN",
                "priceWithTax": "10,50 PLN",
                "error": null
            },
            {
                "itemName": "Postal Service",
                "basePrice": "5 PLN",
                "tax": "0 PLN",
                "priceWithTax": "5 PLN",
                "error": null
            },
            {
                "itemName": "Laptop",
                "basePrice": "2000 PLN",
                "tax": "460,00 PLN",
                "priceWithTax": "2460,00 PLN",
                "error": null
            }
        ]

### Obtaining dictionary Values


#### Sample Request
    GET "https://localhost:44399/TaxRates

#### Sample Response
    [
        {
            "name": "Exempt",
            "id": 1
        },
        {
            "name": "Reduced5",
            "id": 2
        },
        {
            "name": "Reduced8",
            "id": 3
        },
        {
            "name": "Standard",
            "id": 4
        }
    ]   