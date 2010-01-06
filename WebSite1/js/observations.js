function showObservation(){
	$('formularioIngreso').show();
	$('agregarObservacion').hide();
}

function addObservation()
    {
		var tarea = $F('inputTarea');
		$('inputTarea').value = "";
		var observacion = $F('TextAreaObservacion');
		$('TextAreaObservacion').value = "";
		var objectId = $F('HiddenFieldIdentificador');
	    var objectClass = $F('HiddenFieldClass');
	    var objectVersion = $F('HiddenFieldVersion');
	    url = '../Observaciones/saveObservation.aspx?tarea=' + escape(tarea) + '&observacion=' + escape(observacion) + '&objectId=' + escape(objectId) + '&objectClass=' + escape(objectClass) + '&objectVersion=' + escape(objectVersion);
		var myAjax = new Ajax.Request(
			url,
			{
				method: 'post',
				onSuccess: function(req) {
					var text =req.responseText;
					temp = text.split('|');
					addRowToTable(tarea,observacion,temp[0],temp[1],temp[2]);
						$('agregarObservacion').show();
						$('formularioIngreso').hide();
				}
				
			});	
    }
    
    function deleteObservation(id)
    {
        url = '../Observaciones/deleteObservation.aspx?observationId=' + escape(id);
		var myAjax = new Ajax.Request(
			url,
			{
				method: 'post',
				onSuccess: function(req) {
				    $('row_'+id).remove();
				}
				
			});	 
    }
    
    function addRowToTable(tarea,observacion,fecha,autor,id)
    {
        var tbl = document.getElementById('observaciones');
        var lastRow = tbl.rows.length;
        // if there's no header row in the table, then iteration = lastRow + 1
        var iteration = lastRow;
        var row = tbl.insertRow(lastRow);
        row.id = 'row_'+id;
         // left cell
        var cellLeft = row.insertCell(0);
        var textNode = document.createTextNode(tarea);
        cellLeft.appendChild(textNode);
  
        // right cell
        var cellRight1 = row.insertCell(1);
        var textNode1 = document.createTextNode(observacion);
        cellRight1.appendChild(textNode1);
      
        var cellRight2 = row.insertCell(2);
        var textNode2 = document.createTextNode(autor);
        cellRight2.appendChild(textNode2);
        
        var cellRight3 = row.insertCell(3);
        var textNode3 = document.createTextNode(fecha);
        cellRight3.appendChild(textNode3);
        
        var cellRight4 = row.insertCell(4);
         var el = document.createElement('button');
         el.type = 'button';
         el.name = 'txtRow' + id;
         el.id = 'txtRow' + id;
         var buttext = document.createTextNode('Eliminar');
	     el.appendChild(buttext);
        var textNode4 = document.createTextNode("<a href='#' onclick='deleteObservation(" + id + ")'>Eliminar</a>");
        textNode4.id = 'textNode_'+id;
        cellRight4.appendChild(el);
        $('txtRow' + id).addClassName('btn');
        document.getElementById('txtRow' + id).onclick=function(){
               deleteObservation(id);
         }
    }