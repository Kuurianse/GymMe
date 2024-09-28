GymMe

GymMe is a web-based online health and supplement selling application. It is a perfect place for health and fitness enthusiast to buy supplement and for the admin of the store to sell their product. The CEO of GymMe wants to hire your team to build this application. Before working there, you are given an assignment to make a simple version of this application. You may find some features which don’t make sense. But remember, it is just an assignment to improve and test your skill.
As a web developer, you are asked to create a website using ASP.NET for this supplement selling application. You are also required to use Domain Driven Design method to develop the website. Using web service is optional in this project. The required layers are:
-	View
View layer is responsible for showing information to the user and interpreting the user's commands. This layer is the home for all user interfaces in the project.
-	Controller
This layer is responsible to validate all input from the view layer. It also responsible for delegating requests from the user to the lower layer for further processing.
-	Handler
This layer is responsible to handle all business logic required in the application. It will delegates the task to query from the database, including select, insert, update and delete, to the repository layer. Please notes that there can be a single handler that accesses multiple repository.  
-	Repository
Repository layer is responsible for giving access to the database and model layer via its public interfaces to acquiring references to preexisting domain objects. It provides methods to manipulate the object which will encapsulate the actual manipulation operation of data in the database. Repository also provides methods that select objects based on some criteria and return fully instantiated objects or collection of objects whose attribute meets those criteria.
-	Factory
You need to encapsulate all complex object creation in this layer. For example, when the client needs to create an aggregate object (an object that holds a reference to another object), the object factory must provide an interface for creating these objects. It is important to note that an object returned by the factory must in a consistent state.
-	Model
Model layer is responsible for representing concepts in the business or information about the business situation. The model layer is handled using entity framework tool

Figure 1. Entity Relationship Diagram of GymMe Database

There are three types of user's roles in this website, which are admin, customer, and guest (non-logged-in user). Below are the minimum access you need to create for each role.

•	Admin
	View Customers
	Insert Supplement
	Update Supplement
	Delete Supplement
	View Profile
	Update Profile
	View Unhandled Orders
	View Handled Orders
	Handle Orders
	Logout

•	Customer
	View Supplement
	Order Supplement
	Add Supplement to Cart 
	Clear Cart
	Checkout Supplement in Cart
	View Transactions History
	View Transaction Detail
	View Profile
	Update Profile
	Logout

•	Guest
	Login
	Register

The descriptions for each page are as follows:
1.	Login
This page is the landing page of the website where the user will attempt to log in to the website. This page is only accessible to guests. The following table shows the existing fields in the login form and validations for each field:
Field	Information
Username	Must be filled and appropriate with the data in the database and cannot be empty. 
Password	Must be filled and appropriate with the data in the database and cannot be empty.
If the user entered an incorrect username or password, then an error message will be shown corresponding to the validation triggering it. 
The login page will also have a remember me checkbox. The remember me checkbox will save your login information by implementing a cookie which also has an expired time if a user had checked it so that the next time the user attempts another login, it will log the user in automatically. Provide a link to register page if the user does not have an account yet.

3.	Register
This page allows guests to register themselves as GymMe’s customer. Validate this page is only accessible to guests and provide link that could redirect the user to the login page. Display an error message if the user inputs invalid personal data. The following table shows the existing fields on this page and the validation for each field:
Field	Information
Username	Length must be between 5 and 15 alphabet with space only and cannot be empty.
Email	Must ends with ‘.com’ and cannot be empty.
Gender	Gender Must be chosen and cannot be empty.
Password	Must be the same with confirm password, alphanumeric and cannot be empty.
Confirmation
Password	Must be the same with password and cannot be empty.
Date of Birth	Cannot be empty.

5.	Navigation Bar
Provide a navigation bar after the user logged-in, to make it easier for user to navigate between pages.
o	If the current user is a customer, then show:
•	Order Supplement, redirect user to the Order Supplement page.
•	History, redirect user to the transactions page.
•	Profile, redirect user to update profile page.
•	Logout, logs out the user from the website and destroys all cookies.
o	If the current user is a admin, then show:
•	Home, redirect user to the home page.
•	Manage Supplement, redirect user to manage supplement page.
•	Order Queue, redirect user to order queue page.
•	Profile, redirect user to update profile page.
•	Transaction Report, redirect user to view transaction report page. 
•	Logout, logs out the user from the website and destroys all cookies.

