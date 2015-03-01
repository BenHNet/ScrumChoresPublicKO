Here are the steps to create the DB for this project

1. Run the CreateDB.sql script

2. Run the CreateScrumUserlogin.sql script

3. Open the Package Management Console.  (Tools... NuGet Package Manager... Package management Console)

4. Run this command to create the DB tables from EF Code first for the ASP.NET Identitiy management.
	Update-Database -ProjectName ScrumChores.Web.Kendo -StartUpProjectName ScrumChores.Web.Kendo

5. Run this command to create the DB tables from EF Code first.
	Update-Database -ProjectName ScrumChores.Business -StartUpProjectName ScrumChores.Web.Kendo

You should be all set.  Make sure you update the 'DefaultConnection' in all the config files in the project.