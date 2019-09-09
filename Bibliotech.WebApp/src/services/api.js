import axios from "axios";

const api = axios.create({
	baseURL: "http://localhost:49467/api/v1/"
});

export default api;
