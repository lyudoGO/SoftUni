<!DOCTYPE html>
<html>
	<head>
		<title>Problem 2.Coloring Texts</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		textarea{width: 400px;}
		input{margin-bottom: 20px;}
		span.even{color: red;}
		span.odd{color: blue;}
	</style>
<body>
	<form action="02-TextColorer.php" method="post">
		<textarea name="textarea"></textarea><br/>
		<input type="submit" name="submit" value="Color text">
	</form>
	<p>
	<?php 
		if (isset($_POST["submit"])) {
			$inputStr = $_POST["textarea"];
			preg_match_all("/\S/", $inputStr, $inputText);
			$result = array();
			foreach ($inputText[0] as $value) {
				$ascii = ord($value);
				if (($ascii % 2) === 0) {
					$result[] = "<span class=\"even\">$value</span>";
				}else{
					$result[] = "<span class=\"odd\">$value</span>";
				}
			}
			echo implode(" ", $result);
		}
	?>
	</p>
</body>
</html>
