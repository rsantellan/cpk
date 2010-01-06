var place = 0;
    function goForward(){
        switch(place){
            case 0:
                place++;
                hideStuff('InformacionBasica');
                showStuff('divReglas');
                showStuff('ButtonSalvar');
                showStuff('ButtonAtras');
                hideStuff('ButtonAdelante'); 
                break;
            case 1:
                place++;
                hideStuff('dinamico1');
                showStuff('dinamico2');
                showStuff('ButtonSalvar');
                hideStuff('ButtonAdelante');
                break;
        }
    }
    function goBack(){
        switch(place){
            case 1:
                showStuff('InformacionBasica');
                place--;
                hideStuff('divReglas');
                hideStuff('ButtonSalvar');
                showStuff('ButtonAdelante');
                hideStuff('ButtonAtras');
                break;
            case 2:
                place--;
                hideStuff('dinamico2');
                showStuff('dinamico1');
                hideStuff('ButtonSalvar');
                showStuff('ButtonAdelante');
                break;
        }
    }
    
    
    Event.observe(window, 'load', function(){
           loadEvents();
      }); 
    function loadEvents(){
        hideStuff('ButtonSalvar');
        hideStuff('divReglas');
		$('formularioIngreso').hide();
		$('ButtonSalvar').onclick=function(){
		    availableSave();
		}
    }
    function availableSave(){
        save = true;
    }
    var save = false;
	
    function getIdentifier(){
        return $F('HiddenFieldIdentificador');
    }
    
    function getVersion(){
        return $F('HiddenFieldVersion');
    }
    
    function showStuff(id) {
		document.getElementById(id).style.display = 'block';
	}
	
	function hideStuff(id) {
		document.getElementById(id).style.display = 'none';
	}
	
	function leave(){
	    if(save)return;
	    var objectId = $F('HiddenFieldId');
		$('HiddenFieldId').value = "0";
		if(objectId == 0) return;
		var ident = getIdentifier();
		var version =getVersion();
		url = 'cleanUpFamily.aspx?id='+escape(objectId)+'&identifier='+escape(ident)+'&version='+escape(version);
		var myAjax = new Ajax.Request(
			url,
			{
				method: 'post',
				onSuccess: function(req) {
				    alert('La informacion a sido borrada');
				}
				
			});	 
	}
	
	window.onbeforeunload = function(){
	    leave();
	}
	
	function removeAllCssClasses(el) {
        var classArray = $(el).classNames().toArray();
        for (var index = 0, len = classArray.size(); index <len; ++index) {
            $(el).removeClassName(classArray[index]);
        }
    } 