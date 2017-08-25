import { deleteItem, setItemDescriptions, setManageMode, setItem } from './actionCreators';
import * as api from './../api/apiCalls';
import { push, goBack } from 'react-router-redux';

export const deleteItemFromServer = (id) => (dispatch) => {
    return api.deleteItem(id)
        .then((response) => {
            if (!response.data.isError) {
                dispatch(deleteItem(id));
            } else {
                return "error";
            }
        })
        .catch((error) => {
            return "error";
        });
}
export const getItemDescriptionsFromServer = () => (dispatch) => {
    return api.getDescriptions()
        .then((response) => {
            dispatch(setItemDescriptions(response.data.data));
        })
        .catch((error) => {
            return "error";
        });
}

export const editItem = (id) => (dispatch) => {
    return api.getItem(id)
        .then((response) => {
            dispatch(setManageMode(true));
            dispatch(push('/newsurvey'));
            dispatch(setItem(response.data.data));
        })
        .catch((error) => {
            console.log(error);
        });
}

export const saveItem = (item) => (dispatch) => {
    console.log(item);
    return api.saveItem(item)
        .then((response) => {
            dispatch(setManageMode(false));
            dispatch(push('/mysurvey'));
            dispatch(setItem({}));
        });
}

export const cancelCreation = (item) => (dispatch) => {
    dispatch(goBack());
    return dispatch(setManageMode(false));
}