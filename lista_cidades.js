function getcidades(){
	
	var url = 'https://api-ldc-hackathon.herokuapp.com/api/ubs/1';
	var xhr = new XMLHttpRequest();
	xhr.open('GET', url, true);
	xhr.responseType = 'json';
	xhr.onload = function(){
		var status = xhr.status;

		if(status === 200)
		{
			callback(null, xhr.response);
		}
		else
		{
			callback(status, xhr.response);
		}
	};
	xhr.send();

}	

function readTextFile() {
  var rawFile = new XMLHttpRequest();
  rawFile.open("GET", "citys.txt", true);
  rawFile.onreadystatechange = function() {
    if (rawFile.readyState === 4) {
      var allText = rawFile.responseText;
      document.innerHTML = allText;
    }
  }
  rawFile.send();
}