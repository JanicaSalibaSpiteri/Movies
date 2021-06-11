# Movies
This project includes a movies microservice built using **.NET Core** and **Microsoft Orleans**, and also a UI built using **React** and **Tailwind CSS**. 

On application startup, all the movies are loaded from the DB (json file) and stored in Memory Cache for faster retrieval during the runtime of the application. 

The project also includes a Graph Query and Graph Mutation using **GraphQL** for the key features listed below.

## Features
- Add new movie
- Update existing movie
- List all movies
- List top 5 movies by rating
- Search by name
- Filter by genre
- List details for a selected movie

## Extras
Attempt to use **ADO.NET grain storage**, with DB entities and models, creation of DB and sample data in DB context through migrations script written in powershell.

## Installation
1.  Build and run the solution
2.  If necessary, change API path in `frontend/src/shared/path.js` to point to the hosted microservice
3.  Navigate to the root folder of frontend and run `npm install` to install the required dependencies
4.  Run the frontend through the command `npm start`, which should automatically launch `http://localhost:3000`

## Running the Graph QL queries
1. Navigate to `http://localhost:6600/ui/playground`
2. Sample query for getting all movies, searching by name, filtering by genre and getting top 5 movies. 
The following one is without arguments, used to get all the movies. You can also pass one of the following arguments:
- `name: "deadpool"` to search by name
- `genre: "action"` to filter by genre
- `top5: true` to get top 5 movies
```
query getAllMovies {
  movies{
    id,
    name,
    description,
    length,
    rating,
    genres,
    image
  }  
}
```
3. Sample query for getting the movie details for a specific movie
```
query getMovieById{
  movie(id:"1") {
    id,
    name,
    description,
    length,
    rating,
    genres,
    image
  }
}
``` 
4. Sample mutation for adding a new movie
```
mutation addMovie($movie: MovieInput!) {
  addMovie(movie: $movie) {
    name
  }
}
```
Query variables
```
{
  "movie":{
    "name": "Annabelle",
    "description": "Annabelle movie",
    "rating": 8.0,
    "length": "1hr 35mins",
    "image": "Annabelle.jpg",
    "genres": ["horror", "thriller", "mystery"]
  }
}
```
5. Sample mutation for updating an existing movie
```
mutation updateMovie($movie: MovieInput!) {
  updateMovie(movie: $movie) {
    name
  }
}
```
Query variables
```
{
  "movie":{
    "id": "25",
    "name": "Annabelle",
    "description": "Annabelle movie",
    "rating": 8.0,
    "length": "1hr 35mins",
    "image": "Annabelle.jpg",
    "genres": ["horror", "thriller", "mystery"]
  }
}
```
