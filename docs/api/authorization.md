# Authorization

This api is responsible to authorize a user. It's also responsible to registed a new user and do some action relate to authorizaion.

**Login User**
----
  Returns json data about the authorized user.

* **URL**

  /api/authorization/login

* **Method:**

  `POST`
  
*  **URL Params**

   **Required:**
 
  None

* **Data Params**

  ```json
        {
          "email": "amir.gholzam@live.com",
          "password": "123456",
          "isPersistent": "true"
        }
  ```

* **Success Response:**

  * **Code:** 200 <br />
    **Content:**

      ```json
        {
          "email": "amir.gholzam@live.com",
          "fullName": "Amir Movahedi",
          "tagLine": "Think positively",
          "key": "38fc2758-1f96-435d-80ea-c7944037964d",
        }
      ```
* **Error Response:**

  * **Code:** 422 Unprocessable Entity <br />
    **Content:**

      ```json
        {
            "errors": [
                "Email address can't be null or empty.",
                "Password can't be null or empty.",
                "Email address or password is wrong."
            ]
        }
      ```
  OR

  * **Code:** 401 Unauthorized <br />
    **Content:**

      ```json
        {
            "errors": [
                "Email address or password is wrong.",
                "amir.gholzam@live.com user user is inactive.",
                "amir.gholzam@live.com user has been deleted."
            ]
        }
      ```

* **Sample Call:**

  ```javascript
    axios({
    method: 'post',
    url: '/api/authorization/login',
    responseType: 'json',
    data: {
      email: 'amir.gholzam@live.com',
      password: '123456',
      isPersistent": "true
    }
  })
  ```

  **Signup User**
----
  Returns json data user key.

* **URL**

  /api/authorization/signup

* **Method:**

  `POST`
  
*  **URL Params**

   **Required:**
 
  None

* **Data Params**

  ```json
        {
          "email": "amir.gholzam@live.com",
          "fullName": "Amir Movahedi",
          "password": "123456",
          "confirmPassword": "123456"
        }
  ```

* **Success Response:**

  * **Code:** 200 <br />
    **Content:**

      ```json
        {
            "key": "38fc2758-1f96-435d-80ea-c7944037964d"
        }
      ```
* **Error Response:**

  * **Code:** 422 Unprocessable Entity <br />
    **Content:**

      ```json
        {
            "errors": [
                "Full name can't be null or empty.",
                "Email can't be null or empty.",
                "Password can't be null or empty.",
                "Confirm password can't be null or empty.",
                "Password and confirm password should be equal."
            ]
        }
      ```

* **Sample Call:**

  ```javascript
    axios({
    method: 'post',
    url: '/api/authorization/signup',
    responseType: 'json',
    data: {
      email: "amir.gholzam@live.com",
      fullName: "Amir Movahedi",
      password: "123456",
      confirmPassword: "123456"
    }
  })
  ```

  **Logout User**
----
  Returns Ok status.

* **URL**

  /api/authorization/logout

* **Method:**

  `GET`

*  **URL Params**

   **Required:**

    None

* **Data Params**

    None

* **Success Response:**

  * **Code:** 200 <br />
    **Content:**

      None

* **Error Response:**

  * **Code:** 403 Forbidden <br />
    **Content:**

      ```json
        {
            "errors": [
                "User is not authorized to logout."
            ]
        }
      ```

* **Sample Call:**

  ```javascript
    axios({
    method: 'get',
    url: '/api/authorization/logout'
  })
  ```

**Update User Password**
----
  Returns Ok status.

* **URL**

  /api/authorization/password

* **Method:**

  `PUT`
  
*  **URL Params**

   **Required:**
 
  None

* **Data Params**

  ```json
        {
          "newPassword": "123456",
          "confirmPassword": "123456"
        }
  ```

* **Success Response:**

  * **Code:** 200 <br />
    **Content:**

      None

* **Error Response:**

  * **Code:** 422 Unprocessable Entity <br />
    **Content:**

      ```json
        {
            "errors": [
                "New password can't be null or empty.",
                "Confirm password can't be null or empty.",
                "New password and confirm password should be equal."
            ]
        }
      ```
  OR

  * **Code:** 403 Unauthorized <br />
    **Content:**

      ```json
        {
            "errors": [
                "User is not authorized to update password."
            ]
        }
      ```

* **Sample Call:**

  ```javascript
    axios({
    method: 'put',
    url: '/api/authorization/password',
    data: {
      newPassword: 'amir.gholzam@live.com',
      confirmPassword: '123456'
    }
  })
  ```
