-- Для удобства проверки я создам таблицы Product и Category
-- Так как в SQL нет возможности создать m2m связь без доп таблицы, то её тоже потребуется создать (M2M_Product_Category)


CREATE TABLE Product (
    id INT PRIMARY KEY IDENTITY(1, 1),
    [name] NVARCHAR(64)
);

CREATE TABLE Category (
    id INT PRIMARY KEY IDENTITY(1, 1),
    [name] NVARCHAR(64)
);

CREATE TABLE M2M_Product_Category (
    productId INT, -- clustered index
    categoryId INT -- not clustered index
);

SELECT p.name, c.name FROM Product p
    left join M2M_Product_Category m2m ON m2m.productId = p.id
    right join Category c ON m2m.categoryId = c.id;