import React,{useState,useEffect} from 'react';


function MoviePlayer(props){

var player;
var YT = window.YT;

const [nowPlaying,set_nowPlaying]  = useState('');


const SelectedMovie = () => set_nowPlaying(props.movie_id)


const SetYouTubePlayerScript = () =>{
	  // Load the IFrame Player API code asynchronously.
	  var tag = document.createElement('script');
	  tag.src = "https://www.youtube.com/player_api";
	  var firstScriptTag = document.getElementsByTagName('script')[0];
	  firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
	  window.onYouTubeIframeAPIReady = loadVideo;

	}





 useEffect(() => {
 	 SelectedMovie();
     if (!window.YT) { // If not, load the script asynchronously
      SetYouTubePlayerScript();
    } else { // If script is already there, load the video directly
    	loadVideo()
  	}

  });


 const loadVideo = () =>{
 	const video_id = props.movie_id;
 	player = new window.YT.Player('ytplayer', {
      	height: '600px',
      	width: '100%',
      	videoId:video_id
    	});

 }


return(

	<div className = "iframe-container">

	<div id="ytplayer"></div>

	</div>

	)



}


export default MoviePlayer