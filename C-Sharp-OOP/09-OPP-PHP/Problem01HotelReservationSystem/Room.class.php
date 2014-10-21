<?php

abstract class Room implements iReservable
{
	public $reservations = [];
	protected $roomType; 
	protected $restroom;
	protected $balcony;
	protected $bedCount;
	protected $roomNumber;
	protected $extras = []; 
	protected $price; 

	function __construct($roomNumber, $price, $bedCount, $roomType,
	 $restroom, $balcony, $extras)
	{
		$this->setRoomNumber($roomNumber);
		$this->setRoomType($roomType);
		$this->setRestroom($restroom);
		$this->setBalcony($balcony);
		$this->setBedCount($bedCount);
		$this->setExtras($extras);
		$this->setPrice($price);
	}

	public function setRoomNumber($roomNumber)
	{
		$this->roomNumber = $roomNumber;
	}

	public function getRoomNumber()
	{
		return $this->roomNumber;
	}

	public function setRoomType($roomType)
	{
		$this->roomType = $roomType;
	}

	public function getRoomType()
	{
		return $this->roomType;
	}

	public function setRestroom($restroom)
	{
		$this->restroom = $restroom;
	}

	public function getRestroom()
	{
		return $this->restroom;
	}

	public function setBalcony($balcony)
	{
		$this->balcony = $balcony;
	}

	public function getBalcony()
	{
		return $this->balcony;
	}

	public function setBedCount($bedCount)
	{
		$this->bedCount = $bedCount;
	}

	public function getBedCount()
	{
		return $this->bedCount;
	}

	public function setExtras($extras)
	{
		$this->extras = $extras;
	}

	public function getExtras()
	{
		return $this->extras;
	}

	public function setPrice($price)
	{
		$this->price = $price;
	}

	public function getPrice()
	{
		return $this->price;
	}

	public function addReservation($reservation)
	{
		$startDate = strtotime($reservation->getStartDate());
		$endDate = strtotime($reservation->getEndDate());

		foreach ($this->reservations as $oldRes) {
				$startDateOldRes = strtotime($oldRes->getStartDate());
				$endDateOldRes = strtotime($oldRes->getEndDate());

				if (($startDate >= $startDateOldRes && $startDate <= $endDateOldRes) ||
					($endDate <= $endDateOldRes && $endDate >= $startDateOldRes) ||
					($startDate <= $startDateOldRes && $endDate >= $endDateOldRes)) {

					throw new EReservationException($this, $oldRes);

				} 
			}

		$this->reservations[] = $reservation;
	} 

	public function removeReservation($reservation)
	{
		$this->reservations(array_diff($this->reservations, array($reservation)));
	}

	public function __toString()
    {
        $resultString = "Room number: $this->roomNumber<br>\n
        Type: $this->roomType<br>\n
        Price: $this->price<br>\n
        Bed count: $this->bedCount<br>\n
        Restroom: $this->restroom<br>\n
        Balcony: $this->balcony<br>\n
        Extras: " . implode(', ', $this->extras) . "<br><br>\n\n";
   
        return $resultString;
    }
}
?>
