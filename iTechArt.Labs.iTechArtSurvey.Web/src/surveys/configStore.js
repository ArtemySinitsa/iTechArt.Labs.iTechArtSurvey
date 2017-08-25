import rootReducer from './rootReducer';
import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
const initialState = {
    surveys: {
        fetching: true,
        manageMode: false,
        itemDescriptions: [],
        filter: '',
        currentItem: {}
    }
};

const configStore = (middleware) => (createStore(
    rootReducer,
    initialState,
    compose(
        applyMiddleware(thunk, ...middleware),
        window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
    ))
);

export default configStore;