(function () {
	var books = JSON.parse(document.getElementById("input").value);

	var groupBooksByLanguageSortByAuthor = _.chain(books)
				.sortBy(function (book) {
					return [book.author, book.price];
				})
				.groupBy("language")
				.value();

	var averageBookPriceAuthor = _.chain(books)
				.each(function(book) {
					return (book.price) = (book.price).replace("," , ".");
				})
				.groupBy("author")
				.map(function(authors, key) {
						return {
							author: key,
							price: calculateAvrgPrice(_.pluck(authors, "price"))
						}
				})
				.value();

	function calculateAvrgPrice(prices) {
		var average = 0;
		prices.forEach(function(num) {
			average += parseFloat(num);
		});
		return average / prices.length;
	}

	var allEnglishGermanGroup = _.chain(books)
				.filter(function(book) {
					return (book.language === "English" || book.language === "German") &&
					parseFloat(book.price) < 30;
				})
				.groupBy("author") 
				.value();

	console.log("Group all books by language and sort them by author (if two books have the same author, sort by price)");
	console.dir(groupBooksByLanguageSortByAuthor);
	console.log("Get the average book price for each author");
	console.dir(averageBookPriceAuthor);
	console.log("Get all books in English or German, with price below 30.00, and group them by author");
	console.dir(allEnglishGermanGroup);

}())
