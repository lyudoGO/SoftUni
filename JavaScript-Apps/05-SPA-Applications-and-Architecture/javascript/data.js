var data = (function () {
	
	var PARSE_APP_ID = "9MZHdXjQzfYODa66oLKP7h8gLvSrS5SmOGuIHKRN";
	var PARSE_REST_API_KEY = "XHJfTH37hNF5oA1hsn2nrRSMEOcmJLyNGbcqxLPF";
	var url = "https://api.parse.com/1/classes/Book/";
	var headers = {
		"X-Parse-Application-Id": PARSE_APP_ID,
		"X-Parse-REST-API-Key": PARSE_REST_API_KEY 
	};

	var loadBooksFromBase = function loadBooksFromBase() {
		return ajaxRequester.get(headers, url);
	}

	var postBooksToBase = function postBooksToBase(data) {
		return ajaxRequester.post(headers, url, data);
	}

	var editBookToBase = function editBookToBase(data, id) {
		return ajaxRequester.put(headers, (url + id), data);
	}

	var deleteBookFromBase = function deleteBookFromBase(id) {
		return ajaxRequester.delete(headers, (url + id));
	}

	return {
		loadBooksFromBase: loadBooksFromBase,
		deleteBookFromBase: deleteBookFromBase,
		postBooksToBase: postBooksToBase,
		editBookToBase: editBookToBase
	}
}());