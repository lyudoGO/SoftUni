// Problem 1.	Research how to create a MongoDb database in MongoLab (http://mongolab.com)
// Problem 2.	Create a chat database in MongoLab
// The database should keep messages. Each message has a text, date and an embedded field user. Users have username.
// Problem 3.	Create a Chat client, using the Chat MongoDb database
// •	When the client starts, it asks for username
// o	Without password
// •	Logged-in users can see 
// o	All posts, since they have logged in
// o	History of all posts
// •	Logged-in users can post message
// •	Create a simple WPF application for the client

namespace ChatClient
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            MongoUrl url = new MongoUrl("mongodb://student:student@ds037581.mongolab.com:37581/chat");
            MongoClient client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase("chat");
            var collection = database.GetCollection<Message>("messages");

            var messages = collection.FindAll();
            foreach (var item in messages)
            {
                Console.WriteLine("Text:{0} From: {1} Date: {2}", item.text, item.user.username, item.date.Year);
            }
        }
    }
}
