<!DOCTYPE html>
<html>
	<head>
		<title>Problem 1.SquareRootSum</title>
		<meta charset="UTF-8" />
	</head>
<body>
	<table border="1">
		<thead>
			<tr>
				<th>Number</th>
				<th>Square</th>
			</tr>
		</thead>
		<?php
			$sum = 0;
			for ($i=0; $i <= 100; $i+=2){ 
				$squareNum = round(sqrt($i), 2);
				$sum += $i;
				echo "<tr><td>$i</td><td>$squareNum</td></tr>";
			}
		?>
		<tfoot>
			<th>Total:</th>
			<td><?php echo $sum ?></td>
		</tfoot>
	</table>
</body>
</html>