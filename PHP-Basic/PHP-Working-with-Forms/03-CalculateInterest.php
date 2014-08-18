<!DOCTYPE html>
<html>
	<head>
		<title>Problem 3.CalculateInterest</title>
		<meta charset="UTF-8" />
	</head>
<body>
	<section>
		<form method="POST" action="03-CalculateInterest.php" id="amountform">
			<label>Enter Amount</label>
			<input type="text" name="amount" /><br/>
			<input type="radio" name="usd" />USD
			<input type="radio" name="eur" />EUR
			<input type="radio" name="bgn" />BGN<br/>
			<label>Compound Interest Amount</label>
			<input type="text" name="compound" /><br/>
			<select name="period" form="amountform">
				<option value="6">6 Months</option>
				<option value="12">1 Year</option>
				<option value="24">2 Years</option>
				<option value="60">5 Years</option>
			</select>
			<input type="submit" name="calculate" value="Calculate"/>
		</form>	
	</section>
	<p>
		<?php
		    if ( isset($_POST["calculate"]) ) {
				$result = (double)$_POST["amount"];
				$monthsCount = (int)$_POST["period"];
				$compound = (double)$_POST["compound"] / 12;
				$symbol = "";
				if (isset($_POST["usd"])) {
					$symbol = "\$ ";
				}else if (isset($_POST["eur"])) {
					$symbol = "€ ";
				}else if (isset($_POST["bgn"])) {
					$symbol = "BG ";
				}
				for ($i=0; $i < $monthsCount; $i++) { 
					$result = $result * ((100 + $compound)/100);
				}
				echo $symbol . round($result, 2);
			}
		?>
	</p>
</body>
</html>

