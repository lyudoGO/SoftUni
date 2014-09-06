
function findMostFreqWord(inputText)  {
		inputText = inputText.toLowerCase();
		var text = inputText.match(/[a-zA-Z0-9_]+/g);
		var mapText = {};
		var maxCountWord = 0;
		//write word in object and they count
		for (var i = 0; i < text.length; i++) {
		    mapText[text[i]] = (mapText[text[i]] || 0) + 1;
		};
		//find max count of word
		for (var word in mapText){
			var count = mapText[word];
			if( count > maxCountWord){
				maxCountWord = count;
			}
		};
		//write to array and sort word
		var sortMapText = Object.keys(mapText);
		sortMapText.sort();
		//print 
		for (var word in sortMapText){
			var count = mapText[sortMapText[word]];
			if( count === maxCountWord){
				console.log("%s -> %d times", sortMapText[word], count);
			}
		};
		console.log("\n");
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');

