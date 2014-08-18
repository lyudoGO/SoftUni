<?php
function dumpVar($var)
{
	if (is_numeric($var)) {
		$result = var_dump($var);
		echo $result."<br/>";
	}else{
		$result = gettype($var);
		echo $result."<br/>";
	}
}

dumpVar("hello");
dumpVar(15);
dumpVar(1.234);
dumpVar(array(1,2,3));
dumpVar((object)[2,34]);
?>
