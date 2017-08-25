import { combineReducers } from 'redux';
import { surveyReducer } from './reducers/surveyReducer';
import { routerReducer } from 'react-router-redux'

export default combineReducers({
    surveys: surveyReducer,
    router: routerReducer
});
