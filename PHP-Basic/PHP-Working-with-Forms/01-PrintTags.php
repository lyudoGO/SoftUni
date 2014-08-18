<!DOCTYPE html>
<html>
	<head>
		<title>Problem 1.PrintTags</title>
		<meta charset="UTF-8" />
	</head>
<body>
	<form method="post" action="01-PrintTags.php ">
		<label>Enter Tags:</label><br/><br/>
		<input type="text" name="input" />
		<input type="submit" value="Submit" />
	</form>
	<p>
		<?php
		if (isset($_POST["input"])) {
			$inputArr = preg_split("/[\s,]+/", $_POST["input"]);
			for ($i=0; $i < sizeof($inputArr); $i++) { 
				echo $i . " : " . $inputArr[$i] . "<br />\n";
			}
		}
		?>
	</p>
</body>
</html>
