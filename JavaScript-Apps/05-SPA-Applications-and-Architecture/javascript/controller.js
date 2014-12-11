var controller = (function () {

	var loadBooks = function loadBooks() {
		data.loadBooksFromBase()
			.then(function (data) {
				$.get('templates/books.html', function(template) {
	    			var rendered = Mustache.render(template, data);
					$('#app').html(rendered);
	    		});
			});
	}

	var postBookHandler = function postBookHandler() {
		$('#app').on('click', '#add-new-book', function() {
			var tagsText = $(".tags").val();
			var tagsArr = tagsText.split(",") || [];
			for (var i = 0; i < tagsArr.length; i++) {
				tagsArr[i] = tagsArr[i].trim();
			};
			var obj = {
				title: $(".title").val(),
				author: $(".author").val(), 
				isbn: $(".isbn").val(),
				tags: tagsArr
			};
			data.postBooksToBase(obj)
				.then(function() {
					$(".title").val('');
					$(".author").val(''); 
					$(".isbn").val('');
					$(".tags").val('');
				},
				function(error) {
					errorMessage('Cannot post book to server base.');
				});
		});
	}

	var editBookHandler = function editBookHandler() {
		var obj = $('#app').data('book');
		$.get('templates/edit-books.html', function(template) {
			var rendered = Mustache.render(template, obj);
			$('#app').html(rendered);
	    });
	}

	var deleteBookHandler = function deleteBookHandler () {
		$('#app').on('click', 'input[value="Delete"]', function(ev) {
			var deleteConfirmed = confirm('Do you want to delete this book');
			if (deleteConfirmed) {
				var objectId = $(this).parent().data('id');
				data.deleteBookFromBase(objectId)
				.then(function() {
					$(ev.target).parent().remove();
				},
				function(error) {
					console.log(error);
				});
			};
		})
	}

	var attachLoadedBooksLiHandler = function attachLoadedBooksLiHandler() {
		$("#app").on("click", "li", function(event) {
			$("#books > ul li").removeClass("selected");
			$(this).addClass("selected");
			var obj = {
				title: $(".selected .title").text(),
				author: $(".selected .author").text(), 
				isbn: $(".selected .isbn").text(),
				objectId: $(".selected").data('id'),
				tags: $(".selected .book-tags").text()
			};
			$("#app").data("book", obj);
		}).on("click", "input", function(event) {
			event.stopPropagation();
		});
	}

	var attachPutBtnHandler = function attachPutBtnHandler() {
		$('#app').on('click', '#edit-book', function() {
			var id = $("li:last").attr('id');
			var tagsText = $(".tags").val();
			var tagsArr = tagsText.split(",") || [];
			for (var i = 0; i < tagsArr.length; i++) {
				tagsArr[i] = tagsArr[i].trim();
			};
			var obj = {
				title: $(".title").val(),
				author: $(".author").val(), 
				isbn: $(".isbn").val(),
				tags: tagsArr
			};
			data.editBookToBase(obj, id)
				.then(function() {
					$('#app').html('');
				},
				function(error) {
					console.log(error);
				});
		});
	}

	function errorMessage(message) {
		$('#error').css("background-color", "red").show();
		$('<p class="error">').text(message)
							  .appendTo('#error')
							  .fadeOut(7000, function() {
							  	$('.error').remove();
							  	$('#error').hide();
							  });
	}

	function successMessage(message) {
		$('#success').css("background-color", "green").show();
		$('<p class="success">').text(message)
							  .appendTo('#success')
							  .fadeOut(7000, function() {
							  	$('.success').remove();
							  	$('#success').hide();
							  });
	}

	return {
		loadBooks: loadBooks,
		postBookHandler: postBookHandler,
		deleteBookHandler: deleteBookHandler,
		attachLoadedBooksLiHandler: attachLoadedBooksLiHandler,
		attachPutBtnHandler: attachPutBtnHandler,
		editBookHandler: editBookHandler
	}
}());