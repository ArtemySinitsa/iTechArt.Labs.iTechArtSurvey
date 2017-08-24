import axios from 'axios';

export const getDescriptions = () => {
    return axios.get('http://localhost:3179/api/surveys/');
}
export const getItem = (id) => {
    return axios.get('http://localhost:3179/api/surveys/' + id);
}

export const saveItem = (data) => {
    return axios.post('http://localhost:3179/api/surveys/', data);
}