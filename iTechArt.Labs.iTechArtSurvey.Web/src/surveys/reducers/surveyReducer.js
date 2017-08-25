import * as types from './../actions/actionTypes';
import { questions } from './questionReducer';

export const surveyReducer = (state = {}, action) => {
    switch (action.type) {
        case types.SET_ITEMS_DESCRIPTION:
            return { ...state, itemDescriptions: action.items, fetching: false };
        case types.SET_FILTER_STRING:
            return { ...state, filter: action.input };

        case types.DELETE_ITEM:
            let index = state.itemDescriptions.findIndex(i => i.id === action.id);
            return {
                ...state,
                itemDescriptions: [
                    ...state.itemDescriptions.slice(0, index),
                    ...state.itemDescriptions.slice(index + 1)
                ]
            };
        case types.SET_ITEM:
            return { ...state, currentItem: action.item, fetching: false };
        case types.SET_MANAGE_MODE:
            return { ...state, manageMode: action.payload, fetching: true };
        case types.CLEAR_CURRENT_ITEM:
            return { ...state, currentItem: undefined };
        case types.SAVE_SURVEY_TITLE:
            return { ...state, currentItem: { ...state.currentItem, title: action.title } };

        case types.DELETE_QUESTION:
        case types.SAVE_QUESTION:
        case types.ADD_QUESTION:
            return {
                ...state,
                currentItem: {
                    ...state.currentItem,
                    questions: questions(state.currentItem.questions, action)
                }
            };
        default:
            return state;
    }
}

export default surveyReducer;
