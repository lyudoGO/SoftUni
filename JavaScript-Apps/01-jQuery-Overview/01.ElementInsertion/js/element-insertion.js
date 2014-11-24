(function ($) {
	var $wrapper,
		$list,

	$wrapper = $('#wrapper');
	$list = $('<ul>');
	for (var i = 0; i < 10; i += 1) {
		$('<li>' + 'Number ' + i + '</li>').appendTo($list);
	}

	$wrapper.append($list);
	$wrapper.prepend('<h1>Problem 1.Element Insertion</h1>');
	$list.prepend('<h5>Start</h5>');
	$list.append('<h5>End</h5>');
}(jQuery))

