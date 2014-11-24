(function ($) {
	var $output = $('#output');
	
	function createTable(inputArr) {
		var	$table = $('<table>');
		var keys = Object.keys(inputArr[0]);

		var $headRow = $('<tr>');
		$table.append($headRow);
		for (var i = 0; i < keys.length; i++) {
			$headRow.append('<th>' + keys[i] + '</th>');
		};

		for (var i = 0; i < inputArr.length; i++) {
			var $row = $('<tr>');
			$table.append($row);
			for (var j = 0; j < keys.length; j++) {
				$row.append('<td>' + inputArr[i][keys[j]] + '</td>');
			};
		};

		return $table;
	}

	function onChageTextareaInput() {
		var $input = $(this).val();
		var inputArr = JSON.parse($input);
		var $table = createTable(inputArr);
		$output.append($table);
		$('#input').val('');
	}

	$(document).ready(function(){
		$('#input').change(onChageTextareaInput);
	});

}(jQuery));