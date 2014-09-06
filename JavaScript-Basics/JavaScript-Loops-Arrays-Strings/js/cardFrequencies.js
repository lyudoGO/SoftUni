
function findCardFrequency(inputCards)  {
		var cards = inputCards.match(/[a-zA-Z0-9_]+/g);
		var n = cards.length;
		var mapCards = {};

		for (var i = 0; i < cards.length; i++) {
		    mapCards[cards[i]] = (mapCards[cards[i]] || 0) + 1;
		};

		for (var card in mapCards){
			var frequency = (mapCards[card] * 100) / n;
			console.log("%s -> %s%", card, frequency.toFixed(2));
		};
		console.log("\n");
}		
findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
findCardFrequency('10♣ 10♥');

