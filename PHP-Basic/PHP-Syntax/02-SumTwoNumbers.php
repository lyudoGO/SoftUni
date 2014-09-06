<?php
function twoNumbers($firstNumber, $secondNumber)
{
$sum = round($firstNumber + $secondNumber, 2);
echo "\$firstNumber + "."\$secondNumber = ".$firstNumber." + ".$secondNumber ." = " . $sum ."<br/>";
}

twoNumbers(2, 5);
twoNumbers(1.567808, 0.356);
twoNumbers(1234.5678, 333);
?>
