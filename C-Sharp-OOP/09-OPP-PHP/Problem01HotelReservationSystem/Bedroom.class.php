<?php
	class Bedroom extends Room
	{
		const BED_COUNT = 2;

		function __construct($roomNumber, 
							 $price, 
							 $bedCount = self::BED_COUNT,
			 				 $roomType = RoomType::GOLD, 
			 				 $restroom = "yes", 
			 				 $balcony = "yes", 
			 				 $extras = ["TV", "air-conditioner", "refrigerator",
			 				 "mini-bar", "bathtub"] )
		{
			parent::__construct($roomNumber, $price, $bedCount, $roomType,
	 							$restroom, $balcony, $extras);
		}
	}
?>