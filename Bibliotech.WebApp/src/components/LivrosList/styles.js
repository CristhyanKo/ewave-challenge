import styled from "styled-components";

const Container = styled.div`
	display: flex;
	flex-direction: row;
	justify-content: center;
	margin-top: 50px;
	flex-flow: wrap;
`;

const Box = styled.div`
	width: 250px;
	background: #fff;
	border-radius: 3px;
	display: flex;
	flex-direction: column;
	margin: 0 10px 40px 10px;

	header {
		padding: 10px;
		display: flex;
		flex-direction: column;
		align-items: center;

		strong {
			font-size: 20px;
			margin-top: 10px;
			text-align: center;
			height: 50px;
			max-height: 45px;
		}

		img {
			width: 100%;
			height: 270px;
			object-fit: cover;
			border-radius: 3px;
		}
	}

	ul {
		list-style: none;
		margin-top: 10px;

		li {
			padding: 2px 10px;
			width: 250px;
			small {
				font-weight: normal;
				font-size: 12px;
				color: #999;
				font-style: italic;

				a {
					text-decoration: none;
					font-weight: normal;
					font-size: 12px;
					color: #999;
					font-style: italic;

					&:hover {
						color: #f2a606;
					}
				}
			}

			&:nth-child(2n - 1) {
				background: #f5f5f5;
			}
		}
	}

	button {
		position: relative;
		top: 25px;
		height: 35px;
		padding: 0 20px;
		margin-left: 10px;
		background: #f2a606;
		color: #fff;
		border: 0;
		font-size: 12pt;
		border-radius: 3px;
		cursor: pointer;
		transition: 0.3s;

		&:hover {
			background: #c68704;
		}
	}
`;

export { Container, Box };
