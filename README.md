![Print](https://raw.githubusercontent.com/bittencourtRodrigo/sales-recorder/master/ReadmeImages/Prints/InitialPage.png)
[See more prints by clicking here](https://github.com/bittencourtRodrigo/sales-recorder/tree/master/ReadmeImages/Prints)
## Sales Recorder - web application in Visual Studio community 2019

## Create states/districts, subsidiaries for each state and record sales. Backend: C#; Frontend: HTML, CSS and Js; Database: MySql; Additions: Entity Framework, .Net core 2.1 and ASP.NET Core MVC.

This project was inspired on [C# course](https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/) by Professor [Nélio alves](https://www.linkedin.com/in/nelio-alves/). It has the same purpose, but the path there was reasonably taken out of context by me, I ventured out to practice and shaped it my way. 

Topics you will find:
- Follows the Model-View-Controler pattern
- One function/method for each operation 
- MySql connection via Entity Framework
- Strong segmentation
- Custom error pages
- Error handling
- Startup dependency injection configuration
- MySql Dbset configuration
- Queries using LIQN and Lambda
- Search sales by minimum date and maximum date
- See here the [UML of the project](https://github.com/bittencourtRodrigo/sales-recorder/tree/master/ReadmeImages/UML)

## Navigation map
![Diagram](https://raw.githubusercontent.com/bittencourtRodrigo/sales-recorder/master/ReadmeImages/Prints/Diagram.PNG)

## Installation steps (run locally)
- Have VS community 2019 [(How to install on Windows)](https://www.youtube.com/watch?v=1uBESL2S8Ik)
- Install MySql [(How to install on Windows)](https://www.youtube.com/watch?v=2c2fUOgZMmY)
- Clone this repository and open the *WebAppSalesMVC.sln* file with **VS community 2019**
- In **VS community 2019** open the *appsettings.json* file and change the string by changing the **userid and password** to the same ones you used when installing **MySql**
- Go to Package Manager Console in the VS footer and run the command. (If you can't find it, run it: Tools -> NuGet Package Manager -> Package Manager Console)
```bash
Update-Database
```
- Now compile and run on **VS community 2019**

## If you want to contribute
I will be happy to be of help. Follow the installation process above and change as you like. Of course, before we implement here your code will go through testing, so make sure you fix bugs first. 
Read the first paragraph and you will get some idea of how I was thinking when typing the code, follow the same guidelines, we can discuss them, call me at [Linkedin](https://www.linkedin.com/in/bittencourtrodrigo/).

## If you find any bug
Feel free to open a ticket or request a pull request. It will be warmly received.

## Problems known so far that will be solved (by me or by you)

- Not responsive on all devices


## You liked the project
I appreciate it. You can demonstrate this by clicking on the star. Let's have a chat on [Linkedin](https://www.linkedin.com/in/bittencourtrodrigo/).
