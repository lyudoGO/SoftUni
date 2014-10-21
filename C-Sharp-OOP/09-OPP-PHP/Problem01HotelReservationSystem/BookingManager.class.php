<?php
//include_once("Room.class.php");

final class BookingManager
{
	static function bookRoom(Room $room, Reservation $reservation) 
	{
		
		$firstName = $reservation->getGuest()->getFirstName();
		$lastName = $reservation->getGuest()->getLastName();
		$startDate = strtotime($reservation->getStartDate());
		$endDate = strtotime($reservation->getEndDate());
		
		$outputStr = " <strong> " . get_class($room) . " " . $room->getRoomNumber() . 
				"</strong> successfully booked for <strong>" .
        		 $firstName. " " . 
        		 $lastName .
        		"</strong> from <time>" . date('d.m.Y', $startDate) . 
        		"</time> to <time>" . date('d.m.Y', $endDate) .
        		 "</time>!<br>\n";

		try {

			$room->addReservation($reservation);
			echo $outputStr;

		} catch (EReservationException $ex){
			echo $ex->getMessage();
		}
	}
}
?>	