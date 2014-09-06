<!DOCTYPE html>
<html>
	<head>
		<title>Problem 6.URL Replacer</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		form{width: 600px;border: 1px solid black;border-radius: 10px;}
		strong{color: red;}
		div{margin: 10px; border: 1px solid black;border-radius: 10px;}
		textarea{width: 400px;margin: 10px 10px 0 12px; }
		label{margin-left: 5px;font-weight: bold;}
		input[name="submit"]{margin: 10px 10px 10px 95px;color: red;font-weight: bold;}
	</style>
<body>
	<form action="06-URLReplacer.php" method="post">
		<label for="txt">Input text:</label>
		<textarea name="text" id="txt"></textarea><br/>
		<input type="submit" name="submit" value="Replace URL">
		<input type="submit" value="Reload Page" onClick="window.location.reload()">
	</form>
	<?php
	if (isset($_POST["submit"])) {
		$text = $_POST["text"];
		//replace <a> tags with [URL]s
		$text = str_replace("<a href=\"", "[URL=", $text);
		$text = str_replace("\">", "]", $text);
		$text = str_replace("</a>", "[/URL]", $text);
		//replace URLs with strong tags
		$text = replaceWithStrong("/\[URL[\S]+?\]/", $text);
		$text = replaceWithStrong("/\[\/URL\]/", $text);

		echo "<div><strong>Input text</strong><p>" . $_POST["text"] . "</p></div>";
		echo "<div><strong>Output text</strong><p>" . $text . "</p></div>";
	}

	function replaceWithStrong($string, $text){
		preg_match_all($string, $text, $strong);
		foreach ($strong[0] as $value) {
			$text = str_replace($value, "<strong>$value</strong>", $text);
		}
		return $text;
	}
	?>
</body>
</html>
