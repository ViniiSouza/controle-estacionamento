import axios from 'axios'

export default {
    getAll: () => {
        return axios.get('https://localhost:7169/registro')
    }
}