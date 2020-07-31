import React from 'react';
import * as result from "../../test_object.js" ;



class CastComponent extends React.Component {
	constructor(props) {
		super(props);
		this.state = {'actors':[]}
	}


	setActors(props){
		const cast = this.props.cast(this.props);
		this.setState({'actors':cast});

	}


	componentDidMount(){
		this.setActors();
	}


	onCastClick(e){
		e.preventDefault();
		const actor_name = e.target.dataset.actorname;
		// console.log(actor_name);
		this.props.moviecastClick(actor_name);
	}

	render(){
		return(
				<div className = 'cast-suggestions'>
				{this.state.actors.map((item) =>
					<div  className="cast">
					<li>{item.name}</li>
					<img onClick= {(e) => this.onCastClick(e) } data-actorname = {item.name} src = {item.image} ></img>
					</div>
					)
			}
				</div>

			)


	}
}

export default CastComponent;