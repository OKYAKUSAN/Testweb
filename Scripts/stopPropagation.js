/*
btnClass		类型为 String，代表按钮的类样式名。
divClass		类型为 String，代表浮动框类样式名。
[parentClass]	类型为 String，代表按钮的共同父级的类样式名。可选
*/
var stopPropagationInit = function(btnClass, divClass, parentClass){
	var stopPropagation = function(e){
		if (e.stopPropagation) e.stopPropagation();
		else e.cancelBubble = true;
	}

	$(document).click(function(e){
		var e = e || window.event;
		var elem = e.target || e.srcElement;
		while (elem) {
			if (elem.className && elem.className.indexOf(divClass)>-1) {
				return;
			}
			elem = elem.parentNode;
		}
		
		$("." + divClass + ":visible").hide();
	});
	
	var btnIndex;
	var fnToggle = function(currentObj,e){
		stopPropagation(e);
		btnIndex = $("." + btnClass).index(currentObj);
		if(btnIndex != $("." + divClass).index($("." + divClass + ":visible"))) $("." + divClass + ":visible").hide();
		$("." + divClass + ":eq(" + btnIndex + ")").slideToggle("fast");
	}
	if(parentClass){
		$("." + parentClass).delegate("." + btnClass, "click", function(e){
			fnToggle($(this),e);
		});
	} else {
		$("body").delegate("." + btnClass, "click", function(e){
			fnToggle($(this),e);
		});
	}
}

/*
var stopPropagationInit_s = function(btnClass, divClass, parentClass){
	var stopPropagation = function(e){
		if (e.stopPropagation) e.stopPropagation();
		else e.cancelBubble = true;
	}

	$(document).click(function(e){
		var e = e || window.event;
		var elem = e.target || e.srcElement;
		while (elem) {
			if (elem.className && elem.className.indexOf(divClass)>-1) {
				return;
			}
			elem = elem.parentNode;
		}
		
		$("." + divClass + ":visible").hide();
	});
	
	var fnToggle = function(currentObj,e){
	}
	if(parentClass){
		$("." + parentClass).delegate("." + btnClass, "click", function(e){
			fnToggle($(this),e);
		});
	} else {
		$("body").delegate("." + btnClass, "click", function(e){
			fnToggle($(this),e);
		});
	}
}
*/