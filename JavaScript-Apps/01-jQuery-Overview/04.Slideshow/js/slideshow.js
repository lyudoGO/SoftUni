(function ($) {
	function slideShow(direction) {
		var $next;
		var $active = $('.active');

		if (direction == '-') {
			$next = $active.next().length ? $active.next()
        			: $('#wrapper article:first');
		} else {
			$next = $active.prev().length ? $active.prev()
        			: $('#wrapper article:last');
		};

        $active.animate({'left': direction + '=50%'}, 2500, function() {
        	$next.addClass('active');
        	$active.css({'left': '25%'}).removeClass('active');
        });
	}

	function onClickLeftBtn() {
		clearInterval(repeat);
		slideShow('-');
		repeat = setInterval(function(){slideShow('-')}, 5000);
	}

	function onClickRightBtn() {
		clearInterval(repeat);
		slideShow('+');
		repeat = setInterval(function(){slideShow('-')}, 5000);
	}

	repeat = setInterval(function(){slideShow('-')}, 5000);

	$(document).ready(function() {
		repeat;
		$('#left-btn').click(onClickLeftBtn);
		$('#right-btn').click(onClickRightBtn);
	});

}(jQuery));