(function ($) {
	
	var app = Sammy( function() {
		var selector = '#app';
		this.get('#/', function(context) {
			$(selector).html('');
		});

		this.get('#/books', function() {
			controller.loadBooks();
			controller.deleteBookHandler();
			controller.attachLoadedBooksLiHandler();
			controller.attachPutBtnHandler();
			$(selector).load('templates/books.html');
			
		});

		this.get('#/create-books', function() {
			controller.postBookHandler();
			$(selector).load('templates/create-books.html');
		});

		this.get('#/edit-books', function() {
			controller.editBookHandler();
			//$(selector).load('templates/edit-books.html');
		});
	});

	$(function() {
		app.run('#/');
	});
}(jQuery))