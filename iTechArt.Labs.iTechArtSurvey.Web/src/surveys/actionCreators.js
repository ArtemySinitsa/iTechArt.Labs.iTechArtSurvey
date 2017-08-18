import * as types from './actionTypes';

// export function editSurvey(surveyId) {
//     return {
//         type: types.EDIT_SURVEY,
//         payload: surveyId
//     };
// }

// export function deleteSurvey(surveyId) {
//     return {
//         type: types.DELETE_SURVEY,
//         payload: surveyId
//     };
// }

// export function createSurvey() {
//     return {
//         type: types.CREATE_SURVEY
//     };
// }

export default function getSurveysInfo(surveysInfo) {
    return {
        type: types.GET_SURVEYS_INFO,
        payload: surveysInfo
    };
}

// export const getSurveysInfo = () => (dispatch) => {
//     dispatch({
//                 type: types.GET_SURVEYS_INFO,
//                 payload: surveysInfo
//             });
//   };