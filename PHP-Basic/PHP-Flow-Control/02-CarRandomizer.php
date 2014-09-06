<!DOCTYPE html>
<html>
	<head>
		<title>Problem 2.Rich People’s Problems</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		table{margin: 50px 50px;}
	</style>
<body>
	<form action="02-CarRandomizer.php" method="post">
		<label for="cars">Enter cars</label>
		<input type="text" id="cars" name="car-input">
		<input type="submit" name="submit" value="Show result">
	</form>
	<table border="1">
		<thead>
			<th>Car</th>
			<th>Color</th>
			<th>Count</th>
		</thead>
		<?php
		if (isset($_POST["submit"])){
			$cars = preg_split("/[\s,]+/", $_POST["car-input"]);
			$colors = array("yelow", "red", "black", "white", "silver", "metalic", "green");
			for ($i=0; $i < count($cars); $i++) { 
				$color = $colors[rand(0, 6)];
				$quantity = rand(1, 5);
				echo "<tr><td>$cars[$i]</td><td>$color</td><td>$quantity</td></tr>";
			}
		}
		?>
	</table>
	
</body>
</html>