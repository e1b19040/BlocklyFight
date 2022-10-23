mergeInto(LibraryManager.library, {
	MyTestFunction: function() {
		window.alert("Test");
	},
 
	SyncFile: function() {
		FS.syncfs(false, function (err) {
			console.log('Error: syncfs failed!');
		});
	},
});
 