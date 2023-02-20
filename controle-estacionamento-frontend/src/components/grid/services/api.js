import axios from 'axios'

export default {
    getAll: () => {
        return axios.get('https://localhost:7169/registro')
    },
    marcarEntrada: (dto) => {
        return axios.post('https://localhost:7169/registro', dto)
    },
    marcarSaida: (dto) => {
        return axios.put('https://localhost:7169/registro', dto)
    }
}