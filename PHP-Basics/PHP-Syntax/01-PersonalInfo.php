<?php
function fullsName($firstName, $lastName, $age)
{
$fullName = $firstName . ' ' . $lastName;
echo "My name is ".$fullName." and I am ".$age." years old."."<br/>";
}

fullsName('Mister','DakMan',21);
fullsName('Pesho','Peshev',55);
?>
