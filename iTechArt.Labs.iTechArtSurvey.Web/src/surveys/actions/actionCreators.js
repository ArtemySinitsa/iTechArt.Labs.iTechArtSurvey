import * as types from './actionTypes';

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

export function saveSurveyTitle(title) {
    return {
        type: types.SAVE_SURVEY_TITLE,
        title
    }
}

export function setItemDescriptions(items) {
    return {
        type: types.SET_ITEMS_DESCRIPTION,
        items
    };
}

export function setItem(item) {
    return {
        type: types.SET_ITEM,
        item
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

export const addQuestion = (question) => {
    return {
        type: types.ADD_QUESTION,
        question
    }
}

export function saveQuestion(question) {
    return {
        type: types.SAVE_QUESTION,
        question
    }
}

export function deleteQuestion(questionId) {
    return {
        type: types.DELETE_QUESTION,
        questionId
    }
}

