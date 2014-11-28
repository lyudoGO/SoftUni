(function ($) {
	var PARSE_APP_ID = "Dji0HqbW0NXuqYfuJljlBFDp0F2yfCHAYmUrKkRj";
	var PARSE_REST_API_KEY = "oi7OJRbOpXAtkDpRrmk3OWxzT9Cp8mUYphPV282Y";

	$.ajax({
			method: "GET",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
			},
			url: "https://api.parse.com/1/classes/Country",
		}).success(function(data) {
			for (var item in data.results) {
				var country = data.results[item];
				var countryTag = $('<li>');
				countryTag.text(country.name);
				countryTag.appendTo($("#countries"));
			}
		}).error(function() {
			errorMessage();
		});

	function errorMessage() {
		$('<p>').text('Cannot load countries.No access.').appendTo('#wrapper');
	}
}(jQuery));