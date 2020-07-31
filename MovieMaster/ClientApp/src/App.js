import React,{useState} from 'react';
import logo from './logo.svg';
// import Search from './components/searchComponent/search';
import AdminSearch from './components/adminSearch/admin_search';
import MovieComponent from './components/movieComponent/moviecomponent';
import ActorComponent from './components/actorComponent/actorcomponent';
import DirectorComponent from './components/directorComponent/directorcomponent';
import Home from './components/homeComponent/homecomponent';
import {BrowserRouter as Router,Switch,Route,Link,useRouteMatch,useParams} from "react-router-dom";



function App() {

	const[clickedSuggestion,set_clickedSuggestion] = useState("");
    const [clickedcast,set_clicked_cast] = useState("");



	const clickedSuggestionHandler = (data,query) => {
    set_clickedSuggestion(data);
    //sanish regmi

	}


    const onCastClickHandler =(data,query) =>{
        set_clicked_cast(data)
    }


  return (
    <Router>
        <Switch>
            <Route path="/admin">
                <AdminSearch/>
            </Route>
            <Route exact path="/">
                 <div className="App">
                 <Home searchSuggestionHandler = {clickedSuggestionHandler}>

                </Home>
            </div>
            </Route>

            <Route exact path="/movie/:id">

            {clickedSuggestion && clickedSuggestion.type === 'm' ?
                    <MovieComponent onCastClick = {onCastClickHandler}
                                    movieData = {clickedSuggestion}
                                    key = {clickedSuggestion.id} /> :""}
            </Route>
            <Route exact path="/actor/:id">
                    {clickedSuggestion && clickedSuggestion.type === 'actor'?
                    <ActorComponent
                    clickHandler = {clickedSuggestionHandler}
                    actorData = {clickedSuggestion} key = {clickedSuggestion.id}
                     />:""}
            </Route>


        </Switch>
    </Router>
  );
}

export default App;

