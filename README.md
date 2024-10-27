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