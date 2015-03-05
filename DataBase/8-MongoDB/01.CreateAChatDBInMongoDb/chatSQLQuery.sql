-- Problem 1.Create a chat database in MongoDb
-- You should create a chat database in MongoDb CLI. The database should keep messages. 
-- Each message has a text, date, is read and an embedded field user. 
-- Users have username, full name and website. Fill sample data in database. 
-- Find in MongoDb documentation how to back up the database and make a backup.

db.createCollection("chat", {capped: true, size: 2000000, max: 1000} );

use chat;

var bulk = db.messages.initializeUnorderedBulkOp();
bulk.insert({ 	text: "Az sym Gosho",
				date: Date(),
				isRead: true,
				user: { name: "gosho", 
						fullName: "Georgi Georgiev",
						webSite: "www.mishoka-gosho.com"
					} 
			});
bulk.insert({ 
				text: "Az sym Lili",
				date: Date(),
				isRead: true,
				user: { name: "lili", 
						fullName: "Liliana Petrova",
						webSite: "www.lilito-bg.com"
					} 
			});
bulk.insert({ 
				text: "Moeto ime e Ivan",
				date: Date(),
				isRead: true,
				user: { name: "ivancho", 
						fullName: "Ivan Mishev",
						webSite: "www.mishoka-ivan.com"
					} 
			});			
bulk.insert({ 
				text: "Zdraveite, momci",
				date: Date(),
				isRead: false,
				user: { name: "lili", 
						fullName: "Liliana Petrova",
						webSite: "www.lilito-bg.com"
					} 
			});
bulk.execute();

-- Create back up data by connecting to a running mongod or mongos instance
mongodump --db chat --port 27017

-- Create back up data by accessing data files without an active instance of mongod
mongodump --dbpath c:/data/db --db chat -o c:/data/dump