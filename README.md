# CMPG-323-Project-3-38205742
Apply Design Pattern to an existing project and host the Web App on the Cloud. This project aims to teach me how to adapt existing code and apply design patterns effectively.

**Table of Contents**
1. [Demo](#demo)
2. [Features](#features)
3. [Usage](#usage)
   - [Register an Account](#1-register-an-account)
   - [Log In](#2-log-in)
   - [Access the Tables](#3-access-the-tables)
     - [Customer Management](#31-customer-management)
     - [Order Management](#32-order-management)
     - [OrderDetails Management](#33-orderdetails-management)
     - [Product Management](#34-product-management)
4. [Design Pattern](#design-pattern)
   - [Repository Pattern](#repository-pattern)
   - [Generic Repository](#generic-repository)
   - [3-Tier Architecture](#3-tier-architecture)
5. [Reference List](#reference-list)


## Demo

[EcoPower Logistics WebApp](https://superstorep3service.azurewebsites.net/)

[Azure WebApp Sevice](https://portal.azure.com/#@nwuac.onmicrosoft.com/resource/subscriptions/ae904fbb-19de-40d3-8dba-264680e542a8/resourceGroups/rgP3WEBAPP/overview)

## Features

Key features of the EcoPower Logistics Web App include:

- **Customer Management**: Create, edit, and delete customer records.
- **Product Management**: Manage the list of products, including details like name, description, and quantities.
- **Order Management**: Place and manage customer orders.
- **OrderDetails Management**: View and modify order details, including products, quantities, and discounts.

## Usage

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/665c02ba-d597-416d-95df-7c38efe1a352" alt="image" width="75%">


### 1. Register an Account:

1. Open the web application using the provided Demo Link.
2. On the homepage, locate the "_Register_" link or button on the top navigation bar.
3. Click "_Register_" to create a new user account.
4. Fill in the registration form with your details, including your email address, and password.
5. After completing the form, click "_Register_" to create your account.

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/aef34c3d-d90e-4ec8-ba7a-3b7ff6ff9a3f" alt="Image Description" width="75%" />


### 2. Log In:

1. Locate the "_Login_" link or button on the top navigation bar.
2. Enter your registered email address and password.
3. Click "Login" to access your account.

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/af93cf5b-e66f-40dc-b8bb-c677d20b2687" alt="Image" width="75%" />


### 3. Access the Tables:

After successfully logging in, you should have access to the tables for managing customers, orders, order details and products.

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/d23bc05a-8433-4230-9567-d45c7f51e4b3" alt="Image" width="75%" />



#### 3.1 Customer Management:

1. Navigate to the "_Customers_" section on the topbar.
2. Click "_Create New_" to add a new customer.
3. Fill in the customer's information and click "_Create_" to create the record.
4. To edit, view details or delete a customer, click on the corresponding action buttons on the right side of the record row.

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/d7dd6be0-90c0-4c97-9487-7350774f5d44" alt="Image" width="75%" />

#### 3.2 Order Management:

1. Navigate to the "_Orders_" section on the topbar.
2. Click "_Create New_" to add a new order.
3. Fill in the order's information and click "_Create_" to create the record.
4. To edit, view details or delete a order, click on the corresponding action buttons on the right side of the record row.

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/36b55b39-5fbd-4e1c-847a-d1580ac1d760" alt="Image" width="75%" />
   
#### 3.3 OrderDetails Management:

1. Navigate to the "_OrderDetails_" section on the topbar.
2. Click "_Create New_" to add a new orderdetails.
3. Fill in the details and click "_Create_" to create the record.
4. To edit, view details or delete a orderdetails record, click on the corresponding action buttons on the right side of the record row.

<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/895b76e8-6938-40c1-a104-8567d673a154" alt="Image" width="75%" />



#### 3.4 Product Management:

1. Navigate to the "_Products_" section on the topbar.
2. Click "_Create New_" to add a new product.
3. Fill in the product's information and click "_Create_" to create the record.
4. To edit, view details or delete a product, click on the corresponding action buttons on the right side of the record row.


<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/6aff5718-faec-44f8-ba9d-e84734a30dd8" alt="Image" width="75%" />



## Design Pattern

### Repository Pattern:

The Repository Pattern plays a pivotal role by segregating data access logic from the application's core business logic. It provides a standardized and reusable approach for interacting with the underlying data source, which, in this case, is a database. This separation enhances code modularity and maintainability, as data operations are neatly encapsulated within dedicated repositories for Customers, Products, Orders, and Order Details. 

### Generic Repository
What makes this pattern even more efficient is the incorporation of a Generic Repository, which greatly reduces redundant code. The GenericRepository class is a concrete implementation of the IGenericRepository interface. It eliminates the need for repetitive data access code, offering a consistent and reusable way to interact with different data entities within the application. This efficient design not only reduces redundancy but also simplifies data access across various sections of the project.

### 3-Tier Architecture:

The SuperStore_P3 project adheres to the 3-Tier Architecture, providing a clear division of responsibilities among its layers:

- **Presentation Layer (SuperStore_P3.WEB)**: This layer is responsible for user interface and interaction.
- **Business Logic Layer (SuperStore_P3.BLL)**: It contains the core business rules and logic.
- **Data Access Layer (SuperStore_P3.DAL)**: In addition to managing data interactions with the database, this layer integrates the Repository Pattern, especially the Generic Repository, to ensure a high level of code efficiency and reusability.


<img src="https://github.com/Albert-Willemse/CMPG-323-Project-3-38205742/assets/112475881/7f842528-bdd2-4d43-ad29-e6ce4a817a8b" alt="Image" width="35%" />



## Reference List

1. Bageri, S. 2018. _Create and implement 3-tier architecture in asp.Net._ https://www.c-sharpcorner.com/UploadFile/4d9083/create-and-implement-3-tier-architecture-in-Asp-Net/ Date of access: 2023/09/17.
2. Balbach, L. 2021. _Deploying mvc asp net core web app with database to azure_ https://www.youtube.com/watch?v=N7Vi8zhHkMI Date of access: 2023/09/12.
3. Beňovský, D. 2021. _Deploying existing mvc projects to azure web apps._ https://docs.xperience.io/k12sp/deploying-websites/running-kentico-on-microsoft-azure/running-kentico-in-azure-web-apps/deploying-existing-mvc-projects-to-azure-web-apps Date of access: 2023/09/18.
4. Gudanowicz, M. 2022. _Add multiple projects to solution._ https://marketplace.visualstudio.com/items?itemName=MaciejGudanowicz.AddMultipleProjectsToSolution#:~:text=To%20add%20existing%20projects%20to,Explorer%20select%20Add%20%2D%3E%20Multiple%20Projects Date of access: 2023/09/17.
5. Hamedani, M. 2017. _Should you split your asp.Net mvc project into multiple projects?_ https://programmingwithmosh.com/net/should-you-split-your-asp-net-mvc-project-into-multiple-projects/ Date of access: 2023/09/12.
6. IAmTimCorey. 2022. _Intro to class libraries in c#_ https://www.youtube.com/watch?v=C6LV_xMGdKc Date of access: 2023/09/18.
7. Kumar, S. 2023. _Mvc design pattern._ https://www.geeksforgeeks.org/mvc-design-pattern/ Date of access: 2023/09/17.
8. Martin, R. 2012. _The clean architecture._ https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html Date of access: 2023/09/17.
9. Microsoft. 2021. _Connection strings._ https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings Date of access: 2023/09/17.
10. Microsoft. 2022. _Tutorial: Deploy an asp.Net app to azure with azure sql database._ https://learn.microsoft.com/en-us/azure/app-service/app-service-web-tutorial-dotnet-sqldatabase Date of access: 2023/09/18.
11. Microsoft. 2023a. _Using a separate migrations project._ https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli Date of access: 2023/09/17.
12. Microsoft. 2023b. _Common web application architectures._ https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures Date of access: 2023/09/17.
13. Microsoft. 2023c. _Asp.Net mvc overview._ https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/overview/asp-net-mvc-overview Date of access: 2023/09/17.
14. Microsoft. 2023d. _How to: Create multi-project templates._ https://learn.microsoft.com/en-us/visualstudio/ide/how-to-create-multi-project-templates?view=vs-2022 Date of access: 2023/09/17.
15. Microsoft. 2023e. _Safe storage of app secrets in development in asp.Net core._ https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows#secret-manager Date of access: 2023/09/17.
16. Microsoft. 2023f. _Quickstart: Deploy an asp.Net web app._ https://learn.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net70&pivots=development-environment-vs Date of access: 2023/09/18.
17. Microsoft. 2023g. _Publish an asp.Net core app to azure with visual studio._ https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-6.0&source=recommendations Date of access: 2023/09/18.
18. Naik, K. 2023. _Design patterns in c# .Net (2023)._ https://www.c-sharpcorner.com/UploadFile/bd5be5/design-patterns-in-net/ Date of access: 2023/09/17.
19. Narasimha, P. 2023. _How can we create areas as a separate project in asp.Net core mvc._ https://learn.microsoft.com/en-us/answers/questions/1368220/how-can-we-create-areas-as-a-separate-project-in-a Date of access: 2023/09/17.
20. Rivero, J. 2023. _How to publish a solution with 4 projects in one web app on azure._ https://learn.microsoft.com/en-us/answers/questions/1253968/how-to-publish-a-solution-with-4-projects-in-one-w Date of access: 2023/09/18.
21. Sanjay. 2023. _Solid principles with c# .Net core with practical examples & interview questions._ https://procodeguide.com/design/solid-principles-with-csharp-net-core/ Date of access: 2023/09/12.
22. Santos, R. 2019. _.Net core — using entity framework core in a separate project._ https://medium.com/oppr/net-core-using-entity-framework-core-in-a-separate-project-e8636f9dc9e5 Date of access: 2023/09/12.
23. StackOverflow. 2011. _Mvc vs. 3-tier architecture?_ https://stackoverflow.com/questions/4577587/mvc-vs-3-tier-architecture Date of access: 2023/09/17.
24. StackOverflow. 2015. _Deploying web site to azure as well as class library._ https://stackoverflow.com/questions/30437874/deploying-web-site-to-azure-as-well-as-class-library Date of access: 2023/09/18.
25. StackOverflow. 2018. _How to universally create repositories that inherit from a generic type?_ https://stackoverflow.com/questions/52914467/how-to-universally-create-repositories-that-inherit-from-a-generic-type Date of access: 2023/09/17.
26. StackOverflow. 2022. _Difference between repository and service?_ https://stackoverflow.com/questions/1440096/difference-between-repository-and-service Date of access: 2023/09/17.
27. TechWithPat. 2023. _How to use entity framework core database-first in a separate project_ https://www.youtube.com/watch?v=MbdTnUA66wY Date of access: 2023/09/17.
28. Vivas, T. 2023. _Solid with .Net core._ https://www.c-sharpcorner.com/article/solid-with-net-core/ Date of access: 2023/09/12.
