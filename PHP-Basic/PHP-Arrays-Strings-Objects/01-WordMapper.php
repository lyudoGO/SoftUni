<!DOCTYPE html>
<html>
	<head>
		<title>Problem 1.Word Mapping</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		textarea{width: 400px;}
		table, td{margin: 20px 160px; border: 1px solid black;color: blue;font-weight: bold;}
	</style>
<body>
	<form action="01-WordMapper.php" method="post">
		<textarea name="textarea"></textarea><br/>
		<input type="submit" name="submit" value="Count words">
	</form>
	<?php 
		if (isset($_POST["submit"])) {
			$inputStr = strtolower($_POST["textarea"]);
			preg_match_all("/\w+/", $inputStr, $inputText);
			//write words in associative array and they count
			$result = array();
			foreach ($inputText[0] as $value) {
				if (isset($result[$value])) {
					$result[$value]++;
				}else{
					$result[$value] = 1;
				}
			}
		}
	?>
	<table>
		<?php
		if (isset($_POST["submit"])) {
		 	foreach($result as $key => $value){
				echo "<tr><td>$key</td><td>$value</td></tr>";
			}
		}
		?>
	</table>
</body>
</html>