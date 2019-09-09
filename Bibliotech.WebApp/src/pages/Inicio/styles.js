import styled from "styled-components";

const Container = styled.div`
	display: flex;
	flex-direction: column;
	align-items: center;
	padding-top: 60px;
`;

const Form = styled.form`
	margin-top: 20px;
	width: 100%;
	max-width: 600px;
	display: flex;

	input {
		flex: 1;
		height: 35px;
		padding: 0 20px;
		background: #21222c;
		border: 0;
		font-size: 12pt;
		color: #dddddd;
		border-radius: 3px;
	}

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

export { Container, Form };
