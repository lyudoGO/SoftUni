<!DOCTYPE html>
<html>
	<head>
		<title>Problem 2.MostFrequentTag</title>
		<meta charset="UTF-8" />
	</head>
<body>
	<form method="post" action="02-MostFrequentTag.php">
		<label>Enter Tags:</label><br/><br/>
		<input type="text" name="input" />
		<input type="submit" value="Submit" />
	</form>
	<p>
		<?php
		if (isset($_POST["input"])) {
			$inputArr = preg_split("/[\s,]+/", $_POST["input"]);
			
			$outArr = array();
			//write tags in associative array and they count
			for ($i=0; $i < sizeof($inputArr); $i++) { 
				$outArr[$inputArr[$i]] = ($outArr[$inputArr[$i]] || 0) + 1;
			}
		    //find max count of tags
			$maxCount = 0;
			$bestTag = "";
			foreach ($outArr as $key => $value) {
				$count = $value;
				if($count > $maxCount){
					$maxCount = $count;
					$bestTag = $key;
				}
			}
			//sort associative array in descending order, according to the value
			arsort($outArr);
			//print tags and counts
			foreach ($outArr as $key => $value) {
				echo $key . " : " . $value . " times " . "<br />\n";
			}
			//print most frequent tag
			echo "<br/>Most Frequent Tag is: " . $bestTag;
			}
		?>
	</p>
</body>
</html>



