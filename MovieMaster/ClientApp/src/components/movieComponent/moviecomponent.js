import React, {PureComponent} from "react";
import * as result from "../../test_object.js" ;
import CastComponent from './castcomponent.js';
import MoviePlayer from '../moviePlayer/movieplayer.js';

class MovieComponent extends React.Component{


	constructor(props){
		super(props);
		this.state = {"selected_movie_id":""};

	}


	componentDidMount(){
		this.setState({"selected_movie_id":this.props.movieData.id})
	}



	displaycast(props){
		let movie_cast = [];
		const movies_only_result = result.default.filter(item => item.type === 'm');
		console.log(movies_only_result);
		for(var i = 0;i<movies_only_result.length;i++){
			if (movies_only_result[i].movie_id === props.movie_id){
				// this.setState({'movie_cast':movies_only_result[i].actors});
				movie_cast = movies_only_result[i].actors;
			}
		}
		return movie_cast
	}

	render(){

		return(
			<div>
			<MoviePlayer movie_id = {this.state.selected_movie_id} key ={this.state.selected_movie_id}  />
			<CastComponent moviecastClick = {this.props.onCastClick} cast = {this.displaycast} movie_id = {this.props.movieData.id}/>
			</div>
			)
	}
}


export default MovieComponent;
