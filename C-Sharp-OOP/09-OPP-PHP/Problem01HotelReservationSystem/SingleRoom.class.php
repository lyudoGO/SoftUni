<?php
	class SingleRoom extends Room
	{
		const BED_COUNT = 1;

		function __construct($roomNumber, 
							 $price, 
							 $bedCount = self::BED_COUNT,
			 				 $roomType = RoomType::STANDART, 
			 				 $restroom = "yes", 
			 				 $balcony = "no", 
			 				 $extras = ["TV", "air-conditioner"] )
		{
			parent::__construct($roomNumber, $price, $bedCount, $roomType,
	 							$restroom, $balcony, $extras);
		}
	}
?>
