# HAIR SALON !

#### By: Phil Curran

Hair Salon is a 2-model, database-connected app that allows you to create stylists, customers, and associate them with one another, all through a spiffy web interface.

## Technologies Used

* C#
* .NET 6.0
* MySql 8.0.28
* Bulma.css

## Description

This 2-model MVC app allows you to create lists of stylists and their associated customers for the purposes of booking & scheduling.

The Stylist model contains the stylists's automatically assigned id#, name, and list of clients..

The Client model contains an automatically assigned id#, name, and associated stylist.

## App Setup & Install Instructions:
* Clone the repo: git clone https://github.com/phil-curran/Tracker.git
* Change Directory into: HairSalon
* Run to install packages: dotnet restore
* Run to build assets: dotnet build
* Run to launch: dotnet watch run

## Importing the Database
* Use the included demo database: phil_curran.sql
* Import this self-contained file into MySql Workbench
* Create new schema name: your_database.sql
* Update your appsettings.json file as such:
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[your_database];uid=root;pwd=[YOUR PASSWORD];"
  }
}

## Known Bugs
* Project not building & loading due to Model or Controller issues.

## Contact
Get ahold of me at pecurran@hotmail.com for info or to help iterate!

## License
[MIT](https://choosealicense.com/licenses/mit/)