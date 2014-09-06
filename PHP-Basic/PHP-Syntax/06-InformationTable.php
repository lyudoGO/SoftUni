<!DOCTYPE html>
<html>
	<head>
		<title>Problem 6.HTML Table</title>
		<meta charset="UTF-8" />
		<style type="text/css">
			table {border-collapse: collapse;margin: 20px;}
			td { border: 1px solid black;}
			td.color { background: orange;font-weight: bold;padding: 0 5px 0 5px;}
			td:last-child {text-align: right;padding: 0 5px 0 5px;}
		</style>
	</head>
<body>
	<section>
		<?php
			input("Gosho","0882-321-423",24,"Hadji Dimitar");
			input("Pesho","0884-888-888",67,"Suhata Reka");
		?>
	</section>
</body>
</html>

<?php
function input($name, $phone, $age, $address)
{
echo    '<table>';
echo	'<tr>';		
echo	'<td class="color">Name</td>';
echo	'<td>',$name,'</td>';
echo	'</tr>';
echo	'<tr>';
echo	'<td class="color">Phone number</td>';
echo	'<td>',$phone,'</td>';
echo	'</tr>';
echo    '<tr>';
echo	'<td class="color">Age</td>';
echo	'<td>',$age,'</td>';
echo	'</tr>';
echo	'<tr>';
echo	'<td class="color">Address</td>';
echo	'<td>',$address,'</td>';
echo	'</tr>';
echo	'</table>';
}
?>
