import * as types from './../actions/actionTypes';
import { questions } from './questionReducer';

export const surveyReducer = (state = {}, action) => {
    switch (action.type) {
        case types.GET_ITEMS_DESCRIPTION:
            return { ...state, ...{ itemDescriptions: action.payload, fetching: false } };
        case types.SET_FILTER_STRING:
            return { ...state, filter: action.payload };

        case types.DELETE_ITEM:
            let index = state.itemDescriptions.findIndex(i => i.id === action.id);
            return {
                ...state,
                ...{
                    itemDescriptions: [
                        ...state.itemDescriptions.slice(0, index),
                        ...state.itemDescriptions.slice(index + 1)
                    ]
                }
            };
        case types.GET_ITEM:
            return { ...state, currentItem: action.payload };
        case types.SET_MANAGE_MODE:
            return { ...state, manageMode: action.payload };
        case types.CLEAR_CURRENT_ITEM:
            return { ...state, currentItem: undefined };

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
