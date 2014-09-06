<!DOCTYPE html>
<html>
	<head>
		<title>Problem 3.Show Annual Expenses</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		table{margin: 50px 50px;}
	</style>
<body>
	<form action="03-AnnualExpenses.php" method="post">
		<label for="year">Enter number for years</label>
		<input type="text" id="year" name="years-num">
		<input type="submit" name="submit" value="Show costs">
	</form>
	<table border="1">
		<thead>
			<th>Year</th>
			<th>January</th>
			<th>February</th>
			<th>March</th>
			<th>April</th>
			<th>May</th>
			<th>June</th>
			<th>July</th>
			<th>August</th>
			<th>September</th>
			<th>Octomber</th>
			<th>November</th>
			<th>December</th>
			<th>Total:</th>
		</thead>
		<?php
		if (isset($_POST["submit"])){
			$num = $_POST["years-num"];
			$startYear = 2014;
			for ($i=0; $i < $num; $i++) { 
				echo "<tr><td>$startYear</td>";
				echo randomExpenses();
				echo "</tr>";
				$startYear--;
			}
		}
		function randomExpenses(){
			$sum = 0;
			for ($i=0; $i < 12; $i++) { 
				$expenses = rand(0, 999);
				echo "<td>$expenses</td>";
				$sum += $expenses;
			}
			echo "<td>$sum</td>";
		}
		?>
	</table>
	
</body>
</html>