(function ($) {
	$.fn.viewTree = function () {
		var $this = $(this)
		var $parentTag = $this[0].nodeName;
		var $childrenTag = $this.children()[0].nodeName;
	
        $this.find($parentTag).hide();
	
		$this.find($childrenTag).click(function (event) {
			var $parent = $(this).children();
			$parent.toggle(800, function() {
				if ($parent.is(':visible')) {
					$parent.parent().attr('class', 'down');
				} else {
					$parent.parent().removeClass();
				}
			});

			event.stopPropagation();
		});

		return this;
	}
}(jQuery));
