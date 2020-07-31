import React,{useState,useEffect} from 'react';
import axios from 'axios';
import * as result from "../../test_object.js" ;
import {BrowserRouter as Router,Switch,Route,Link,useRouteMatch,useParams} from "react-router-dom";



function ActorComponent(props){

	const [actor_bio,set_actor_bio] = useState("");
	const[actor_thumbnail,set_actor_thumbnail] = useState("");
	const [cast_movies,set_cast_movies]  = useState("");

	const dummy_data = [{"movie_name":"maachis",
							"poster":"https://upload.wikimedia.org/wikipedia/en/thumb/f/fe/Maachis.jpg/220px-Maachis.jpg",
							"movie_id":"323"},
							{"movie_name":"josh",
							"poster":"https://upload.wikimedia.org/wikipedia/en/thumb/e/e5/Josh_%282000_movie_poster%29.jpg/220px-Josh_%282000_movie_poster%29.jpg",
						     "movie_id":"Box7wRT9Zkg"},
						     {"movie_name":"Kya-Kehna",
						      "poster":"https://upload.wikimedia.org/wikipedia/en/thumb/1/13/Kyakehna.jpg/220px-Kyakehna.jpg",
						       "movie_id":"430"  }




						     ]





	const getMovies = () => {
		// network request for movies for the cast
		// also network request for the actor bio
		// this request will come from api
		set_cast_movies(dummy_data)
	}




	function setBio() {
	  return {__html: actor_bio};
	}




	const getBio = () => {
		axios.get(`https://en.wikipedia.org/w/api.php?action=query&format=json&origin=*&prop=extracts&titles=${props.actorData.name}`)
		.then( res => {
			let wiki_data = res.data;
			let bio_html  = wiki_data.query.pages[Object.keys(wiki_data.query.pages)[0]].extract;
			set_actor_bio(bio_html);
			})

		axios.get(`https://en.wikipedia.org/w/api.php?action=query&origin=*&format=json&prop=pageimages&titles=${props.actorData.name}&pithumbsize=200`)
		.then( res => {
			let wiki_image = res.data;
			let bio_image_source = wiki_image.query.pages[Object.keys(wiki_image.query.pages)[0]].thumbnail.source;
			set_actor_thumbnail(bio_image_source);
			})
		}

		useEffect(() => getBio() );

		useEffect(() => {getMovies()},[]);


		const onClickCastMoviehandler = e => {
		const movie_id = e.target.parentElement.dataset.movie_id;
		props.clickHandler({"id":movie_id,"type":"m"});

	}



	return(
			<div>
				<div className = "actor-bio">
					<div className  = "image-container" >
						<img src ={actor_thumbnail} ></img>
					</div>
					<div className = "wiki-html-results" dangerouslySetInnerHTML = {setBio()}></div>
				</div>

				<div className = "cast-movies" >
				{cast_movies ? cast_movies.map( (item) =>
						<Link to={`/movie/${item.movie_id}`}>
						<div onClick = {onClickCastMoviehandler} className = "movie-data-wrapper" data-movie_id = {item.movie_id}>
						<img   src = {item.poster}></img>
						<li>{item.movie_name}</li>
						</div>
					</Link>
					) :null

					}

				</div>
			</div>


		)
}


export default ActorComponent

