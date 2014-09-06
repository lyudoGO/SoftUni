<!DOCTYPE html>
<html>
	<head>
		<title>Problem 5.Sentence Extractor</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		form{width: 600px;border: 1px solid black;border-radius: 10px;}
		textarea{width: 400px;margin: 10px 10px 0 12px; }
		label{margin-left: 5px;font-weight: bold;}
		input[name="submit"]{margin: 10px 10px 10px 95px;color: red;font-weight: bold;}
	</style>
<body>
	<form action="05-SentenceExtractor.php" method="post">
		<label for="txt">Input text:</label>
		<textarea name="text" id="txt"></textarea><br/>
		<label for="w">Input word:</label>
		<input type="text" name="word" id="w" /><br/>
		<input type="submit" name="submit" value="Extract sentence">
		<input type="submit" value="Reload Page" onClick="window.location.reload()">
	</form>
	<?php
		if (isset($_POST["submit"])) {
			$inputStr = $_POST["text"];
			$word = $_POST["word"];
			$startStr = 0;
			$endStr = 0;
			for ($i=0; $i < strlen($inputStr); $i++) { 
				$subStr = null;
				//find substring ending with "." or "?" or "!"
				if (($inputStr[$i] === ".") || ($inputStr[$i] === "?") || ($inputStr[$i] === "!")) {
					$endStr = $i + 1;
					$subStr = substr($inputStr, $startStr, $endStr - $startStr);
					$startStr = $endStr;
					//if input word match the word in substring then print substring
					if (preg_match("/\b$word\b/i", $subStr)) {
	?>
		<p>
			<?php echo $subStr; ?>
		</p>
	<?php
					}
				}
			}
		}
	?>
</body>
</html>
