(function ($) {
	var PARSE_APP_ID = "Dji0HqbW0NXuqYfuJljlBFDp0F2yfCHAYmUrKkRj";
	var PARSE_REST_API_KEY = "oi7OJRbOpXAtkDpRrmk3OWxzT9Cp8mUYphPV282Y";
	var countryId;
	var countryName;
	var townId;
	var townName;

	function loadCountries() {
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
				$(countryTag).data('country', country);
				$(countryTag).click(countryClicked);
				countryTag.appendTo($("#countries"));
			}
		}).error(function() {
			errorMessage('load countries');
		});
	}
	
	function loadTowns() {
		$('#wrapper-town').show();
		$('#town').val('');

		$.ajax({
			method: "GET",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
			},
			url: 'https://api.parse.com/1/classes/Town?where={"country":{"__type":"Pointer","className":"Country","objectId":"' + countryId + '"}}',
		}).success(function(data) {
			var countryHead = $('<h2>').text(countryName).insertAfter($("#wrapper-town>h1"));
			for (var item in data.results) {
				var town = data.results[item];
				var townTag = $('<li>');
				townTag.text(town.name);
				$(townTag).data('town', town);
				$(townTag).click(townClicked);
				townTag.appendTo($("#towns"));
			}
		}).error(function() {
			errorMessage('load towns');
		});
	}

	function countryClicked() {
		var country = $(this).data('country');
		countryId = country.objectId;
		countryName = country.name;
		$('#countries li').removeClass('selected');
		$(this).addClass('selected');
		$('#country').val(countryName);
		clearTowns();
		loadTowns();
	}

	function townClicked() {
		var town = $(this).data('town');
		townId = town.objectId;
		townName = town.name;
		$('#towns li').removeClass('selected');
		$(this).addClass('selected');
		$('#town').val(townName);
	}

	function clearCountries() {
		$('#countries>li').remove();
		clearTowns();
		loadTowns();
	}

	function clearTowns() {
		$('#wrapper-town>h2').remove();
		$('#towns>li').remove();
	}

	function deleteCountry() {
		$.ajax({
			method: "DELETE",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY,
			},
			url: "https://api.parse.com/1/classes/Country/" + countryId,
		}).success(function() {
			clearCountries();
			loadCountries();
		}).error(function() {
			errorMessage('delete ' + countryName);
		});
	}

	function editCountry() {
		var countryName = $('#country').val();

		$.ajax({
			method: "PUT",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
			},
			url: "https://api.parse.com/1/classes/Country/" + countryId,
			data: JSON.stringify({"name" : countryName})
		}).success(function() {
			clearCountries();
			loadCountries();
		}).error(function() {
			errorMessage('edit ' + countryName);
		});
	}

	function addCountry() {
		var countryName = $('#country').val();

		$.ajax({
			method: "POST",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
			},
			url: "https://api.parse.com/1/classes/Country",
			data: JSON.stringify (
				{
					"name" : countryName
				}),
		}).success(function() {
				var countryTag = $('<li>');
				countryTag.text(countryName);
				countryTag.appendTo($("#countries"));
				clearCountries();
				loadCountries();
		}).error(function() {
			errorMessage('add ' + countryName);
		});
	}

	function deleteTown() {
		var townDel = $('#town').val() || townName;
		
		$.ajax({
			method: "DELETE",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY,
			},
			url: "https://api.parse.com/1/classes/Town/" + townId,
		}).success(function() {
			$('#towns .selected').remove();
			clearCountries();
			loadCountries();
		}).error(function() {
			errorMessage('delete ' + townDel);
		});
	}

	function editTown() {
		var townName = $('#town').val();
		if (townName.length == 0) {
			return warningMessage('edit empty name');
		};
		$.ajax({
			method: "PUT",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
			},
			url: "https://api.parse.com/1/classes/Town/" + townId,
			data: JSON.stringify(
				{
					"name" : townName
				})
		}).success(function() {
			$('#towns .selected').text(townName);
			clearCountries();
			loadCountries();
		}).error(function() {
			errorMessage('edit ' + townName);
		});
	}

	function addTown() {
		var townName = $('#town').val();
		if (townName.length == 0) {
			return warningMessage('add empty name');
		};
		$.ajax({
			method: "POST",
			headers: {
				"X-Parse-Application-Id": PARSE_APP_ID,
				"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
			},
			url: "https://api.parse.com/1/classes/Town",
			data: JSON.stringify (
				{
					"name" : townName, 
					"country" : 
					{
						"__type": "Pointer",
                        "className": "Country",
						"objectId" : countryId
					}
				})
		}).success(function() {
				var townTag = $('<li>');
				townTag.text(townName);
				townTag.appendTo($("#towns"));
				$('#town').val("");
				clearCountries();
				loadCountries();
		}).error(function() {
			errorMessage('add ' + townName);
		});
	}

	function errorMessage(message) {
		$('<p class="error">').text('Cannot ' + message + '.No access.')
				.appendTo('#wrapper')
				.fadeOut(5000, function() {
					$('.error').remove();
				})
	}

	function warningMessage(message) {
		$('<p class="warning">').text('Cannot ' + message + '.No entered towns.')
				.appendTo('#wrapper')
				.fadeOut(5000, function() {
					$('.warning').remove();
				});
	}

	$(document).ready(function() {
		$('#wrapper-town').hide();
	    loadCountries();
		$('#btn-add').click(addCountry);
		$('#btn-edit').click(editCountry);
		$('#btn-delete').click(deleteCountry);
		$('#btn-add-town').click(addTown);
		$('#btn-edit-town').click(editTown);
		$('#btn-delete-town').click(deleteTown);
	});

}(jQuery));