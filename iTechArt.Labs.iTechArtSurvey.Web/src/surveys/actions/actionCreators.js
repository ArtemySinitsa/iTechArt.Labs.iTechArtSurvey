import * as types from './actionTypes';
import survey from './../fakedata/survey';
import { push, goBack } from 'react-router-redux';

export function getItem(survey) {
    return {
        type: types.GET_ITEM,
        payload: survey
    };
}

export function deleteItem(info) {
    return {
        type: types.DELETE_ITEM,
        payload: info
    };
}

export function setFilter(input) {
    return {
        type: types.SET_FILTER_STRING,
        payload: input
    };
}

export function getItemsDescription(items) {
    return {
        type: types.GET_ITEMS_DESCRIPTION,
        payload: items
    };
}
export function setManageMode(payload) {
    return {
        type: types.SET_MANAGE_MODE,
        payload
    };
}
export function clearCurrentItem() {
    return {
        type: types.CLEAR_CURRENT_ITEM
    };
}
export const editItem = (id) => {
    return function (dispatch) {
        dispatch(push('/newsurvey'));
        dispatch(getItem(survey));
        return dispatch(setManageMode(true));
    }
}

export const cancelCreation = (item) => {
    return function (dispatch) {
        dispatch(goBack());
        return dispatch(setManageMode(false));
    }
}
// export const openItem = (item) => {
//     return function (dispatch) {
//         if (!item) {
//             dispatch(clearCurrentItem);
//         }

//     }
// }

export const saveItem = (item) => {
    return function (dispatch) {
        //save item
        dispatch(clearCurrentItem());
        return dispatch(setManageMode(false));
    }
}