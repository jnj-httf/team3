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


function requestAJAX(type, method, data, callback) {

	$.ajax({
		type : type,
		contentType : "application/json",
		url : method,
		data : data,
		dataType : 'json',
		timeout : 300000,
		success : function(data) {
			callback(data);
		},
		error : function() {
			showMessage(TITLE_SWEET.DEFAULT, TYPE_SWEET.ERROR,MESSAGE.ERROR_REQUEST);
		},
		done : function() {

		}
	});
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


function resetTable(nameTable, callback) {
	$('#' + nameTable).dataTable().fnDestroy();
	(callback !== undefined) ? callback() : '';
}