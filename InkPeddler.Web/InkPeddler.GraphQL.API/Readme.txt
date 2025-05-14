

Run this to scaffold the database in the nuget PM console under the graphql.api project 

Scaffold-DbContext "Server=tcp:ink-peddler.database.windows.net,1433;Initial Catalog=InkPeddler;Persist Security Info=False;User ID=ip-admin;Password=4!EoOl9F@MzR!l3uG;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
