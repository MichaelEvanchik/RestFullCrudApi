# RestFullCrudApi

Michael Evanchik

Setup
Not much, I do not have to send you the database, as long as you have Visual Studio 2015 and Microsoft SQL Server mssqllocaldb running  , the first call to CreatePhoto creates the database for you and the first record.  That is the beauty of EntityFramework Code First,   I will send you an export of the database anyway,(I put it in the App_Data folder) but you will have to change the connection string in the database to try to attempt that.
What I am using is much simpler ORM Entity Code First Framework (EntityFramework) here is the proof
 

You will notice the title and description is null, but that’s because I did not call the service with anything put the html of uploading a file.  If you call the api as it is defined it will populate
If you want to know if you can use this try connecting to this with SQL Management Studio “(LocalDb)\MSSQLLocalDB”

I know you asked for no interface, but in order to create the database you need to create a record.  Create.html  (which seems to only work in IE 11) due to security issues(you will have to allow the javascript security message) calls the api/CreatePhoto/  (the slash at the end was important.
