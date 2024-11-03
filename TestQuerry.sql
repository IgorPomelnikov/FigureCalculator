SELECT 
    products.Name,
    categories.Name
FROM 
    Products products
LEFT JOIN 
    ProductCategories pc ON products.ProductID = pc.ProductID
LEFT JOIN 
    Categories categories ON pc.CategoryID = categories.CategoryID
ORDER BY 
    products.ProductName, categories.CategoryName;
