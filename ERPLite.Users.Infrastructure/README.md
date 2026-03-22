## ERPLiteUsers DbContext and Data Models

_TODO: Define the data models and database context for the ERPLite.Users project. 
This will include creating classes for user entities, roles, permissions, and any other relevant data structures. 
Additionally, set up the necessary configurations for Entity Framework Core to manage the database interactions effectively._

1. **User Entity definition**
	- [x] Id - users uniqueidentifier, requerd, primary key with auto insert.
	- [x] Name - users name, required unicode text field in range 2 - 200 charachters.
	- [x] Email - users email, required unicode text field in range 5 - 500 charachters, unique with valid email format.
	- [x] Username - users username, required unicode text field in range 5 - 50 charachters, unique for each user.
	- [x] Password - users password stored as SHA512 hash, text field whit length 128 charachters, required text field with 64 charachters
	
2. **Role Entity definition**
	- [x] Id - roles uniqueidentifier, requerd, primary key with auto insert.
	- [x] Name - role name, required unicode text field in range 2 - 200 charachters.

3. **Resource Entity definition**
	- [x] Id - resources uniqueidentifier, requerd, primary key with auto insert.
	- [x] Lang - resources language, required text field in range 2 - 10 charachters, should follow ISO 639-1 format.
	- [x] Name - resources name, required unicode text field in range 2 - 200 charachters, unique for each language.
	- [x] Content - resources content, required unicode text field with no specific length limit.