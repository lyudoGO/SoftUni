<!DOCTYPE html>
<html>
	<head>
		<title>Problem 4.Text Filter</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		form{width: 600px;border: 1px solid black;border-radius: 10px;}
		strong{color: red;}
		div{margin: 10px; border: 1px solid black;border-radius: 10px;}
		textarea{width: 400px;margin: 10px 10px 0 20px; }
		label{margin-left: 5px;font-weight: bold;}
		input[name="submit"]{margin: 10px 10px 10px 95px;color: red;font-weight: bold;}
	</style>
<body>
	<form action="04-TextFilter.php" method="post">
		<label for="txt">Input text:</label>
		<textarea name="text" id="txt"></textarea><br/>
		<label for="ban">Input banlist:</label>
		<input type="text" name="banlist" id="ban" /><br/>
		<input type="submit" name="submit" value="Ban !!!">
		<input type="submit" value="Reload Page" onClick="window.location.reload()">
	</form>
	<?php
	if (isset($_POST["submit"])) {
		$text = $_POST["text"];
		$replacements = preg_split("/[\s,]+/", $_POST["banlist"]);
		foreach ($replacements as $value) {
			$replace = "<strong>";
			for($i=0;$i<strlen($value);$i++){
				$replace.="*";
			}
			$replace.="</strong>";
			$text = str_replace($value, $replace, $text);
		}
		echo "<div><strong>Input text</strong><p>" . $_POST["text"] . "</p></div>";
		echo "<div><strong>Output text</strong><p>" . $text . "</p></div>";
	}
	?>
</body>
</html>