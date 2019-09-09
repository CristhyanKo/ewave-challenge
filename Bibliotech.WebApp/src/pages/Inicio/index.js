import React, { Component, Fragment } from "react";
import logo from "../../assets/logo.png";
import { Container, Form } from "./styles";
import LivrosList from "../../components/LivrosList";
import api from "../../services/api";
import Livro from "../../components/Livro";
import { Modal, Button } from "antd";

export default class Inicio extends Component {
	constructor(props) {
		super(props);
	}
	componentDidMount() {
		api.get("/livros").then(response => {
			this.setState({
				livros: response.data,
				isLoading: false
			});
		});
	}

	state = {
		isLoading: true,
		pesquisaInput: "",
		livros: [],
		modal: false
	};

	atualizaLista = () => {
		api.get("/livros").then(response => {
			this.setState({
				livros: response.data,
				isLoading: false
			});
		});
	};

	handlePesquisa = async e => {
		e.preventDefault();
		try {
			await api
				.get(`/livros/busca-filtrada?termo=${this.state.pesquisaInput}`)
				.then(response => this.setState({ livros: response.data }));
		} catch (error) {
			console.log(error);
		}
	};

	render() {
		return (
			<Fragment>
				{!this.state.isLoading ? (
					<Container>
						<img height={50} src={logo} alt="Bibliotech Logo" />

						<Form onSubmit={this.handlePesquisa}>
							<input
								values={this.state.pesquisaInput}
								onChange={e =>
									this.setState({
										pesquisaInput: e.target.value
									})
								}
								type="text"
								placeholder="Gênero, Autor, Título, Editora"
							/>
							<button type="submit">Pesquisar</button>
							<button
								onClick={() => this.setState({ modal: true })}
							>
								Adicionar Novo
							</button>
							<Livro
								modal={this.state.modal}
								modalClose={() =>
									this.setState({ modal: false })
								}
								callback={this.atualizaLista}
							/>
						</Form>

						<LivrosList
							history={this.props.history}
							livros={this.state.livros}
						/>
					</Container>
				) : (
					<small>Carregando...</small>
				)}
			</Fragment>
		);
	}
}
