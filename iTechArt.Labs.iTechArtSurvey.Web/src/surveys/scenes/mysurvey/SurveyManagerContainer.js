import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import ItemManager from './components/item-manager/ItemManager';
import { getItemsDescription, setFilter, deleteItem, openItem } from './../../actions/actionCreators';
import { getFilteredSurveys } from './selectors/selector';

const mapStateToProps = (state, props) => {
    return {
        surveys: getFilteredSurveys()(state, props),
        fetching: state.surveys.fetching,
        totalCount: state.surveys.surveys.length
    }
};

const mapDispatchToProps = (dispatch) => ({
    getItemsDescription: bindActionCreators(getItemsDescription, dispatch),
    handleSearch: bindActionCreators(setFilter, dispatch),
    handleDeleteSurvey: bindActionCreators(deleteItem, dispatch),
    handleEditSurvey: bindActionCreators(openItem, dispatch)
});

class SurveyManagerContainer extends Component {
    render() {
        return (
            <div>
                <ItemManager
                    type='Surveys'
                    getItemsDescription={this.props.getItemsDescription}
                    items={this.props.surveys}
                    handleSearch={this.props.handleSearch}
                    handleDeleteItem={this.props.handleDeleteSurvey}
                    handleEditItem={this.props.handleEditSurvey}
                />
                {
                    this.props.fetching && <i className='fa fa-spinner fa-spin fa-3x'></i>
                }
                <h4>{'Count: ' + this.props.totalCount}</h4>
            </div>

        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SurveyManagerContainer);