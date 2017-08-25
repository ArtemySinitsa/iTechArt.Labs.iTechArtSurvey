import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { addQuestion, saveSurveyTitle } from './../../actions/actionCreators';
import { saveItem, editItem, cancelCreation } from './../../actions/middlewareActionCreators';

import SurveyConstructor from './components/survey-constructor/SurveyConstructor';

const mapStateToProps = (state) => ({
    item: state.surveys.currentItem,
    manageMode: state.surveys.manageMode,
    fetching: state.surveys.fetching
});

const mapDispatchToProps = (dispatch) => ({
    cancelCreation: bindActionCreators(cancelCreation, dispatch),
    saveItem: bindActionCreators(saveItem, dispatch),
    editSurvey: bindActionCreators(editItem, dispatch),
    addQuestion: bindActionCreators(addQuestion, dispatch),
    saveTitle: bindActionCreators(saveSurveyTitle, dispatch)
});

class SurveyConstructorContainer extends Component {
    render() {
        return (
            <SurveyConstructor
                info={{
                    title: this.props.item.title,
                    id: this.props.item.id,
                    author: this.props.item.author
                }}
                fetching={this.props.fetching}
                questions={this.props.item.questions}
                manageMode={this.props.manageMode}
                cancelCreation={this.props.cancelCreation}
                addQuestion={this.props.addQuestion}
                saveTitle={this.props.saveTitle}
                saveItem={this.props.saveItem}
            />
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SurveyConstructorContainer);