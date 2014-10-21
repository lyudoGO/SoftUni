<?php

class EReservationException extends LogicException {

    public function __construct(Room $room, Reservation $reservation)
    {
    	$typeRoom = get_class($room);
    	$startDate = strtotime($reservation->getStartDate());
		$endDate = strtotime($reservation->getEndDate());
		$firstName = $reservation->getGuest()->getFirstName();

    	$strMessage = "<strong>$typeRoom " . $room->getRoomNumber() . " is already occupied for period from "
    				  . date('d.m.Y', $startDate) . " to "
            		  . date('d.m.Y', $endDate) . "!</strong><br>\n";

        $this->message = $strMessage;
    }
}