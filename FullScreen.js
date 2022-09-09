
$(document).ready(function () {
    
    function setUpVideos() {
        var players = $('.video-player');
        players.each(function () {
            var player = videojs(this);
            player.bigPlayButton.on('mouseup', function () {
                player.requestFullscreen();
            });
            player.posterImage.on('mouseup', function () {
                player.requestFullscreen();
            });
            player.bigPlayButton.on('touchend', function () {
                player.requestFullscreen();
            });
            player.posterImage.on('touchend', function () {
                player.requestFullscreen();
            });
            player.on('ended', function () {
                player.exitFullscreen();
            });
            player.on('fullscreenchange', function () {
                if (!player.isFullscreen()) player.pause();
            });
        });
    }
   
    setUpVideos();
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        setUpVideos();
    });

});
