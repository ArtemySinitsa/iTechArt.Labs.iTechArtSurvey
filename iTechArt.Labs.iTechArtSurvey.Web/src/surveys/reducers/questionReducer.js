import * as types from './../actions/actionTypes';

export const questions = (questions = [], action) => {
    switch (action.type) {
        case types.SAVE_QUESTION:
            return questions.map(q => {
                return q.id === action.question.id ?
                    action.question : q;
            });
        case types.DELETE_QUESTION:
            let index = questions.findIndex(q => q.id === action.questionId);
            return [
                ...questions.slice(0, index),
                ...questions.slice(index + 1),
            ];
        case types.ADD_QUESTION:
            return [...questions, action.question];
        default:
            return questions;
    }
}