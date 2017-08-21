import { createSelector } from 'reselect';

const getSurveys = (state) => state.surveys.surveys;
const getTemplates = (state) => state.surveys.templates;
const getFilter = (state) => state.surveys.filter;

export const getFilteredSurveys = () => createSelector(
    getSurveys,
    getFilter,
    (items, filter) => items.filter(s => s.title.match(new RegExp('^' + filter, 'i')))
);
export const getFilteredTemplates = () => createSelector(
    getTemplates,
    getFilter,
    (items, filter) => items.filter(s => s.title.match(new RegExp('^' + filter, 'i')))
);