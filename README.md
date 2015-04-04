uber-coding-challenge
Problem Description
SF Movies
Create a service that shows on a map where movies have been filmed in San Francisco. The user should be able to filter the view using autocompletion search.
The data is available on DataSF: Film Locations.
Solution
Use SODA API get the movie information(movie titles and locations, etc.) locations are geocoded on the server side using google map API. Get movie title input from client side and with jQuery autocomplete.
Language and APIs
•	Language: C#  
•	Frame: ASP.Net MVC 
•	APIs: SODA API
Back-end
API Example
Get all the movies list, including all the information:
http://sfmovieslocation.azurewebsites.net/api/movie 

Search by title:
http://sfmovieslocation.azurewebsites.net/api/movie?title=blue+jasmine 

Search by year:
http://sfmovieslocation.azurewebsites.net/api/movie?year=1998 

Fuzzy search, search all movie related information:
http://sfmovieslocation.azurewebsites.net/api/movie?fuzzysearch=Paramount
Front-end
•	The autocompletion search is only applied on the titles of the movies, but the API exposes resources that would allow us to extend the search to any field of a movie location object, e.g., 'writer, 'director' and 'actor_1'.
•	Used the Google Maps API 3 to show the map and add the markers for every movie location.


The project is hosted on azure
The source code is located on github.

Link to your resume or public profile. https://www.linkedin.com/profile/view?id=89391266

Link to to the hosted application: http://sfmovieslocation.azurewebsites.net/
