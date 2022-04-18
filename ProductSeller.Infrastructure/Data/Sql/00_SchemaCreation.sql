CREATE SCHEMA productseller;

USE productseller;

CREATE TABLE users(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);

CREATE TABLE products(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    value DECIMAL(14, 4) NOT NULL
);

CREATE TABLE purchase_orders(
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    total_value DECIMAL(14, 4) NOT NULL,
    purchased_at DATETIME(6) NOT NULL,
    purchase_mailed BOOL NOT NULL DEFAULT FALSE,
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE purchase_product_rel(
    purchase_id INT NOT NULL,
    product_id INT NOT NULL,
    PRIMARY KEY (purchase_id, product_id),
    FOREIGN KEY (purchase_id) REFERENCES purchase_orders(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);