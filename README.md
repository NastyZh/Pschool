I have developed a simple parent/student application called Pschool. 
This app allows users to view students and their parents. It features a straightforward two-view design (parent view, student view), as illustrated in the attached image.

Project Structure:
Pschool API (Backend):
The backend is built as an ASP.NET Web API project containing the necessary API controllers. 
It uses Entity Framework Core as the database provider and is connected to a SQL Server database (or alternative options like SQL Express, PostgreSQL, or SQLite). 
The entity relationship is structured so that every student is associated with a parent.

Pschool Blazor WebAssembly (Frontend):
The frontend is implemented using Blazor WebAssembly, featuring two separate views: one for parents and one for students. 
Both views support basic CRUD operations (add, edit, and delete). Additionally, the student page includes a filter that allows users to view students based on parent selection from a dropdown list.
