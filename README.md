The goal of this assignment is to work with a database in C# and implementing the Model-View-Controller (MVC) software design pattern learned in class. 
You will revise and update the program you created in the previous lab that dealt with car rentals. 

Save & Restore the Rental Car Inventory:
Revise the program to use a Microsoft Access Database (.accdb) file instead of a text file. The previous lab had you save the collection of cars in a text file when the program exited and restore the collection of cars using the data in the text file when the program loaded. Now utilize a database to store and manage records in a database for the cars.

Display Cars:
A form that allows the user to view all the cars saved in the database using a DataGridView control. It only show summary information for each car and not every single field value. The display show only the car make, model, year, availability, and cost per day. Allow the user to select a car and display the detailed information that includes the image, and remaining information for the car using a separate set of form controls. 
Search & Display Cars:
Allows the user to view all the cars in the database and perform searches that will display cars that match the search criteria. The program does a search that find and displays all cars based on a specific category of car (SUV, luxury, economy, sport, etc…). Display the summary information (car make, model, year, availability, and cost per day) for all search results in a DataGridView. The user can view a more detailed view of the car information using a selection tool like described in the above Display Cars section. 

Add New Car:
A form that allows the user to add a new car to the database. The form should contain the necessary controls to get car information like car’s category (economy, luxury, sport, SUV, van, pickup, etc…), car manufacturer, model of car, year, mileage, rental cost per day, availability (rented or available), description, location on the lot (parking spot), and an image.
Delete an Existing Car:
A form that allows the user to view all the cars, select a car, and delete it from the database. This form could utilize the search and display capability that you implemented in a previous requirement.

Modify a Car:
A form that allows the user to select a car from inventory, display the car’s detailed information in the proper form controls, and allow the user to modify the data and update the database with the changes. For example, the user might need to change the image, description, mileage, or other information related to the car. This form could utilize the search and display capability that you implemented in a previous requirement.

Rent a Car:
A form that allows the user to select an available car from inventory and rent it. This form allow the user to enter the customer’s information including their contact information, driver’s license information, insurance information, and number of days to rent the car. This form store the rental transaction and all the necessary information that is associated with it including total cost calculate by your application based on the car’s cost per day and number of days the car will be rented. This operation involve adding a new record to a rental transactions table and updating a record in the cars table in the database. The rental operation need to update the car’s record in the car table; this simply involves changing the car’s availability from available to rented. 
Return a Car:
A form that allows the user to view all cars that are currently rented, select a car, and return it. This form allow the user to update the mileage for the car and record any damage that was found. This operation update the car’s record in the car database table; this simply involves changing the car’s availability from rented to available.

Implement the MVC Design Pattern.
