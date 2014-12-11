var ajaxRequester = (function ajaxRequester() {
	function request(method, headers, url, data) {
		var defer = Q.defer();

		$.ajax({
			type: method,
			headers: headers,
			url: url,
			contentType: 'application/json',
			data: JSON.stringify(data) || undefined,
			success: function (data) {
				defer.resolve(data);
			},
			error: function (error) {
				defer.reject(error);
			}
		});

		return defer.promise;
	}

	var get = function get(headers, url) {
		return request("GET", headers, url, null);
	}

	var post = function post(headers, url, data) {
		return request("POST", headers, url, data);
	}

	var put = function put(headers, url, data) {
		return request("PUT", headers, url, data);
	}

	var del = function del(headers, url) {
		return request("DELETE", headers, url, null);
	}

	return {
		get: get,
		post: post,
		put: put,
		delete: del
	}
}());