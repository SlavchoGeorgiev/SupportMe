# SupportMe

## Build status
[![Build status](https://ci.appveyor.com/api/projects/status/0xqake9jbu20d8oe?svg=true)](https://ci.appveyor.com/project/SlavchoGeorgiev/supportme)

### Overview
Support Me System is a web application developed as an exercise and it is **not Production-ready**. This application can facilitate communication between companies that provide support and their clients.  
  
Main entities are: Company, Location, User(in diferent roles), Contact, Address, Ticket, Message, Team
-  Company has many Locations(Branches)
-  Company has Contact
-  Location has many Users
-  Location has Contact
-  User has Contact
-  User has many Tickets
-  Contact has Address
-  Users has many Roles
-  Ticket has many Messages
-  Ticket has State, Type and Priority
-  Main User roles are Administrator, Support, Company manager and Employee

##<a href="http://support-me.azurewebsites.net/" target="_blank"> Live demo</a>

##Demo screenshots

This is view of home page
<img src="https://raw.githubusercontent.com/SlavchoGeorgiev/SupportMe/master/Images/EmployeeHomePage.jpg"/>

Administration view of locations 
<img src="https://raw.githubusercontent.com/SlavchoGeorgiev/SupportMe/master/Images/AdminLocationPanel.jpg"/>

User info page accessible from authorized users.
<img src="https://raw.githubusercontent.com/SlavchoGeorgiev/SupportMe/master/Images/UserInfoPage.jpg"/>

Avatar upload page
<img src="https://raw.githubusercontent.com/SlavchoGeorgiev/SupportMe/master/Images/AvatarUploadPage.jpg"/>

Creat new ticket page for user in role Support
<img src="https://raw.githubusercontent.com/SlavchoGeorgiev/SupportMe/master/Images/SupportCreateTicketPage.jpg"/>

Ticket edit/details/add-message page
<img src="https://raw.githubusercontent.com/SlavchoGeorgiev/SupportMe/master/Images/TicketDetailsPage.jpg"/>
