<?php
	class Apartment extends Room
	{
		const BED_COUNT = 4;

		function __construct($roomNumber, 
							 $price, 
							 $bedCount = self::BED_COUNT,
			 				 $roomType = RoomType::DIAMOND, 
			 				 $restroom = "yes", 
			 				 $balcony = "yes", 
			 				 $extras = ["TV", "air-conditioner", "refrigerator",
			 				 "kitchen box", "mini-bar", "bathtub", "free Wi-fi"] )
		{
			parent::__construct($roomNumber, $price, $bedCount, $roomType,
	 							$restroom, $balcony, $extras);
		}
	}
?>