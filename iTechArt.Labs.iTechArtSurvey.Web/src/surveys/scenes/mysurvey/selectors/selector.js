import { createSelector } from 'reselect';

const getSurveys = (state) => state.surveys.itemDescriptions;
const getFilter = (state) => state.surveys.filter;

export const getFilteredItems = () => createSelector(
    getSurveys,
    getFilter,
    (items, filter) => items.filter(s => s.title.match(new RegExp('^' + filter, 'i')))
);