Event.observe(window, 'load', function() {
    loadEvents();
});
function loadEvents() {
}
    
    function getIdentifier(){
        return $F('HiddenFieldIdentificador');
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

