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