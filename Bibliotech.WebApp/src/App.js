import React, { Fragment } from "react";
import GlobalStyle from "./styles/global";
import Inicio from "./pages/Inicio";
import Detalhes from "./pages/Detalhes";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

const App = props => (
	<Fragment>
		<GlobalStyle />
		<BrowserRouter>
			<Switch>
				<Route
					history={props.history}
					exact
					path="/"
					component={Inicio}
				/>
				<Route exact path="/detalhes" component={Detalhes} />
			</Switch>
		</BrowserRouter>
	</Fragment>
);
export default App;
