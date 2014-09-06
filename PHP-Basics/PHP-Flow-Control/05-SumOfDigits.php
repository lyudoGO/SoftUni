<!DOCTYPE html>
<html>
	<head>
		<title>Problem 5.Sum of Digits</title>
		<meta charset="UTF-8" />
		<style type="text/css">
			form{margin: 20px;}
			table{margin: 20px 80px;border: 2px solid blue;}
			td{border: 1px solid blue;}
			span{color: red;}
		</style>
	</head>
<body>
	<form action="05-SumOfDigits.php" method="post">
		<label for="input">Input string:</label>
		<input type="text" id="input" name="input-string">
		<input type="submit" name="submit" value="Submit">
	</form>
	<?php
		if (isset($_POST["submit"])) {
			$inputs = preg_split("/[\s,]+/", $_POST["input-string"]);
			echo "<table>";
			for ($i=0; $i < count($inputs); $i++) { 
				echo "<tr><td>$inputs[$i]</td>";
				echo "<td>".sumDigits($inputs[$i])."</td></tr>";
			}
			echo "</table>";	
		}
		function sumDigits($input){
			if (is_numeric($input)) {
				$sum = 0;
				for ($i=0; $i < strlen($input); $i++) { 
					$sum += $input[$i];
				}
				return $sum;
			}else{
				return "<span>I cannot sum that</span>";
			}
		}
	?>
</body>
</html>