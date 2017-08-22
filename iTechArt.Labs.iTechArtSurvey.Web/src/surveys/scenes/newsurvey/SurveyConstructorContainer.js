import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { clearCurrentItem, cancelCreation, setManageMode, editItem,addQuestion } from './../../actions/actionCreators';


import SurveyConstructor from './components/survey-constructor/SurveyConstructor';

const mapStateToProps = (state) => ({
    item: state.surveys.currentItem,
    manageMode: state.surveys.manageMode
});

const mapDispatchToProps = (dispatch) => ({
    setDefault: bindActionCreators(clearCurrentItem, dispatch),
    cancelCreation: bindActionCreators(cancelCreation, dispatch),
    setManageMode: bindActionCreators(setManageMode, dispatch),
    editSurvey: bindActionCreators(editItem, dispatch),
    addQuestion: bindActionCreators(addQuestion,dispatch)
});

class SurveyConstructorContainer extends Component {
    render() {
        return (
            <SurveyConstructor
                route={this.props.route}
                item={this.props.item}
                manageMode={this.props.manageMode}
                setDefault={this.props.setDefault}
                cancelCreation={this.props.cancelCreation}
                addQuestion={this.props.addQuestion}
            />
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SurveyConstructorContainer);