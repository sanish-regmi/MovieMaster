import React,{Component} from 'react'


function Genres(){
	const [genre_value,set_genre_value] = useState("");

	const genres = []

	return(
		<div className = "button-group">
		<button type="button" class="btn btn-light">Comedy</button>
		<button type="button" class="btn btn-light">Horror</button>
		<button type="button" class="btn btn-light">Action</button>
		<button type="button" class="btn btn-light">Romantic</button>
		<button type="button" class="btn btn-light">Drama</button>
		<button type="button" class="btn btn-light">Hindi Dubbed</button>
		<button type="button" class="btn btn-light">Nepali</button>
		</div>


		)
}

export default Genres