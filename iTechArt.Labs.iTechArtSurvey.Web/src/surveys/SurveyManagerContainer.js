import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import SurveyManager from './components/surveymanager/SurveyManager';
import getSurveysInfo from './actionCreators';
import getFoundedSurveys from './selectors/selector';

const mapStateToProps = (state, props) => {
    console.log(props);
 return {
    surveys: state.surveys,
    fetching: state.fetching,
    filterSurveys:  getFoundedSurveys()(state,props),
}}
;

const mapDispatchToProps = (dispatch) => ({
    getSurveysInfo: bindActionCreators(getSurveysInfo, dispatch),
});

export class SurveyManagerContainer extends Component {
    render() {
        return (
            <div>
                <SurveyManager
                    getSurveysInfo={this.props.getSurveysInfo}
                    surveys={this.props.surveys}
                    filterSurveys = {this.props.filterSurveys}
                />
                {
                    this.props.fetching && <i className='fa fa-spinner fa-spin fa-3x'></i>
                }
            </div>

        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SurveyManagerContainer);