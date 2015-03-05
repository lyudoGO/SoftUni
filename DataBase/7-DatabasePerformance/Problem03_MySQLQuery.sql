--Problem 3.	Create the same table in MySQL
--Your task is to create the same table in MySQL and partition it by date (1990, 2000 and 2010).
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random dates) to certain 
-- partition (e.g. year 1995).

-- Without partitioning
--CREATE SCHEMA `performancedatabase`;

--CREATE TABLE `performancedatabase`.`testentries` (
-- `id` INT NOT NULL AUTO_INCREMENT,
--  `text` TEXT NOT NULL,
--  `date` DATETIME NOT NULL,
--  PRIMARY KEY (`Id`));

-- With partitioning
CREATE SCHEMA `PerformanceDataBase`;

CREATE TABLE `PerformanceDataBase`.`TestEntries` 
(
  `id` INT NOT NULL AUTO_INCREMENT,
  `text` NVARCHAR(300) NOT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`id`, `date`)
) 
PARTITION BY RANGE(YEAR(date)) 
(
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

DELIMITER $$
CREATE PROCEDURE InsertRandomLogs(IN numberRows INT)
    BEGIN
        DECLARE currentRow INT;
        SET currentRow = 1;
        START TRANSACTION;
        WHILE currentRow <= numberRows DO
            INSERT INTO `TestEntries`(`text`, `date`)
            VALUES (conv(floor(rand() * 99999999999999), 20, 36), FROM_UNIXTIME(RAND() * 2147483647));
            SET currentRow = currentRow + 1;
        END WHILE;
        COMMIT;
    END$$
DELIMITER ;

CALL InsertRandomLogs(1000000);

EXPLAIN PARTITIONS SELECT * FROM `testentries`;

SELECT COUNT(*) FROM `TestEntries` PARTITION (p0);
SELECT COUNT(*) FROM `TestEntries` PARTITION (p1);
SELECT COUNT(*) FROM `TestEntries` PARTITION (p2);
SELECT COUNT(*) FROM `TestEntries` PARTITION (p3);

-- (14679 total, Query took 0.0156 sec)
SELECT * FROM `TestEntries` PARTITION (p0)
	WHERE YEAR(date) = 1985;
-- (14679 total, Query took 0.0326 sec)
SELECT * FROM `TestEntries`
	WHERE YEAR(date) = 1985;

-- (14781 total, Query took 0.0432 sec)
SELECT * FROM `TestEntries` PARTITION (p1)
	WHERE YEAR(date) = 1999;
-- (14781 total, Query took 0.5246 sec)
SELECT * FROM `TestEntries`
	WHERE YEAR(date) = 1999;

-- (14646 total, Query took 0.0382 sec)
SELECT * FROM `TestEntries` PARTITION (p2)
	WHERE YEAR(date) = 2009;
-- (14646 total, Query took 0.9712 sec)
SELECT * FROM `TestEntries`
	WHERE YEAR(date) = 2009;

	
-- (14458 total, Query took 0.0548 sec)
SELECT * FROM `TestEntries` PARTITION (p3)
	WHERE YEAR(date) = 2019;
-- (14458 total, Query took 1.2546 sec)
SELECT * FROM `TestEntries`
	WHERE YEAR(date) = 2019;
