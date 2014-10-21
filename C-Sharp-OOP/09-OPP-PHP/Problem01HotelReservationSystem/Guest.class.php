<?php

class Guest
{
	protected $firstName;
	protected $lastName;
	protected $id;

	function __construct($firstName, $lastName, $id)
	{
		$this->setFirstName($firstName);
		$this->setLastName($lastName);
		$this->setId($id);
	}

	public function setFirstName($firstName)
	{
		$this->firstName = $firstName;
	}

	public function getFirstName()
	{
		return $this->firstName;
	}

	public function setLastName($lastName)
	{
		$this->lastName = $lastName;
	}

	public function getLastName()
	{
		return $this->lastName;
	}

	public function setId($id)
	{
		$this->id = $id;
	}

	public function getId()
	{
		return $this->id;
	}

	function __toString()
    {
        $resultString= ("Guest: $this->firstName $this->lastName; ID: $this->id<br><br>\n\n");
        return $resultString;
    }
}
?>