import React, { Component } from "react";
import { Container, ImageBox, Box, Form, TowItens, OneItens } from "./styles";
import { Modal, Button, DatePicker } from "antd";
import api from "../../services/api";
import Axios from "axios";
import locale from "antd/es/date-picker/locale/pt_BR";
import moment from "moment";

export default class Livro extends Component {
	state = {
		titulo: "",
		dataPublicacao: null,
		paginas: "",
		descricao: "",
		sinopse: "",
		livro: {},
		editoraId: "",
		generoId: "",
		autorId: "",
		capa: "",
		id: "",
		editoras: [],
		autores: [],
		generos: [],
		modalVisible: this.props.modal,
		modalAlertVisible: false
	};

	componentDidMount() {
		api.get("/autores")
			.then(response => {
				this.setState({
					autores: response.data
				});
			})
			.then(() => {
				api.get("/editoras").then(response => {
					this.setState({
						editoras: response.data
					});
				});
			})
			.then(() => {
				api.get("/generos").then(response => {
					this.setState({
						generos: response.data
					});
				});
			});

		if (this.props.idLivro > 0) {
			this.preencheDados();
		}
	}

	constructor(props) {
		super(props);
	}

	showModal = () => {
		this.setState({ modalAlertVisible: !this.state.modalAlertVisible });
	};

	preencheDados() {
		api.get(`/livros/busca-especifica?id=${this.props.idLivro}`).then(
			response => {
				const livro = response.data;
				this.setState({
					titulo: livro.titulo,
					dataPublicacao: moment(livro.dataPublicacao).format(
						"DD/MM/YYYY"
					),
					paginas: livro.paginas,
					descricao: livro.descricao,
					sinopse: livro.sinopse,
					editoraId: livro.editoraId,
					generoId: livro.generoId,
					autorId: livro.autorId,
					capa: livro.capa,
					id: livro.id
				});
			}
		);
	}

	showModalAlert = () => {
		console.log("teste");
		this.setState({ modalAlertVisible: !this.state.modalAlertVisible });
		this.setState({ modalVisible: false });
	};

	salvar = () => {
		if (this.props.idLivro > 0) {
			const data = this.state;
			api.put("/livros", {
				titulo: data.titulo,
				dataPublicacao: moment(data.dataPublicacao).format(
					"YYYY-MM-DD"
				),
				paginas: data.paginas,
				descricao: data.descricao,
				sinopse: data.sinopse,
				editoraId: data.editoraId,
				generoId: data.generoId,
				autorId: data.autorId,
				capa: data.capa,
				id: data.id
			}).then(() => {
				this.showModalAlert();
				this.props.callback();
			});
		} else {
			const data = this.state;
			api.post("/livros", {
				titulo: data.titulo,
				dataPublicacao: moment(data.dataPublicacao).format(
					"YYYY-MM-DD"
				),
				paginas: data.paginas,
				descricao: data.descricao,
				sinopse: data.sinopse,
				editoraId: data.editoraId,
				generoId: data.generoId,
				autorId: data.autorId,
				capa: data.capa
					? data.capa
					: "https://www.kickante.com.br/sites/default/files/financiamento-coletivo/pitch/um_livro_talvez_-866890.jpg"
			}).then(() => {
				this.showModalAlert();
				this.props.callback();
				this.limpaCampos();
			});
		}
	};

	limpaCampos() {
		this.setState({
			titulo: "",
			dataPublicacao: "",
			paginas: "",
			descricao: "",
			sinopse: "",
			editoraId: "",
			generoId: "",
			autorId: "",
			capa: "",
			id: ""
		});
	}

