// thank_you_page.js
//
jQuery(function($, undefined) {

var intervalID;

function process_file(uid) {
	$.ajax({
		url: "/wp-json/cfs/v1/process_signed/" + uid,
		type: 'POST',
		context: info
	})
	.done(function( data ) {
		this.waiting = false;
		stop_count_down("done.");
		$('#download_btn').removeClass('hide');
	})
	.fail (function(jqXHR, textStatus, errorThrown){ 
		this.waiting = false;
		stop_count_down();
		var msg = errorThrown;
		if (jqXHR.status === 400 && jqXHR.responseJSON[0].message) {
			msg = jqXHR.responseJSON[0].message;
		}
		$('#errmsg').html($('#errmsg').html() + "<p>Problem: " + msg + "</p>");
	});
}

function start_count_down(start) {
	$('#countDown').text(start);
	intervalID = window.setInterval(function(){
		$('#countDown').text($('#countDown').text()-1);
		}, 500, $);
}

function stop_count_down(text) {
	if (! text) { text = ''; }
	window.clearInterval(intervalID);
	$('#countDown').text(text);
}

////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

// Mainline

// Start the count down clock
//
// cfs_webagent_info ==>> {'sessionId', 'uid', 'code', 'msg'}

if (cfs_webagent_info.code === '0') {
	start_count_down(100);

	var info = {waiting: true, uid: cfs_webagent_info.uid};
	process_file(cfs_webagent_info.uid);
}

});


