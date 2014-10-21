<?php

class Reservation
{
	protected $startDate;
	protected $endDate;
	protected $guest;

	function __construct($startDate, $endDate, $guest)
	{
		$this->setStartDate($startDate);
		$this->setEndDate($endDate);
		$this->setGuest($guest);
	}

	public function setStartDate($startDate)
	{
		$this->startDate = $startDate;
	}

	public function getStartDate()
	{
		return $this->startDate;
	}

	public function setEndDate($endDate)
	{
		$this->endDate = $endDate;
	}

	public function getEndDate()
	{
		return $this->endDate;
	}

	public function setGuest($guest)
	{
		$this->guest = $guest;
	}

	public function getGuest()
	{
		return $this->guest;
	}

	function __toString()
    {
        $resultString= ("Reservation from: " . 
        	date("d.m.Y", strtotime($this->startDate)) . " to " .
        	date("d.m.Y", strtotime($this->endDate)) .
        	";$this->guest<br>\n");
        return $resultString;
    }
}
?>