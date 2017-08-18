import * as types from './actionTypes';

export const surveyReducer = (state = {}, action) => {
    switch (action.type) {
        case types.GET_SURVEYS_INFO:
            return { ...state, ...{ surveys: action.payload, fetching: false } };
        default:
            return state;
    }
}
export default surveyReducer;
