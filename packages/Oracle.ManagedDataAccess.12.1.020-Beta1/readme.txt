Release Notes
-------------
Oracle Data Provider for .NET, Managed Driver
Oracle Data Provider for .NET, Managed Driver for Entity Framework

Release 12.1.0.1.0 for ODAC 12c Release 3 Beta

July 2014


Copyright (c) Oracle Corporation 2014

This document provides information that supplements the Oracle Data Provider for .NET (ODP.NET) documentation.

TABLE OF CONTENTS
•Installation and Configuration
•Documentation Corrections and Additions
•ODP.NET, Managed Driver Tips, Limitations, and Known Issues
•ODP.NET, Unmanaged Driver Tips, Limitations, and Known Issues
•Entity Framework Tips, Limitations, and Known Issues


Installation and Configuration
------------------------------
The downloads are NuGet packages that can be installed with the NuGet Package Manager. These instructions apply to install ODP.NET, Managed Driver and ODP.NET, Unmanaged Driver.

1. Un-GAC any existing ODP.NET 12.1.0.1 versions you have installed. For example, if you plan to use only the ODP.NET, Managed Driver, only un-GAC existing managed ODP.NET 12.1.0.1 versions then.

2. In Visual Studio 2010, 2012, or 2013, open NuGet Package Manager from an existing Visual Studio project.

3. Click on the Settings button in the lower left of the dialog box.

4. Click the "+" button to add a package source. In the Source field, enter in the directory location where the NuGet package(s) were downloaded to. Click the Update button, then the Ok button.

5. In the drop down box at the top center-left of the page, select "Include Prerelease".

6. On the left side, under the Online root node, select the package source you just created. The ODP.NET NuGet packages will appear.

7. Click on the Install button to select the desired NuGet package(s) to include with the project. Accept the license agreement and Visual Studio will continue the setup.

8. Open the app/web.config file to configure the ODP.NET connection string and local naming parameters (i.e. tnsnames.ora). Below is an example of configuring the local naming parameters:

  <oracle.manageddataaccess.client>
    <version number="*">
      <dataSources>
        <!-- Customize these connection alias settings to connect to Oracle DB -->
        <dataSource alias="MyDataSource" descriptor="(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL))) " />
      </dataSources>
    </version>
  </oracle.manageddataaccess.client>

After following these instructions, ODP.NET is now configured and ready to use.


Note: If you installed ODP.NET, Managed Driver, these instructions will install and configure the 64-bit version. If you are using 32-bit .NET Framework, you will need to configure 32-bit ODP.NET, Managed Driver by following these steps:

1) Remove the existing 64-bit Oracle.ManagedDataAccessDTC.dll from your Visual Studio's project references.
2) Add the 32-bit Oracle.ManagedDataAccessDTC.dll as a project reference. This assembly resides in your local solution's directory: packages\Oracle.ManagedDataAccess.12.1.020-Beta1\x86.



Documentation Corrections and Additions
---------------------------------------
This section contains information that corrects or adds to existing ODP.NET documentation. 

•None

 

ODP.NET, Managed Driver Tips, Limitations, and Known Issues
-----------------------------------------------------------
This section contains information that is specific to ODP.NET, Managed Driver. 

1. OracleConnection object's OpenWithNewPassword() method invocation will result in an ORA-1017 error with 11.2.0.3.0 and earlier versions of the database. [Bug 14311412]


2. Stored functions/procedures in a PDB cannot be added to a .NET Entity Framework model. [Bug 17344899]



ODP.NET, Unmanaged Driver Tips, Limitations, and Known Issues
-----------------------------------------------------------
This section contains information that is specific to ODP.NET, Unmanaged Driver. 

1. If SenderId is specified in OracleAQMessage object while enqueuing, the sender id of dequeued message will have "@ODP.NE" appended in the end. [Bug 7315542]


