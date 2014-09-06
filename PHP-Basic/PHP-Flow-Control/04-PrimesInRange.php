<!DOCTYPE html>
<html>
	<head>
		<title>Problem 4.Find Primes in Range</title>
		<meta charset="UTF-8" />
		<style type="text/css">
			strong{color: red;}
		</style>
	</head>
<body>
	<form action="04-PrimesInRange.php" method="post">
		<label for="start">Starting index:</label>
		<input type="text" id="start" name="start-num">
		<label for="end">End:</label>
		<input type="text" id="end" name="end-num">
		<input type="submit" name="submit" value="Submit">
	</form>
	<p>
		<?php
			if (isset($_POST["submit"])) {
				$start = $_POST["start-num"];
				$end = $_POST["end-num"];
				$result= array();
				for ($i=$start; $i <= $end; $i++) { 
					if (isPrime($i)){
						$result[] = "<strong>$i</strong>";
					}else{
						$result[] = $i;
					}
				}
				echo implode(", ", $result);
			}
			function isPrime($num) {
				if ($num == 1) {
					return true;
				}else{
					for ($i = 2; $i <= sqrt($num); $i++){
				        if ($num % $i == 0) {
				            return false;
				        	}
					    }
					    return true;
					}
				}
		?>
	</p>
</body>
</html>