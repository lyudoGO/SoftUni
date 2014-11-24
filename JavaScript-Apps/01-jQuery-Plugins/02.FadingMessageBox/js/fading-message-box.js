(function ($) {
	$.fn.messageBox = function () {
		var $this = $(this);
		$this.append('<div id="message-box">');

		var error = function (message) {
			var paragraph = $('<p class="error">').text(message).fadeIn(1000);
			$('#message-box').append(paragraph);
			paragraph.delay(3000).fadeOut('fast');
		}

		var success = function (message) {
			var paragraph = $('<p class="success">').text(message).fadeIn(1000);;
			$('#message-box').append(paragraph);
			paragraph.delay(3000).fadeOut('fast');
		}

		return {
			this: this,
			error: error,
			success: success
		}
	}

	$(document).ready(function () {
		var messageBox = $('#wrapper').messageBox();
		$('<p>').text(string).appendTo('#message-box');
		messageBox.success('Success message.');
		messageBox.error('Error message.');
	});

	var string = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Error explicabo neque, recusandae molestias nulla natus voluptas optio dignissimos veritatis ab repellat, eum voluptates qui incidunt maiores quod mollitia ducimus iure!"
}(jQuery));
