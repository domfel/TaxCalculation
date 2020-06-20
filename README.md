# TaxCalculation

This service allows to calculate VAT tax reates based on Polish regulations.

## Quick start quide
1. Build solution 
2. Run service 
3. Open browser on https://localhost:44399/swagger

## API usage
Api exposes two controllers one for making the tax calulations, and second for obtainig values of tax rates. 

### Calculating Tax
Enpoint allows to send a collection of products or services with prices and desired tax rates for which we want to calculate tax value. Response contains the same list of products and services together with calulated tax value and the full price (base price and tax value). In case that calculation of one of the entries will fail, it will be retruned with error message. Other calculation entries should be calculated normaly.

#### Sample request
     POST "https://localhost:44399/api/TaxCalculation"
     {
        "data": [
            {
            "itemName": "cola",
            "basePrice": 2.50,
            "taxRate": 3
            },
            {
            "itemName": "Book",
            "basePrice": 10,
            "taxRate": 2
            },
            {
            "itemName": "Postal Service",
            "basePrice": 5.0,
            "taxRate": 1
            },
            {
            "itemName": "Laptop",
            "basePrice": 2000,
            "taxRate": 4
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

### Obtaining dictionary values
This endpont exposes all possible values o tax rates that can be used for calcualtion. 

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