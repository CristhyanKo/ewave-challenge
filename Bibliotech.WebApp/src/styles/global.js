import { createGlobalStyle } from "styled-components";

const GlobalStyle = createGlobalStyle`
	* {
		margin: 0;
		padding: 0;
		box-sizing: border-box;
		outline: 0;
	}

	body {
		background: #343746 !important;
		background-color: #343746 !important;
		text-rendering: optimizeLegibility !important;
		-webkit-font-smoothing: antialiased !important;
		font-family: sans-serif;
	}
`;

export default GlobalStyle;
