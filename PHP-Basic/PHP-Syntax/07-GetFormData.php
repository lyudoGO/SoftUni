<!DOCTYPE html>
<html>
	<head>
		<title>Problem 6.HTML Table</title>
		<meta charset="UTF-8" />
		<style type="text/css">
			input {display: block;}
			#male, #female {display: inline-block;}
		</style>
	</head>
<body>
	<form method="post" action="07-GetFormData.php">
		<input type="text" name="firstName" placeholder="Name" />
		<input type="text" name="age" placeholder="Age" />
		<input type="radio" name="gender" id="male" value="male"><label for="male">Male</label><br/>
		<input type="radio" name="gender" id="female" value="female"><label for="female">Female</label>
		<input type="submit" value="Изпращане" />
	</form>
	<p>
		<?php
		if (isset($_POST["firstName"])) {
			echo "My name is ". $_POST["firstName"].".";
			echo " I am ". $_POST["age"] ." years old.";
			echo " I am ". $_POST["gender"] .".";
		}
		?>
	</p>
</body>
</html>
