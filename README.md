## API EndPoints

These are the endpoints for our API:
GET http://localhost:5000/api/destinations/
--> This endpoint will get you a list of all destination entries in the database.
Optionally, you can query to search for specific entries by chosen paramaters. Here are the parameters you can query by:
Parameter: CityName | Type: string | Description: Returns a list of destinations matching the City Name entered.
ex: GET http://localhost:5000/api/destinations?cityname=Osaka
 
 Parameter: Country | Type: string | Description: Returns a list of destinations matching the country entered.
ex: GET http://localhost:5000/api/destinations?country=Peru


Parameter: Rating | Type: int | Description: Returns a list of destinations  matching the ratings entered.
ex: GET http://localhost:5000/api/destinations?rating=1 To 10

Parameter: MinimumRating | Type: int| Description: Returns a list of destinations  with a minimum rating or higher equal to the number entered
ex: GET http://localhost:5000/api/destinations?minimumrating=3
--returns all destinations with rating 3 or more

You can chain queries by separating them with a & sign.
ex: GET http://localhost:5000/api/destinations?minimumrating=3&country=UK

POST http://localhost:5000/api/destinations/
--> This endpoint will create a new entry in the destinations table upon the POST request. It requires a JSON body with a structure like this:
{
    "Cityname": "Osaka",
    "Country": "Japan",
    "Review": "Cool spot",
    "Rating": 3
}

GET http://localhost:5000/api/destinations/{id}
--> This endpoint will get you a specific entry in the destinations table by searching for it with a specific {id} entered.

ex: GET: http://localhost:5000/api/destinations/5
--will return entry with DestinationId 5

PUT http://localhost:5000/api/destinations/{id}
--> This endpoint will edit an entry in the destinations table by searching for a specific entry with an {id}. It requires a JSON body with a structure like this:
{
    "DestinationId": 3,
    "Cityname": "Osaka",
    "Country": "Japan",
    "Review": "Cool spot",
    "Rating": 3
}
And the PUT request looks like this:
http://localhost:5000/api/destinations/3


DELETE http://localhost:5000/api/destinations/{id}
--> This endpoint will delete an entry in the destinations table by searching for a specific entry by {id}.

ex: DELETE http://localhost:5000/api/destinations/8
-- will delete entry with DestinationId 8 from the database