# Book Store Api

- [Book Store Api](#book-store-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login response](#login-response)

## Auth

### Register

```js
POST {{host}}/api/auth/register
```

#### Register Request

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "example@example.com",
  "password": "password123"
}
```

#### Register Response

```js
200 OK
```

```json
{
  "id": "fd0b7a89-2a6e-4d9f-a3c8-1f5e6c87d3e1",
  "firstName": "John",
  "lastName": "Doe",
  "email": "example@example.com",
  "token": "tokenstring"
}
```

### Login

```js
POST {{host}}/api/auth/login
```

#### Login Request

```json
{
  "email": "example@example.com",
  "password": "password123"
}
```

#### Login response

```js
200 OK
```

```json
{
  "id": "fd0b7a89-2a6e-4d9f-a3c8-1f5e6c87d3e1",
  "firstName": "John",
  "lastName": "Doe",
  "email": "example@example.com",
  "token": "tokenstring"
}
```
