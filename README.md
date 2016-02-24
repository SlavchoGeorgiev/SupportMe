# SupportMe

## Build status
[![Build status](https://ci.appveyor.com/api/projects/status/0xqake9jbu20d8oe?svg=true)](https://ci.appveyor.com/project/SlavchoGeorgiev/supportme)

###Overview
  Support Me System is web application which aims to facilitate communication between company providing support service and their clients. Support Me System is designed to be simple enough and to offer all main required features. Software design is flexible allowing to be easy extensible without need of big modifications of existing code.

###Data Layer
  This web app use some data layers for access MSSQL Database server. First layer is Entity Framework 6, followed by implementation of Repository pattern, and data service layer. This abstraction on different layer has good separation of concerns and facilitate unit tests writing.
  
  Base database entities are: Company, Location, User(in diferent roles), Contact, Address, Ticket, Message, Team
  Company has many Locations(Branches)
  Company has Contact
  Location has many Users
  Location has Contact
  User has Contact
  User has many Tickets
  Contact has Address
  Users has many Roles
  Ticket has many Messages
  Ticket has State, Type and Priority
  Main User roles are Administrator, Support, Company manager and Employee

##<a href="http://support-me.azurewebsites.net/" target="_blank"> Live demo</a>

##Demo screenshots

This is view of home page
<img src="https://raw.githubusercontent.com/p0150n/SupportMe/master/Images/EmployeeHomePage.jpg"/>

Administration view of locations 
<img src="https://raw.githubusercontent.com/p0150n/SupportMe/master/Images/AdminLocationPanel.jpg"/>

User info page accessible from authorized users.
<img src="https://raw.githubusercontent.com/p0150n/SupportMe/master/Images/UserInfoPage.jpg"/>

Avatar upload page
<img src="https://raw.githubusercontent.com/p0150n/SupportMe/master/Images/AvatarUploadPage.jpg"/>

Creat new ticket page for user in role Support
<img src="https://raw.githubusercontent.com/p0150n/SupportMe/master/Images/SupportCreateTicketPage.jpg"/>

Ticket edit/details/add-message page
<img src="https://raw.githubusercontent.com/p0150n/SupportMe/master/Images/TicketDetailsPage.jpg"/>