6.	Home
When users visit this page, display the current user role. If the logged in user is admin, retrieve all the customer data and display it in this page. 

7.	Order Supplement
This page is only accessible for customers. This page shows a Supplement detail data such as supplement name, expiry date, price, type name. 
If the current user is Customer provide an order button and quantity text field in each of the supplement. If the button is clicked, validate the quantity must be bigger than 0 then add the selected Supplement to the cart if the user selects clear cart, clear all the cart contents, if the user select checkout, create a new unhandled transaction for all supplement orders in the cart.

8.	Profile
This page allows the user to change their profile information. The user will be redirected to this page when they click the account button provided at navigation bar. There would be 2 forms in this page. The first one will display the information of the current user, make it editable and update the user profile upon clicking the “Update Profile” button. The other one will be used to change the password of the current user. It will ask for the old password and the new password. Update the password of the current user upon clicking “Update Password” button.. The following table shows existing fields in the page and the validation for each field:
Field	Information
Username	Length must be between 5 and 15 alphabet with space only and cannot be empty.            
Email	Must ends with ‘.com’ and cannot be empty.
Gender	Gender Must be chosen and cannot be empty.
Old Password	Must be the same with the current password and cannot be empty.
New Passoword	Alphanumeric and cannot be empty
Date of Birth	Cannot be empty
9.	History
If the user is a customer, displays all transaction that the user has made, also provide a button foreach transaction, upon clicking the button the user will be redirected to the detail page of the transaction. If the user is an admin display all the transaction done also providing a button to view the transaction detail using URL query string parameter.
10.	Transaction Detail
In this page the user can see all the detailed data of the transaction selected. This page is accessible for both admin and user. 

11.	Manage Supplement
This page is only accessible for Admin. In this page the user will be presented with all the supplement data. Create an update and a delete button for each supplement. Upon clicking the delete button, delete the supplement and upon clicking the update button, redirect the user to the update supplement page. The user can also click the insert button and be redirected to the insert supplement page. The following table shows existing fields in the page and the validation for each field:
Field	Information
Name	Must contains ‘Supplement’ and cannot be empty.
Expiry Date	Must be greater than today’s date and cannot be empty.
Price	Price must be at least 3000 and cannot be empty.
Type ID	Cannot be empty

12.	Insert Supplement
This page is not accessible to the customer. This page will allow the admin to input the contents and insert the new suppmenet data. Also provide a back button that upon clicking will redirect the user to Manage Supplement. The following table shows the existing fields in the page and the validation for each field:
Field	Information
Name	Must contains ‘Supplement’.
Expiry Date	Must be greater than today’s date.
Price	Price must be at least 3000.
Type ID	Cannot be empty

13.	Update Supplement
This page is only accessible for the Admin. This page will allow the admin to alter the contents and update the selected supplement data. Also provide a back button that upon clicking will redirect the user to Manage Supplement. The following table shows the existing fields in the page and the validation for each field:
Field	Information
Name	Must contains ‘Supplement’ and cannot be empty.
Expiry Date	Must be greater than today’s date and cannot be empty.
Price	Price must be at least 3000 and cannot be empty.
Type ID	Cannot be empty

14.	Transactions Queue
This page is only accessible for the Admin. This page allows the user to view ongoing transactions that have and has not been handled. In this page the admin can also handle unhandled transaction by pressing the handle transaction button. Upon clicking the handle transaction button, update the status of the transaction from unhandled to handled.

15.	View Transactions Report
This page is only accessible for the Admin. The administrator will be redirected to this page when they click the reports button provided at the navigation bar. This page will display the report of all GymMe sales data using crystal report. The report will have to show grand total income and each transaction’s entire information plus its sub total value.
