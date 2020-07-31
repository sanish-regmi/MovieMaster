import React,{useState,useEffect} from 'react';
import Search from '../../components/searchComponent/search';
import {Link,Redirect,useParams,useRouteMatch} from "react-router-dom";


var movie1 = "https://m.media-amazon.com/images/M/MV5BZjAwZjc1MjktNmMwOS00MzA5LWE3MDktMzUxMmMzOTgxYjk3XkEyXkFqcGdeQXVyNjc5Mjg4Nzc@._V1_SX300.jpg";
var movie2 = "https://m.media-amazon.com/images/M/MV5BM2M0NTJjNDYtNjFhMC00MmEzLTk4NjYtNGY4MDhlNTMzYTlmXkEyXkFqcGdeQXVyODMzMjMzOTg@._V1_SX300.jpg"

function Home(props){

	const [home_page_movies,set_home_page_movies] = useState({latest_addition:[],
															 nepali_movies:[{id:"ser234d",image_url:movie1},
															 {id:"serd3245",image_url:movie2}],
															 dubbed_movies:[]})
	const [cast_specific_search_query,set_cast_specific_search_query] = useState({query:false,search_query:""});

	const [display_latest_movies,set_display_latest_movies] = useState(true);
	const searchHandler =  props.searchSuggestionHandler;


	const movieClickHandler =  props.searchSuggestionHandler;

	// api to request data from ,this will set state
	useEffect(()=>console.log("useffect"),home_page_movies)

	let {movie_id} = useParams()






	return(
		<div>

		{ cast_specific_search_query.query === false ?
			<div className = "container-fluid">
				<div className = "row">
					<div className = "col">
						<nav className="navbar navbar-dark bg-dark justify-content-between">
							<a className="navbar-brand">Mero Madrasi Movies</a>
							<form className="form-inline">
								<Search clickedSuggestionHandler = {searchHandler}>
								</Search>
						   </form>
					   </nav>
					</div>
				</div>

				<div className = "row">
					<div className = "col">
						<div className = "category_wrapper">
							<div className = "category_header">
								<span>Recently Added</span>
								{home_page_movies.latest_addition.map((item) => <li>{item})</li>)}
							</div>
						</div>
					</div>
				</div>
				<div className = "row">
					<div className = "col">
						<div className = "category_wrapper">
							<div className = "category_header">
								<span>Dubbed Movies</span>
								{home_page_movies.latest_addition.map((item) => <li>{item})</li>)}
							</div>
						</div>
					</div>
				</div>
				<div className = "row">
					<div className = "col">
						<div className = "category_header">Nepali Movies</div>
							<div className = "category_wrapper">


								{home_page_movies.nepali_movies.map((item) =>

									<div className = "movie_container">

									    <img  src = {item.image_url}/>

									    <Link to={`/movie/${item.id}`}>
									    <button onClick = {()=> movieClickHandler({"id":item.id,"type":"m"})}
									    className = "play_icon"/>
									    </Link>
									    <input type = "hidden" data-movie_id = {item.id} />
								    </div>

								)}


						</div>
					</div>
				</div>
		</div>

		:

		<div>
			<li>clicked on cast suggestions</li>
		</div>

	}
	</div>


	)
}


export default Home
