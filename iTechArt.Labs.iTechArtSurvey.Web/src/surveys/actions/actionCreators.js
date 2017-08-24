import * as types from './actionTypes';
import { push, goBack } from 'react-router-redux';
import * as api from './../apiCalls';

export function setItem(item) {
    return {
        type: types.SET_ITEM,
        item
    };
}

export function deleteItem(id) {
    return {
        type: types.DELETE_ITEM,
        id
    };
}

export function setFilter(input) {
    return {
        type: types.SET_FILTER_STRING,
        input
    };
}

export function setItemDescriptions(items) {
    return {
        type: types.SET_ITEMS_DESCRIPTION,
        items
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

export const cancelCreation = (item) => {
    return function (dispatch) {
        dispatch(goBack());
        return dispatch(setManageMode(false));
    }
}

export const editItem = (id) => {
        return function(dispatch){
            return api.getItem(id)
            .then((response)=>{
                var itemDescriptions = JSON.parse(response.data.Data);
                dispatch(setItem(itemDescriptions));
                dispatch(push('/newsurvey'));
                dispatch(setManageMode(true));
                
            })
            .catch((error)=>{
                 console.log(error);
            });
         }
     }

export const addQuestion = (question)=>{
    return{
        type: types.ADD_QUESTION,
        question
    }
}

export function deleteQuestion(questionId){
    return {
        type: types.DELETE_QUESTION,
        questionId
    }
}

export const getItemDescriptionsFromServer = ()=>{
    return function(dispatch){
       return api.getDescriptions()
       .then((response)=>{
           var itemDescriptions = JSON.parse(response.data.Data);
           dispatch(setItemDescriptions(itemDescriptions));
       })
       .catch((error)=>{
            console.log(error);
       });
    }
}

export function saveQuestion(question){
    return {
        type: types.SAVE_QUESTION,
        question
    }
}