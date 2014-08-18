<?php
function nonRepeatingDigits($num)
{
$solveProblem = false;
if ($num > 999) {
	$num = 999;
}
if ($num < 100) {
	$solveProblem = false;
}else{
for ($i=100; $i <= $num ; $i++) { 
	$firstDig = floor($i / 100);
	$secondDig = ($i / 10) % 10;
	$thirdDig = $i % 10;
	if (($firstDig != $secondDig) && ($secondDig != $thirdDig)) {
		echo $i . ", ";
		$solveProblem = true;
	}
}
echo "<br/>";	
}

if (!$solveProblem) {
	echo "no"."<br/>";
}
}

nonRepeatingDigits(1234);
nonRepeatingDigits(145);
nonRepeatingDigits(15);
nonRepeatingDigits(247);
?>
