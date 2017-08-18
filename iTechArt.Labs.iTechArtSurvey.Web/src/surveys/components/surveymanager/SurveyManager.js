import React, { Component } from 'react';
import surveys from './../../surveysInfo';
class SurveyManager extends Component {
    componentWillMount() {
        setTimeout(()=>this.props.getSurveysInfo(surveys),
            1);

    }
    render() {
        return (
            <div>
                <h1>Here will be survey manager</h1>
                {
                    // this.props.surveys && this.props.surveys[0].title
                }
                <br />
                {this.props.surveys && this.props.surveys.length}
            </div>
        );
    }
}

export default SurveyManager;