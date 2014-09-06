<!DOCTYPE html>
<html>
	<head>
		<title>Problem 6.Modify String</title>
		<meta charset="UTF-8" />
		<style type="text/css">
			p{font-weight: bold;color: blue;}
		</style>
	</head>
<body>
	<form action="06-StringModifier.php" method="post">
		<input type="text" id="input" name="input-string">
		<input type="radio" name="palindrome" ><span>Check Palindrome</span>
		<input type="radio" name="reverse" ><span>Reverse String</span>
		<input type="radio" name="split" ><span>Split</span>
		<input type="radio" name="hash" ><span>Hash String</span>
		<input type="radio" name="shuffle" ><span>Shuffle String</span>
		<input type="submit" name="submit" value="Submit">
	</form>
	<p>
	<?php
		if (isset($_POST["submit"])) {
			$str = $_POST["input-string"];
			if (isset($_POST["palindrome"])) {
				if ($str == strrev($str)) {
					echo $str." is a palindrome!<br/>";
				}else{
					echo $str." is not a palindrome!<br/>";
				}
			}
			if (isset($_POST["split"])) {
				for ($i=0; $i < strlen($str); $i++) { 
					if ($str[$i] != " "){
						echo $str[$i]." ";
					}
				}
				echo "<br/>";
			}
			if (isset($_POST["reverse"])) {
				echo strrev($str)."<br/>";
			}
			if (isset($_POST["hash"])) {
				echo crypt($str)."<br/>";
			}
			if (isset($_POST["shuffle"])) {
				echo str_shuffle($str)."<br/>";
			}
		}
	?>
	</p>
</body>
</html>