Create project

Add a controller for clothes, check for the query string in URL

Add a view in Views/Clothes

Change views and layout pages: modify _Layout, _ViewStart bring the _Layout to each view, ViewData pass data to _Layout

Passing data from Controller to View, passing it through the ViewData and method in Controller, pass by query string and ViewData

Add a model to app

Create a class in Model folder, add a scaffold clothes page from Controllers

Initial migration, bug here is specifying the Column of Price; then Update-Database

Generated database connection string is created in Program.cs and shown in appsettings.json

InitialCreate.up: tạo bảng, InitialCreate.Down: ngược lại của up

The constructor use DI to inject db context into the controller; pass a strongly typed model with scaffolding

From Controller, the detail method pass the object to the View
For the list, Index method get the list and pass to Index view a list with IEnumerable

Work with a database
- Use SQL server express localDB
- View -> SSOX

Seed the data by creating a new class in Model with data inside
- Modify the Program.cs file to add the seed initializer

Modify the display of database type by modifying in Model file

The anchor tag helper supports generating html element. Passing the action and id

Call GET for edit to create a form and POST to submit and change the data

[Bind] protect against over-posting. Include properties want to change

ValidateAntiForgeryToken created by edit view file and check if match with the Edit POST

Trong View phải dùng đúng model, tag helper supports rendering

SEARCH
Add Search: search by name of the items, LINQ query for select the movies

Can change the parameter name to id to be the default parameter

Search method can affect with the bool notUsed to overload for Index method, no modify data so don't need for validate the token

If want to show the query URL then change the request in form to GET method

Search information only brings to the URL with form field value and GET method

SEARCH BY AN ATTRIBUTE
Add a Model to Models folder
Modify Index method in Controller
Add the search by type to Index view
model => model.Clothes![0].type : null forgiving
select: create a list for picking the type of items

ADD A NEW FIELD
Order: add -> migrate 
Change the data with code first migration

ADD VALIDATION
Validation by using requirement in Model file

Delete Method
- Have to add a new method name for HttpPost but with the action name the same
- Or we can add an extra method to overload the existing method

Uploading images
- Using the filepath and filedata
- Update the Model Image to string
- Update the Controller Create method adding a parameter of IFormFile Image
- Create a web host environment
- Change the View of Create method
- For the src: remember to add @
- Modify the edit view to update the image: after change the image, delete the old image
- 