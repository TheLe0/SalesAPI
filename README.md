# SalesAPI #

[![Build Status](https://dev.azure.com/leobtosin/Caesar%20Cipher/_apis/build/status/TheLe0.SalesAPI?branchName=master)](https://dev.azure.com/leobtosin/Caesar%20Cipher/_build/latest?definitionId=2&branchName=master)

A REST API for Sales Management

## Specifications ##

This is the json structure for input and output

```json
{
    "sku": 43264,
    "name": "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
    "inventory": {
        "quantity": 15,
        "warehouses": [
            {
                "locality": "SP",
                "quantity": 12,
                "type": "ECOMMERCE"
            },
            {
                "locality": "MOEMA",
                "quantity": 3,
                "type": "PHYSICAL_STORE"
            }
        ]
    },
    "isMarketable": true
}
```

Note: Only the proprieties  **isMarketable** and **inventory.quantity** are not stored on the database, they are calculated on the code.

Is implemented endpoints for the followings REST methods:

- __**POST**__, for create a new product;

- __**PUT**__ a new product by **sku**

- __**GET**__ a product by **sku**

- __**DELETE**__ a product by **sku**

## Requirements ##

- The RDBMS used was SQL Server, was created a database called SalesDB, and executed the script to create the tables on *./_sql/create_db.sql*

- To persist data was used the ORM Dapper;

- The Project structure is ASP .NET Core for APIs.
