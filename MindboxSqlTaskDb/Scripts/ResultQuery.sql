SELECT 
	p.[Name],
	c.[Name]
FROM 
	dbo.Products AS p
LEFT JOIN
	dbo.ProductCategory AS pc
ON 
	p.Id = pc.ProductId
LEFT JOIN
	dbo.Categories AS c
ON 
	pc.CategoryId = c.Id;