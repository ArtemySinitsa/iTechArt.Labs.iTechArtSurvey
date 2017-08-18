import { createSelector } from 'reselect';

const getSurveys = (state, props) => state.surveys;

const getFoundedSurveys = ()=> createSelector(
    getSurveys,
    (surveys,input) => {
        if (surveys) {
            console.log(input);
            return surveys.filter(s=>s.title.startsWith('Y'))
        }
    }
);

export default getFoundedSurveys;