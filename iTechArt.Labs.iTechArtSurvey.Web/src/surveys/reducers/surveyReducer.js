import * as types from './../actions/actionTypes';

export const surveyReducer = (state = {}, action) => {
    switch (action.type) {
        case types.GET_ITEMS_DESCRIPTION:
            return { ...state, ...{ [action.payload.type]: action.payload.items, fetching: false } };
        case types.SET_FILTER_STRING:
            return { ...state, filter: action.payload };
        case types.DELETE_ITEM:
            let index = state[action.payload.type].findIndex(i => i.id === action.payload.id);
            return {
                ...state,
                ...{
                    [action.payload.type]: [
                        ...state[action.payload.type].slice(0, index),
                        ...state[action.payload.type].slice(index + 1)
                    ]
                }
            };
        case types.GET_ITEM:
            return { ...state, currentItem: action.payload };
        case types.SET_MANAGE_MODE:
            return { ...state, manageMode: action.payload };
        case types.CLEAR_CURRENT_ITEM:
            return { ...state, currentItem: undefined }
        default:
            return state;
    }
}

export default surveyReducer;
