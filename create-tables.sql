CREATE TABLE IF NOT EXISTS
    Address
(
    Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Street      TEXT    NOT NULL,
    HouseNumber TEXT    NOT NULL,
    City        TEXT    NOT NULL,
    PostalCode  TEXT    NOT NULL,
    Country     TEXT    NOT NULL,
    AddressId   INTEGER NOT NULL,
    FOREIGN KEY (AddressId) REFERENCES Address (Id)
);
CREATE TABLE IF NOT EXISTS
    CustomerContact
(
    Id           INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    CustomerName TEXT    NOT NULL,
    PhoneNumber  TEXT    NOT NULL,
    Email        TEXT    NOT NULL,
    FOREIGN KEY (Id) REFERENCES Address (AddressId)
);
CREATE TABLE IF NOT EXISTS
    Ingredient
(
    Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Title       TEXT    NOT NULL,
    Description TEXT,
    Category    TEXT    NOT NULL
);
CREATE TABLE IF NOT EXISTS
    Alergen
(
    Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    "Order"     INTEGER NOT NULL UNIQUE,
    Title       TEXT    NOT NULL UNIQUE,
    Description TEXT
);
CREATE TABLE IF NOT EXISTS
    MenuItem
(
    Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Title       TEXT    NOT NULL,
    Description TEXT,
    Price       REAL    NOT NULL
);
CREATE TABLE IF NOT EXISTS
    MenuItemIngredient
(
    Id           INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    MenuItemId   INTEGER NOT NULL,
    IngredientId INTEGER NOT NULL,
    FOREIGN KEY (MenuItemId) REFERENCES MenuItem (Id),
    FOREIGN KEY (IngredientId) REFERENCES Ingredient (Id)
);
CREATE TABLE IF NOT EXISTS
    MenuItemAlergen
(
    Id         INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    MenuItemId INTEGER NOT NULL,
    AlergenId  INTEGER NOT NULL,
    FOREIGN KEY (MenuItemId) REFERENCES MenuItem (Id),
    FOREIGN KEY (AlergenId) REFERENCES Alergen (Id)
);
CREATE TABLE IF NOT EXISTS
    OrderItem
(
    Id          INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    OrderItemId INTEGER NOT NULL,
    MenuItemId  INTEGER NOT NULL,
    Quantity    INTEGER NOT NULL,
    FOREIGN KEY (MenuItemId) REFERENCES MenuItem (Id)
);
CREATE TABLE IF NOT EXISTS
    OrderDetail
(
    Id           INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    OrderStatus  INTEGER NOT NULL,
    DeliveryType INTEGER NOT NULL,
    CreatedAt    TEXT    NOT NULL,
    UpdatedAt    TEXT
);
CREATE TABLE IF NOT EXISTS
    Orders
(
    Id                INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    OrderItemId       INTEGER NOT NULL,
    CustomerContactId INTEGER NOT NULL,
    OrderDetailId     INTEGER NOT NULL,
    Total             REAL    NOT NULL,
    FOREIGN KEY (OrderItemId) REFERENCES OrderItem (OrderItemId),
    FOREIGN KEY (CustomerContactId) REFERENCES CustomerContact (Id),
    FOREIGN KEY (OrderDetailId) REFERENCES OrderDetail (Id)
);