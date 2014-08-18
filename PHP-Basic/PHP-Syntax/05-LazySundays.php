<?php

$startdate = strtotime("first sunday of this month", time());
$enddate = strtotime("last day of this month", time());

while ($startdate <  $enddate) {
   echo date("jS F\, Y", $startdate),"<br>";
   $startdate = strtotime("+1 week", $startdate);
}
?>
