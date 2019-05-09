use ofxtrandb;

CREATE TABLE Transaction (
    Id int NOT NULL auto_increment,
    Hash varchar(255) NOT NULL unique,
    Type varchar(10),
    Date datetime,
    Amount float4,
    FITID varchar(15),
    Description varchar(100),
    PRIMARY KEY (ID)
);