import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { clearCurrentItem, cancelCreation, setManageMode } from './../../actions/actionCreators';

import SurveyConstructor from './components/survey-constructor/SurveyConstructor';

const mapStateToProps = (state) => ({
    item: state.surveys.currentItem,
    manageMode: state.surveys.manageMode
});

const mapDispatchToProps = (dispatch) => ({
    setDefault: bindActionCreators(clearCurrentItem, dispatch),
    cancelCreation: bindActionCreators(cancelCreation, dispatch),
    setManageMode: bindActionCreators(setManageMode, dispatch)
});

class SurveyConstructorContainer extends Component {
    render() {
        return (
            <SurveyConstructor
                item={this.props.item}
                manageMode={this.props.manageMode}
                setDefault={this.props.setDefault}
                cancelCreation={this.props.cancelCreation}
                setManageMode={this.props.setManageMode}
            />
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SurveyConstructorContainer);