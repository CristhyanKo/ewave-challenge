import React, { Component, Fragment } from "react";
import logo from "../../assets/logo.png";
import { Container, ImageBox, Box, LivroData, ActionButtons } from "./styles";
import api from "../../services/api";
import moment from "moment";
import { Modal } from "antd";
import Livro from "../../components/Livro";

export default class Detalhes extends Component {
	state = {
		livro: {},
		isLoading: true,
		modalVisible: false,
		modalEditar: false
	};

	componentDidMount() {
		api.get(
			`/livros/busca-especifica?id=${this.props.location.state.idLivro}`
		).then(response => {
			this.setState({
				livro: response.data,
				isLoading: false
			});
		});
	}

	atualizaState = () => {
		api.get(
			`/livros/busca-especifica?id=${this.props.location.state.idLivro}`
		).then(response => {
			this.setState({
				livro: response.data,
				isLoading: false
			});
		});
	};

	removerLivro = () => {
		api.delete(`/livros?id=${this.props.location.state.idLivro}`)
			.then(() => this.props.history.goBack())
			.catch(err => console.log(err));
	};

	showModal = () => {
		this.setState({ modalVisible: !this.state.modalVisible });
	};

	render() {
		const { livro } = this.state;

		return (
			<Fragment>
				{!this.state.isLoading ? (
					<Container>
						<img height={50} src={logo} alt="Bibliotech Logo" />
						<ActionButtons>
							<button
								style={{ background: "#f2a606" }}
								onClick={() => this.props.history.goBack()}
							>
								Voltar
							</button>
							<button
								onClick={() =>
									this.setState({ modalEditar: true })
								}
							>
								Alterar
							</button>
							<button onClick={this.showModal}>Excluir</button>
						</ActionButtons>
						<Modal
							title="Atenção"
							visible={this.state.modalVisible}
							onOk={this.removerLivro}
							onCancel={this.showModal}
							okText="Sim"
							cancelText="Não"
						>
							<h3>
								Você tem certeza que deseja remover este livro?
							</h3>
						</Modal>
						<Livro
							modal={this.state.modalEditar}
							modalClose={() =>
								this.setState({ modalEditar: false })
							}
							idLivro={this.props.location.state.idLivro}
							callback={this.atualizaState}
						/>
						<LivroData>
							<ImageBox>
								<img src={livro.capa} alt="Capa" />
							</ImageBox>
							<Box>
								<ul>
									<li>
										<strong>Título:</strong> {livro.titulo}
									</li>
									<li>
										<strong>Gênero:</strong>{" "}
										{livro.genero.descricao}
									</li>
									<li>
										<strong>Publicação:</strong>{" "}
										{moment(livro.dataPublicacao).format(
											"DD/MM/YYYY"
										)}
									</li>
									<li>
										<strong>Autor:</strong>{" "}
										{livro.autor.nome}
									</li>
									<li>
										<strong>Editora:</strong>{" "}
										{livro.editora.nome}
									</li>
									<li>
										<strong>Descrição:</strong>{" "}
										{livro.descricao}
									</li>
									<li>
										<strong>Sinopse:</strong>{" "}
										{livro.sinopse}
									</li>

									<li>
										<strong>Páginas:</strong>{" "}
										{livro.paginas}
									</li>
								</ul>
							</Box>
						</LivroData>
					</Container>
				) : (
					<small>Carregando...</small>
				)}
			</Fragment>
		);
	}
}