	render() {
		const { autores, generos, editoras } = this.state;

		return (
			<Modal
				title="Livro"
				visible={this.props.modal}
				onOk={this.salvar}
				onCancel={this.props.modalClose}
				okText="Salvar"
				cancelText="Cancelar"
			>
				<Modal
					title="Atenção"
					visible={this.state.modalAlertVisible}
					onOk={() => {
						this.setState({ modalAlertVisible: false });
						this.props.modalClose();
					}}
					okText="Sim"
					footer={[
						<Button
							key="submit"
							type="primary"
							onClick={() => {
								this.setState({ modalAlertVisible: false });
								this.props.modalClose();
							}}
						>
							OK
						</Button>
					]}
				>
					<h3>Sua ação foi salva com sucesso!</h3>
				</Modal>

				<Container>
					<ImageBox>
						<img
							src={
								this.state.capa
									? this.state.capa
									: "https://www.kickante.com.br/sites/default/files/financiamento-coletivo/pitch/um_livro_talvez_-866890.jpg"
							}
							alt="Capa"
						/>
					</ImageBox>
					<Box>
						<Form>
							<OneItens>
								<input
									value={this.state.capa}
									onChange={e =>
										this.setState({
											capa: e.target.value
										})
									}
									type="text"
									placeholder="URL Imagem Capa"
								/>
							</OneItens>
							<OneItens>
								<input
									value={this.state.titulo}
									onChange={e =>
										this.setState({
											titulo: e.target.value
										})
									}
									type="text"
									placeholder="Título"
								/>
							</OneItens>
							<TowItens>
								<DatePicker
									defaultValue={
										this.state.dataPublicacao
											? moment(
													this.state.dataPublicacao,
													"DD/MM/YYYY"
											  )
											: ""
									}
									format={"DD/MM/YYYY"}
									placeholder={"Data de Publicação"}
									locale={locale}
									style={{ marginRight: "10px" }}
									onChange={e =>
										this.setState({
											dataPublicacao: e
										})
									}
								/>
								{/* <input
									value={
										this.state.dataPublicacao.length > 9
											? moment(
													this.state.dataPublicacao
											  ).format("DD/MM/YYYY")
											: this.state.dataPublicacao
									}
									type="text"
									onChange={e =>
										this.setState({
											dataPublicacao: e.target.value
										})
									}
									placeholder="Data Publicação"
								/> */}
								<input
									value={this.state.paginas}
									onChange={e =>
										this.setState({
											paginas: e.target.value
										})
									}
									type="number"
									placeholder="Páginas"
								/>
							</TowItens>
							<OneItens>
								<textarea
									value={this.state.descricao}
									onChange={e =>
										this.setState({
											descricao: e.target.value
										})
									}
									rows="6"
									placeholder="Descrição"
								/>
							</OneItens>
							<OneItens>
								<textarea
									value={this.state.sinopse}
									onChange={e =>
										this.setState({
											sinopse: e.target.value
										})
									}
									rows="4"
									placeholder="Sinopse"
								/>
							</OneItens>
							<OneItens>
								<select
									value={this.state.editoraId}
									onChange={e => {
										this.setState({
											editoraId: parseInt(e.target.value)
										});
									}}
								>
									<option value="">
										Selecionar Editora..
									</option>
									{editoras.map((item, key) => (
										<option key={key} value={item.id}>
											{item.nome}
										</option>
									))}
								</select>
							</OneItens>
							<TowItens>
								<select
									value={this.state.generoId}
									onChange={e => {
										this.setState({
											generoId: parseInt(e.target.value)
										});
									}}
								>
									<option value="">
										Selecionar Gênero..
									</option>
									{generos.map((item, key) => (
										<option key={key} value={item.id}>
											{item.descricao}
										</option>
									))}
								</select>
								<select
									value={this.state.autorId}
									onChange={e => {
										this.setState({
											autorId: parseInt(e.target.value)
										});
									}}
								>
									<option value="">
										Selecionar Autor...
									</option>
									{autores.map((item, key) => (
										<option key={key} value={item.id}>
											{item.nome}
										</option>
									))}
								</select>
							</TowItens>
						</Form>
					</Box>
				</Container>
			</Modal>
		);
	}
}
