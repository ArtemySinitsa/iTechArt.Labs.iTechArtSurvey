import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import ItemManager from './components/item-manager/ItemManager';
import { setFilter } from './../../actions/actionCreators';

import { getItemDescriptionsFromServer, deleteItemFromServer, editItem } from './../../actions/middlewareActionCreators';

import { getFilteredItems } from './selectors/selector';

const mapStateToProps = (state, props) => ({
    surveys: getFilteredItems()(state, props),
    fetching: state.surveys.fetching,
    totalCount: state.surveys.itemDescriptions.length,
    filterString: state.surveys.filter
});

const mapDispatchToProps = (dispatch) => ({
    getItemDescriptions: bindActionCreators(getItemDescriptionsFromServer, dispatch),
    search: bindActionCreators(setFilter, dispatch),
    deleteItem: bindActionCreators(deleteItemFromServer, dispatch),
    editItem: bindActionCreators(editItem, dispatch)
});

class SurveyManagerContainer extends Component {
    render() {
        return (
            <ItemManager
                filterString={this.props.filterString}
                fetching={this.props.fetching}
                totalCount={this.props.totalCount}
                items={this.props.surveys}

                getItemDescriptions={this.props.getItemDescriptions}
                handleSearch={this.props.search}
                handleDeleteItem={this.props.deleteItem}
                handleEditItem={this.props.editItem}
            />
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SurveyManagerContainer);