# HighScore API

Microservice responsable for storing high scores of different players (users).

## User manipulation

### Get user list

Get all users stored on the server:

```
GET /user/ HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json

{
    [
        "id":1
        "name":"user name",
        "country":"HR"
    ], ...
}
```

Get data form specific user:

```
GET /user/{id} HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json

{
    "id":1
    "name":"user name",
    "country":"HR"
}
```

### Adding new user

Add new user (name and country). Server response with user id.

**Request:**

```
POST /user/ HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json

{
    "name":"user name",
    "country":"HR"
}
```

**Response:**

200 ok

```
{ "id":"userId" }
```

### Remove user data

Remove user with user id.

**Request:**

```
DELETE /user/{id} HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json
```

**Response:**

200 ok

## Score list maniuplation

### Add new score

Add new score for user (id).

**Request:**

```
POST /score HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json

{  
    "id":<user id>,
    "score":12
}
```

**Response:**

200 ok

## Get score list

The server can return score list ordered by score. **Biggest score is the first element of the returned array**.

**Request:**

```
GET /score/ HTTP/1.1
Host: api.example.org
Accept: application/json
```

**Response:**

200 ok
```
{
    [
        "score":12, 
        "user":{
            "id":1
            "name":"user name"
            "country":"hr"
        }
    ], ...
}
```

If you wish to get score list for the defined country you can use:

**Request:**

```
GET /score/{country} HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json
```

**Response:**

200 ok
```
{
    [
        "score":12, 
        "user":{
            "id":1
            "name":"user name"
            "country":"hr"
        }
    ], ...
}
```

## Get player position

Get global position for a player with id.

**Request:**

```
GET /score/position/{id} HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json
```

**Response:**

200 ok
```
{
    "userPosition":1
}
```

Get local position for a player with id in defining country.

**Request:**

```
GET /score/position/{id}/{country} HTTP/1.1
Host: api.example.org
Content-Type: application/json
Accept: application/json
```

**Response:**

200 ok
```
{
    "userPosition":1
}
```
