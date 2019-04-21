# Overview

An ASP .NET MVC web application using Entity Framework for users and projects managing.

The application has the following functionalities:
* CRUD operations with the entities;
* applying filter to the shown entities;
* pagination;
* preferences for number of entities shown per page;
* authentication for those functionalities to be accessed.

## Starting the application

For pages **Users** and **Projects** are accessible only after authentication, in order to explore the full functionality of the application valid username and password are needed. The easiest way for them to be obtained is by commenting the **[AuthFilter]** line from **UsersController** and creating a user through the application itself.
