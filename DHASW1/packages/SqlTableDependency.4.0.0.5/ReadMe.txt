================================================================================================================================================================
SqlTableDependency NuGet Package
================================================================================================================================================================
Release 4.0.0.0 for SqlTableDependency
October 2015
Copyright (c) 2015 Christian Del Bianco
Home site: https://tabledependency.codeplex.com/">https://tabledependency.codeplex.com/


New features
----------------------------------------------------------------------------------------------------------------------------------------------------------------
SqlTableDependency can be disposed or stopped and started again without destroy its database object. It this case you have to specify Service Broker's name.
Here is an example where we create a SqlTableDependency and than we dispose it. In order to reuse the same database objects created to receive 
the notifications, you have to specify to false the automaticDatabaseObjectsTeardown constructor parameter:
 
SqlTableDependency<Check_Model> tableDependency = null;
string dataBaseObjectsNamingConvention;

var mapper = new ModelToTableMapper<Check_Model>();
mapper.AddMapping(c => c.Name, "FIRST name").AddMapping(c => c.Surname, "Second Name");

try
{
    tableDependency = new SqlTableDependency<Check_Model>(ConnectionString, TableName, mapper, new List<string> { "First Name" }, false);
    tableDependency.OnChanged += TableDependency_Changed;
    tableDependency.Start();
    dataBaseObjectsNamingConvention = tableDependency.DataBaseObjectsNamingConvention;
    Thread.Sleep(5000);
}
finally
{
    tableDependency?.Dispose();
}

Then if we want resuse it, we create it again indicating the Service Broker name:

try
{
    tableDependency = new SqlTableDependency<Check_Model>(ConnectionString, dataBaseObjectsNamingConvention, true, mapper);
    tableDependency.OnChanged += TableDependency_Changed;
    tableDependency.Start();
    Thread.Sleep(10000);
    tableDependency.Stop(true);
}
finally
{
    tableDependency?.Dispose();
}


Documentation
----------------------------------------------------------------------------------------------------------------------------------------------------------------
Documentation available at https://tabledependency.codeplex.com/">https://tabledependency.codeplex.com/
