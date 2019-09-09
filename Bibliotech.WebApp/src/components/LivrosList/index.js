import React, { Component } from "react";
import { Container, Box } from "./styles";
import moment from "moment";
import { stat } from "fs";

export default class LivroList extends Component {
	constructor(props) {
		super(props);
	}

	render() {
		const { livros } = this.props;
		return (
			<Container>
				{livros.map((livro, key) => (
					<Box key={key}>
						<header>
							<img src={livro.capa} alt="Capa" />
							<strong>{livro.titulo}</strong>
							<ul>
								<li>
									Editora:{" "}
									<small>
										<a href="#">{livro.editora.nome}</a>
									</small>
								</li>
								<li>
									Autor:{" "}
									<small>
										<a href="#">{livro.autor.nome}</a>
									</small>
								</li>
								<li>
									Gênero:{" "}
									<small>{livro.genero.descricao}</small>
								</li>
								<li>
									Publicação:{" "}
									<small>
										{moment(livro.dataPublicacao).format(
											"DD/MM/YYYY"
										)}
									</small>
								</li>
								<li>
									Páginas: <small>{livro.paginas}</small>
								</li>
							</ul>

							<button
								onClick={() =>
									this.props.history.push({
										pathname: "/detalhes",
										state: {
											idLivro: livro.id
										}
									})
								}
							>
								Mais detalhes
							</button>
						</header>
					</Box>
				))}
			</Container>
		);
	}
}
