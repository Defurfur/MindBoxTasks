DELETE FROM dbo.Categories;
DELETE FROM dbo.Products;
DELETE FROM dbo.ProductCategory;

DBCC CHECKIDENT('Categories', RESEED, 0);
DBCC CHECKIDENT('Products', RESEED, 0);
DBCC CHECKIDENT('ProductCategory', RESEED, 0);

INSERT INTO
	dbo.Categories([Name])
VALUES 
	('Female'),
	('Kids'),
	('Male'),
	('Trousers'),
	('Outwear');


INSERT INTO 
	dbo.Products([Name])
VALUES 
	('Beige wool coat'),
	('Black cashemere coat'),
	('Pink puffer'),
	('Kids puffer'),
	('Kids parka'),
	('White T-Shirt'),
	('Black T-Shirt'),
	('Rainbow umbrella'),
	('Potato'),
	('Black male pants'),
	('Darkblue male pants'),
	('Darkblue male jeans'),
	('Black female jeans'),
	('Beige female jeans'),
	('Kids jeans'),
	('Kids shorts');

INSERT INTO 
	dbo.ProductCategory(ProductId, CategoryId)
VALUES
	(1, 1),
	(1, 5),
	(2, 1),
	(2, 5),
	(3, 1),
	(3, 5),
	(4, 5),
	(4, 2),
	(5, 2),
	(5, 5),
	(6, 1),
	(6, 3),
	(7, 1),
	(7, 3),
	(10, 3),
	(10, 4),
	(11, 4),
	(11, 3),
	(12, 3),
	(12, 4),
	(13, 1),
	(13, 4),
	(14, 1),
	(14, 4),
	(15, 2),
	(15, 4),
	(16, 2),
	(16, 4);
