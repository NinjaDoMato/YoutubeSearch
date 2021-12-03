import Axios from 'axios';
const URL = 'api'; //process.env.VUE_APP_ROOT_API;


Axios.interceptors.response.use(response => {
    return response;
}, error => {
    throw error;
});

export default {
    blob(requestURL) {
        let authHeader = {
            method: 'GET',
            headers: this.authHeader(),
            responseType: 'blob'
        };
        return Axios.get(URL + requestURL, authHeader);
    },

    get(requestURL) {
        let authHeader = {
            method: 'GET',
            headers: this.authHeader()
        };
        return Axios.get(URL + requestURL, authHeader);
    },

    post(requestURL, data) {
        let authHeader = {
            method: 'POST',
            headers: this.authHeader()
        };
        return Axios.post(URL + requestURL, data, authHeader);
    },

    update(requestURL, data) {
        let authHeader = {
            method: 'PUT',
            headers: this.authHeader()
        };
        return Axios.put(URL + requestURL, data, authHeader);
    },

    delete(requestURL) {
        let authHeader = {
            method: 'DELETE',
            headers: this.authHeader()
        };
        return Axios.delete(URL + requestURL, authHeader);
    },

    authHeader() {
        let USER = JSON.parse(localStorage.getItem('user'));
        if (USER && USER.token) {
            return { 'Authorization': 'Bearer ' + USER.token };
        } else {
            return {};
        }
    }
};