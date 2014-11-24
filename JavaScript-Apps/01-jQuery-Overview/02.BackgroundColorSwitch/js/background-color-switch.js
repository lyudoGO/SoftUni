(function ($) {
	var color, inputId;
	var $form = $('<form>');
	var $output = $('#output');
	
	$form.append('<label>Class: </label>');
	$form.append('<input type="text" id="text" placeholder="bird or reptile"></br>');
	$form.append('<label>Color: </label>');
	$form.append('<input type="color" id="color"></br>');
	$form.append('<input type="button" id="button" value="Paint">');
	$form.appendTo($output);

	function onButtonClick() {
		$('.' + inputId).css('background', color);
		$('#text').val('');
  	}

  	function onInputChange() {
    	inputId = $(this).val();
  	}

  	function onColorChange() {
    	color = $(this).val();
  	}

  	$(document).ready(function () {
    	$('#button').on('click', onButtonClick);
    	$('#color').on('change', onColorChange);
    	$('#text').on('change', onInputChange);
  	});

}(jQuery));