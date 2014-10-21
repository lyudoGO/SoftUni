<?php
function __autoload($className)
{
	require_once($className . ".class.php");
}

$singleRoom101 = new SingleRoom(101, 45);
$singleRoom105 = new SingleRoom(105, 45);

$bedoom211 = new Bedroom(211, 85);
$bedroom234 = new Bedroom(234, 255);

$apartment308 = new Apartment(308, 150);
$apartment311 = new Apartment(311, 190);
$apartment323 = new Apartment(323, 290);

$rooms = [$singleRoom101, $singleRoom105, $bedoom211, $bedroom234, 
		  $apartment308, $apartment311, $apartment323];

$guestPesho = new Guest("Pesho", "Peshkov", 8001126767);
$guestMara = new Guest("Mara", "Otvarachkata", 8407226666);
$guestKiro = new Guest("Kiro", "Vampiro", 5401110000);
$guestMisho = new Guest("Misho", "Shamara", 9009091212);

$reservationPesho = new Reservation("21.10.2014", "23.10.2014", $guestPesho);
$reservationMara = new Reservation("21.10.2014", "25.10.2014", $guestMara);
$reservationKiro = new Reservation("23.10.2014", "24.10.2014", $guestKiro);
$reservationMisho = new Reservation("17.10.2014", "19.10.2014", $guestMisho);

BookingManager::bookRoom($singleRoom101, $reservationPesho);
BookingManager::bookRoom($singleRoom101, $reservationMara);
BookingManager::bookRoom($apartment311, $reservationMara);
BookingManager::bookRoom($bedoom211, $reservationKiro);
BookingManager::bookRoom($apartment323, $reservationMisho);

$filterRooms = array_filter($rooms, function($room){
	if ($room instanceof Apartment || $room instanceof Bedroom) {
		return $room->getPrice() <= 250;
	}

	return false;
});

$filterBalkony = array_filter($rooms, function($room){
	return $room->getBalcony() == "yes";
});

$filterBathtub = array_filter($rooms, function($room){
	$extras = $room->getExtras();
	foreach ($extras as $extra) {
		if ($extra == "bathtub") {
			return true;
		}
	}

	return false;
});

$allApartment = array_filter($rooms, function($room){
	if ($room instanceof Apartment) {
		return true;
	}

	return false;
});

$allEmptyApartment = array_filter($allApartment, function($apartment){
	$startDate = strtotime("17.10.2014");
	$endDate = strtotime("19.10.2014");

	foreach ($apartment->reservations as $res) {
			$startDateOldRes = strtotime($res->getStartDate());
			$endDateOldRes = strtotime($res->getEndDate());

			if (($startDate >= $startDateOldRes && $startDate <= $endDateOldRes) ||
				($endDate <= $endDateOldRes && $endDate >= $startDateOldRes) ||
				($startDate <= $startDateOldRes && $endDate >= $endDateOldRes)) {

				return false;
			} 
	}

	return true;
});

echo "<br>\n<strong>Filter the array by bedrooms and apartments with a 
	 price less or equal to 250.00</strong><br>\n";
foreach ($filterRooms as $room) {
	echo $room;
}

echo "<br>\n<strong>Filter the array by all rooms with a balcony</strong><br>\n";
foreach ($filterBalkony as $room) {
	echo $room;
}

echo "<br>\n<strong>Return the room numbers of all rooms which have a 
	 bathtub in their extras</strong><br>\n";
foreach ($filterBathtub as $room) {
	echo "Room number: ";
	echo $room->getRoomNumber();
	echo "<br>\n";
}

echo "<br>\n<strong>Filter the array by all apartments which are not 
	 booked in a given time period</strong><br>\n";
foreach ($allEmptyApartment as $apartment) {
	echo $apartment;
}
?>