import styled from "styled-components";

const Container = styled.div`
	display: flex;
	flex-direction: column;
	align-items: center;
	padding-top: 60px;
`;

const ImageBox = styled.div`
	display: flex;
	background: #fff;
	padding: 10px;
	border-radius: 3px;

	img {
		height: 350px;
	}
`;

const Box = styled.div`
	width: 100%;
	max-width: 600px;

	ul {
		list-style: none;
		margin-left: 10px;

		li {
			padding: 2px 10px;
			flex: 1;
			padding: 10px;
			background: #21222c;
			border-radius: 3px;
			margin-bottom: 5px;
			color: #dddddd;
			border: 1px solid #191a21;
		}
	}
`;

const LivroData = styled.div`
	margin-top: 30px;
	display: flex;
	flex-direction: row;
	align-items: flex-start;
`;

const ActionButtons = styled.div`
	margin-top: 30px;
	display: flex;
	flex-direction: row;
	align-items: flex-start;

	button {
		height: 35px;
		padding: 0 20px;
		margin-left: 10px;
		background: #8942f4;
		color: #fff;
		border: 0;
		font-size: 12pt;
		border-radius: 3px;
		cursor: pointer;
		transition: 0.3s;

		&:hover {
			background: #9b5ff5;
		}
	}
`;

export { Container, ImageBox, Box, LivroData, ActionButtons };
