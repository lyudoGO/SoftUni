<!DOCTYPE html>
<html>
	<head>
		<title>Problem 3.Sidebar Builder</title>
		<meta charset="UTF-8" />
	</head>
	<style type="text/css">
		body{margin-left: 100px;}
		form{width: 260px; border: 1px solid black;padding: 20px;border-radius: 5px;}
		input[name="tags"]{margin-left: 38px;}
		input[name="months"]{margin-left: 20px;}
		input[type="submit"]{margin: 10px 85px;width: 100px;}
		aside{margin-top: 20px; width: 260px; background: linear-gradient(#CCCCFF, #8080FF);border: 1px solid gray;padding: 20px;border-radius: 30px;}
		ul{list-style-type: circle;}
		h2{border-bottom: 1px solid black;}
	</style>
<body>
	<form action="03-SidebarBuilder.php" method="post">
		<label for="cat">Categories:</label>
		<input type="text" name="categories" id="cat" /><br/>
		<label for="tag">Tags:</label>
		<input type="text" name="tags" id="tag" /><br/>
		<label for="mon">Months:</label>
		<input type="text" name="months" id="mon" /><br/>
		<input type="submit" name="submit" value="Generate">
		<input type="submit" value="Reload Page" onClick="window.location.reload()">
	</form>
	<?php 
		if (isset($_POST["submit"])) {
			$fieldCategories = preg_split("/[\s,]+/", $_POST["categories"]);
			$fieldTags = preg_split("/[\s,]+/", $_POST["tags"]);
			$fieldMonths = preg_split("/[\s,]+/", $_POST["months"]);

			if (isset($_POST["categories"])) {
	?>
					<aside>
						<h2><?="Categories"?></h2>
						<ul>
							<?php 
								foreach ($fieldCategories as $value) {
									echo "<li><a href=\"\">$value</a></li>";
								}
							?>
						</ul>
					</aside>
	<?php	}
			
			if (isset($_POST["tags"])) {
	?>
					<aside>
						<h2><?="Tags"?></h2>
						<ul>
							<?php 
								foreach ($fieldTags as $value) {
									echo "<li><a href=\"\">$value</a></li>";
								}
							?>
						</ul>
					</aside>
	<?php		}
			if (isset($_POST["months"])) {
	?>
			<aside>
						<h2><?="Months"?></h2>
						<ul>
							<?php 
								foreach ($fieldMonths as $value) {
									echo "<li><a href=\"\">$value</a></li>";
								}
							?>
						</ul>
					</aside>
	<?php		}
		}
	?>
</body>
</html>