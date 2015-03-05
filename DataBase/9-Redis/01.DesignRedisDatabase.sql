-- Problem 1.Design a redis database to hold ads and authors
-- your task is to design a redis database to hold a list of ads, along with their authors.

SADD authors:usernames maria_p steve

HSET authors:maria_p name "Maria Peneva"
HSET authors:maria_p email "maria@gmail.com"
HSET authors:maria_p phone "0899 12 34 56"

HSET authors:steve name "Steve Wilson"
HSET authors:steve email "steve@yahoo.com"
HSET authors:steve phone "0800 77 553 452"

SET ads:count 4

HSET ad:1 title "BMW 320 for Sale"
HSET ad:1 description "BMW 320d, 2.0 diesel, 4 doors, automatic transmission.Year: 2007. Miles: 107,000.Price:2400 EUR."
HSET ad:1 location "Sofia"
HSET ad:1 date "2014-12-26 12:37"
HSET ad:1 author "maria_p"

HSET ad:2 title "Job as Housekeeper"
HSET ad:2 description "I am looking for a job as housekeeper."
HSET ad:2 location "Plovdiv"
HSET ad:2 date "2014-12-30 23:43"
HSET ad:2 author "steve"

HSET ad:3 title "3 bed apartment to let"
HSET ad:3 description "Very good. A must see. Price: 750 EUR."
HSET ad:3 location "Sofia"
HSET ad:3 date "2015-01-17 10:44"
HSET ad:3 author "maria_p"

HSET ad:4 title "Free MP3 Player"
HSET ad:4 description "Free MP3 player, broken."
HSET ad:4 location "Rousse"
HSET ad:4 date "2014-11-28 21:15"
HSET ad:4 author "steve"

-- Add one more author
SADD authors:usernames gosho

HSET authors:gosho name "Georgi Georgiev"
HSET authors:gosho email "gosho@yahoo.com"
HSET authors:gosho phone "0888 17 545 423"

-- Add a new ad from author gosho
INCR ads:count
GET ads:count

HSET ad:5 title "Sell book"
HSET ad:5 description "Fundamentals of Computer Programming with C#.Price:5 EUR."
HSET ad:5 location "Burgas"
HSET ad:5 date "2015-02-26 11:15"
HSET ad:5 author "gosho"