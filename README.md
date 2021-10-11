Warehouse Management System Web API<br/>

Architecture: Domain-driven Design<br/>
Framework: .NET 5<br/>

Features:<br/>
-users with roles and access to warehouses<br/>
-warehouse CRUD (Store section) with default warehouses<br/>
-locations for warehouse<br/>
-items on locations with limited quantity defined by location size<br/>
-user operations on locations for verification<br/>
-every endpoint has action summary <br/>

For endpoints with pagination to order by use camelCase with first upper letter example: "/api/user" order by = "RoleId"

Roles:<br/>
-SuperAdmin,<br/>
-Admin,<br/>
-Manager,<br/>
-Worker,<br/>
-Accountant<br/>

If you have access to demo:<br/>
Manager:<br/>
login: manager1<br/>
password: manager1<br/>

Worker:<br/>
login: worker1<br/>
password: worker1<br/>

