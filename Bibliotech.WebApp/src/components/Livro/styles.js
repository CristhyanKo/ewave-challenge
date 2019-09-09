import styled from "styled-components";

const Container = styled.div`
	display: flex;
	flex-direction: column;
	align-items: center;
`;
const ImageBox = styled.div`
	display: flex;
	background: #21222c;
	padding: 10px;
	border-radius: 3px;

	img {
		height: 250px;
	}
`;

const Box = styled.div`
	display: flex;
	flex-direction: column;
	align-items: center;
	ul {
		list-style: none;
		margin-left: 10px;

		li {
			padding: 2px 10px;
			flex: 1;
			padding: 10px;
			background: #dddddd;
			border-radius: 3px;
			margin-bottom: 5px;
			color: #21222c;
			border: 1px solid #191a21;
		}
	}
`;

const Form = styled.form`
	margin-top: 20px;
	width: 500px;
	display: flex;
	flex-direction: column;

	input {
		flex: 1;
		height: 35px;
		padding: 0 20px;
		background: #dddddd;
		border: 0;
		font-size: 12pt;
		color: #21222c;
		border-radius: 3px;
		margin: 0 10px 10px 0;
	}

	textarea {
		flex: 1;
		height: auto;
		padding: 0 20px;
		background: #dddddd;
		border: 0;
		font-size: 12pt;
		color: #21222c;
		border-radius: 3px;
		margin: 0 10px 10px 0;
	}

	select {
		flex: 1;
		height: 35px;
		padding: 0 20px;
		background: #dddddd;
		border: 0;
		font-size: 12pt;
		color: #21222c;
		border-radius: 3px;
		margin: 0 10px 10px 0;
	}
`;

const TowItens = styled.div`
	display: flex;
	flex-direction: column;
	align-items: center;
	flex-flow: wrap;
`;

const OneItens = styled.div`
	display: flex;
	flex-direction: row;
	align-items: center;
	flex-flow: wrap;
`;

export { Container, ImageBox, Box, Form, TowItens, OneItens };