2. An "ORA-00942: table or view does not exist" error may be thrown from Dequeue or DequeueArray method invocations when OracleAQDequeueOptions.DeliveryMode is specified as 
OracleAQMessageDeliveryMode.Buffered and OracleAQDequeueOptions.Correlation is specified and there are no messages available in the queue. [Bug 7343633]


3. Application may not receive group notifications if GroupingInterval property on the OracleNotificationRequest object is set to 0. [Bug 7373765]


4. OracleConnection object's OpenWithNewPassword() method invocation will result in an ORA-1017 error with pre-11.2.0.3.0 database versions. [Bug 12876992] 



Entity Framework Tips, Limitations, and Known Issues
----------------------------------------------------
This section contains Entity Framework related information that pertains to both ODP.NET, Managed Driver and ODP.NET, Unmanaged Driver. 

1. Interval Day to Second and Interval Year to Month column values cannot be compared to literals in a WHERE clause of a LINQ to Entities or an Entity SQL query.


2. LINQ to Entities and Entity SQL (ESQL) queries that require the usage of SQL APPLY in the generated queries will cause SQL syntax error(s) if the Oracle Database being used does not support APPLY. In such cases, the inner exception message will indicate that APPLY is not supported by the database.


3. ODP.NET does not currently support wildcards that accept character ranges for the LIKE operator in Entity SQL (i.e. [] and [^]). [Bug 11683837]


4. ODP.NET does not support DbContext APIs.


5. Executing LINQ or ESQL query against tables with one or more column names that are close to or equal to the maximum length of identifiers (30 bytes) may encounter "ORA-00972: identifier is too long" error, due to the usage of alias identifier(s) in the generated SQL that exceed the limit.


6. An "ORA-00932: inconsistent datatypes: expected - got NCLOB" error will be encountered when trying to bind a string that is equal to or greater than 2,000 characters in length to an XMLType column or parameter. [Bug 12630958]


7. An "ORA-00932 : inconsistent datatypes" error can be encountered if a string of 2,000 or more characters, or a byte array with 4,000 bytes or more in length, is bound in a WHERE clause of a LINQ/ESQL query. The same error can be encountered if an entity property that maps to a BLOB, CLOB, NCLOB, LONG, LONG RAW, XMLTYPE column is used in a WHERE clause of a LINQ/ESQL query.


8. An "Arithmetic operation resulted in an overflow" exception can be encountered when fetching numeric values that have more precision than what the .NET type can support. In such cases, the LINQ or ESQL query can "cast" the value to a particular .NET or EDM type to limit the precision and avoid the exception. This approach can be useful if the LINQ/ESQL query has computed/calculated columns which will store up to 38 precision in Oracle, which cannot be represented as .NET decimal unless the value is casted. 


9. Oracle Database treats NULLs and empty strings the same. When executing string related operations on NULLS or empty strings, the result will be NULL. When comparing strings with NULLs, use the equals operator (i.e. "x == NULL") in the LINQ query, which will in turn use the "IS NULL" condition in the generated SQL that will appropriately detect NULL-ness.


10. If an exception message of "The store provider factory type 'Oracle.ManagedDataAccess.Client.OracleClientFactory' does not implement the IServiceProvider interface." is encountered when executing an Entity Framework application with ODP.NET, the machine.config requires and entry for ODP.NET under the <DbProviderFactories> section. To resolve this issue by adding an entry in the machine.config, reinstall ODAC.


11. Creating a second instance of the context that derives from DbContext within an application and executing methods within the scope of that context that result in an interaction with the database may result in unexpected recreation of the database objects if the DropCreateDatabaseAlways database initializer is used.

More Informations: https://entityframework.codeplex.com/workitem/2362

Known Workarounds:
    - Use a different database initializer,
    - Use an operating system authenticated user for the connection, or 
    - Include "Persist Security Info=true" in the connection string (Warning: Turning on "Persist Security Info" will cause the password to remain as part of the connection string).
