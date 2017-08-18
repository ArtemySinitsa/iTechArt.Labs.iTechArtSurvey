import { combineReducers } from 'redux';
import { surveyReducer } from '../surveys/reducer';

const rootReducer = combineReducers({
    surveyReducer
});

export default surveyReducer;