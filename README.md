# _Travel API_

#### _Version 01/29/2020_

#### By _**Nina Potrebich**_

## Description

_An API that allows users to GET and POST reviews about various travel destinations around the world. Here are some user stories to get started._

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET
* MySqlServer (or other SQL-based server)
* PostMan (or any other API Client / browser)

### Installing

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Start MySql server by using command:
```
mysql start
```
3. Access MySql by executing the command (update name and password with yours credentials):
```
mysql -uroot -pepicodus
```
4. Update database using command
```
dotnet ef database update
```
5. Using console of your choice build and run program in Project directory:
```
dotnet run
```
6. Run PostMan or other API client to send REST requests.

## Specifications:

* As a user, I want to GET and POST reviews about travel destinations (http://localhost:5000/api/reviews/).
* As a user, I want to GET reviews by country or city (http://localhost:5000/api/reviews?country=USA&city=Seattle).
* As a user, I want to see the most popular travel destinations by number of reviews or by overall rating (http://localhost:5000/api/destinations/).
* As a user, I want to PUT and DELETE reviews, but only if I wrote them. (Start by requiring a user_name param to match the user_name of the author on the message. You can always try authentication later.)
* As a user, I want to look up random destinations just for fun.

## Technologies Used

_C#, .NET, ASP.NET Core CLI_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*