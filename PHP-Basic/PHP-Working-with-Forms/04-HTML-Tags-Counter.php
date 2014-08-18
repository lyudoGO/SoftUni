<!DOCTYPE html>
<html>
	<head>
		<title>Problem 4.HTML Tags Counter</title>
		<meta charset="UTF-8" />
	</head>
<body>
	<form method="POST" action="04-HTML-Tags-Counter.php">
		<label for="tag">Enter HTML tags:</label><br/>
		<input type="text" name="tags" id="tag" />
		<input type="submit" name="submit" value="Submit"/>
	</form>	
	<h3>
		<?php
			$htmlTags = "<a><abbr><acronym><address><applet><area><b><base><basefont><bdo><big><blockquote><body><br><button><caption><center><cite><code><col><colgroup><dd><del><dfn><dir><div><dl><dt><em><fieldset><font><form><frame><frameset><h1><h2><h3><h4><h5><h6><head><hr><html><i><iframe><img><input><ins><isindex><kbd><label><legend><li><link><map><menu><meta><noframes><noscript><object><ol><optgroup><option><p><param><pre><q><s><samp><script><select><small><span><strike><strong><style><sub><sup><table><tbody><td><textarea><tfoot><th><thead><title><tr><tt><u><ul><var>";
			$tagsArr = preg_split('/[\s|<|>]+/', $htmlTags);
			$_SESSION["counter"] = 0;
		    if (isset($_POST["submit"])) {
		    	session_start();
		    	$value = strtolower($_POST["tags"]);
		    	if (in_array($value, $tagsArr)) {
		    		$_SESSION["counter"]++;
		    		echo "Valid HTML tag!<br/>";
		    		echo "Score: " . $_SESSION["counter"];
		    	}else {
		    		echo "Invalid HTML tag!";
		    	}
		    	//echo '<pre>';
		     	//print_r($tagsArr);
		     	//echo '</pre>';
		    }
		?>
	</h3>
	
</body>
</html>
