# Core2Recruitment

Database Model
Design a database structure based on information:
1.	Each product has a specified type (Type)
2.	Each product can belong to few categories (Category)
3.	Each product has assigned unit to where it is sold (like a box of spoons)(Unit)
4.	Suggest a type, requirements and size of fields
5.	You are allow to add your own properties

Tables:

|Product|Category|Type|Unit|
|---|---|---|---|
|Code|Code|Code|Code|
|Description|Description|Description|Description|
|Price|---|---|---|
|IsAvailable|---|---|---|
|DeliveryDate|---|---|---|

API specification
Design API based on information: 
1.	Each entity (described in „Database model”) has a basic CRUD operations
2.	Add new method which will display information about only available products (with paging)
3.	Add a method which will filter products according to type, category and unit (all filters can be used at the same time)
4.	Add method which will display bellow information:


Nazwa pola	Format
ProductDescription	(Code) Description
Price	xx,xx $
IsAvailable	Yes = „Available”, No = „Not available”
DeliveryDate	12.12.2012
CategoriesCount	
Type	(Code) Description
Unit	(Code) Description

SQL
For newly created database scheme write a queries which will return data about:
1.	Not available products which delivery date is expected in the current month
2.	Available products that are assigned to more than one category
3.	Top 3 categories with information about amount of products assigned to them and avarage price of products for category
(Top 3 should be calculated based on highest avarage of products prices assigned to category)
