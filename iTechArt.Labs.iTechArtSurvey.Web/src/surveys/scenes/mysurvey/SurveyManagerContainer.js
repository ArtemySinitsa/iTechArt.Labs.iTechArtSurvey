import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import ItemManager from './components/item-manager/ItemManager';
import { getItemDescriptionsFromServer, setFilter, deleteItem, editItem } from './../../actions/actionCreators';
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
    deleteItem: bindActionCreators(deleteItem, dispatch),
    editItem: bindActionCreators(editItem, dispatch)
});

class SurveyManagerContainer extends Component {
    render() {
        return (
            <div>
                <ItemManager
                    filterString={this.props.filterString}
                    getItemDescriptions={this.props.getItemDescriptions}
                    items={this.props.surveys}
                    handleSearch={this.props.search}
                    handleDeleteItem={this.props.deleteItem}
                    handleEditItem={this.props.editItem}
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