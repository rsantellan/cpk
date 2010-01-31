var place = 0;
    function goForward(){
        switch(place){
            case 0:
                place++;
                hideStuff('InformacionBasica');
                showStuff('divReglas');
                showStuff('ButtonAtras');
                hideStuff('ButtonAdelante'); 
                break;
            case 1:
                place++;
                hideStuff('dinamico1');
                showStuff('dinamico2');
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
                showStuff('ButtonAdelante');
                hideStuff('ButtonAtras');
                break;
            case 2:
                place--;
                hideStuff('dinamico2');
                showStuff('dinamico1');
                showStuff('ButtonAdelante');
                break;
        }
    }
    
    
    Event.observe(window, 'load', function(){
           loadEvents();
      }); 
    function loadEvents(){
        hideStuff('divReglas');
		//$('formularioIngreso').hide();
		//$('ButtonSalvar').onclick=function(){
		//    availableSave();
		//}
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
	
	function removeAllCssClasses(el) {
        var classArray = $(el).classNames().toArray();
        for (var index = 0, len = classArray.size(); index <len; ++index) {
            $(el).removeClassName(classArray[index]);
        }
    } 