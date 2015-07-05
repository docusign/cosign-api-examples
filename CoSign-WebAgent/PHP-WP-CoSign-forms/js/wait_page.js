// wait_page.js
//
jQuery(function($, undefined) {

var fetch_status = function(context) {
	if (context.waiting === false) {
		return; // all done!
	}
	
	$.ajax({
		url: "/wp-json/cfs/v1/request/" + context.uid,
		type: 'GET',
		context: context
	})
	.done(function( data ) {
		if (this.waiting && data && data.msg && data.msg.length != $('#msg2').html().lenth) {
			$('#msg2').html(data.msg);
		}
		window.setTimeout(fetch_status, 750, context); // repeat!		
	});
}

var intervalID;

function form_sign(uid) {
	$.ajax({
		url: "/wp-json/cfs/v1/request/" + uid,
		type: 'POST',
		context: info
	})
	.done(function( data ) {
		if (data && data.redirect_url) {
			window.location = data.redirect_url;
		}
	})
	.always(function( data ) {
		this.waiting = false;
		stop_count_down();
	})
	.fail (function(jqXHR, textStatus, errorThrown){ 
		this.waiting = false;
		var msg = errorThrown;
		if (jqXHR.status === 400 && jqXHR.responseJSON[0].message) {
			msg = jqXHR.responseJSON[0].message;
		}
		$('#errmsg').html($('#errmsg').html() + "<p>Problem: " + msg + "</p>");
	});

	window.setTimeout(fetch_status, 500, info);	
}

function start_count_down(start) {
	$('#countDown').text(start);
	intervalID = window.setInterval(function(){
		$('#countDown').text($('#countDown').text()-1);
		}, 500, $);
}

function stop_count_down() {
	window.clearInterval(intervalID);
	$('#countDown').text('');
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

// Mainline

// Start the count down clock
var info = {waiting: true, uid: cfs_uid};
start_count_down(200);
form_sign(cfs_uid);

});

