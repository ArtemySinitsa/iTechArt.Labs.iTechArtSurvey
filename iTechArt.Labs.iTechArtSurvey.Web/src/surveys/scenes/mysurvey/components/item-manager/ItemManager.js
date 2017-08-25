import React, { Component } from 'react';
import { Row } from 'reactstrap';
import PropTypes from 'prop-types';

import ItemDescription from './../item-description/ItemDescription';
import Loading from './../../../../components/loading/Loading';
import SearchToolbar from './../search-toolbar/SearchToolbar';

class ItemManager extends Component {
    componentDidMount() {
        this.props.getItemDescriptions()
    }
    render() {
        const items = this.props.items.map((item) => (
            <ItemDescription key={item.id}
                item={item}
                handleEditItem={this.props.handleEditItem}
                handleDeleteItem={this.props.handleDeleteItem} />
        ));

        if (this.props.fetching) {
            return <Loading loading={this.props.fetching} />;
        } else {
            return (
                <div className='h-100'>
                    <SearchToolbar
                        header="Surveys"
                        link="New"
                        linkValue="/newsurvey"
                        handleSearch={this.props.handleSearch}
                        filterString={this.props.filterString}/>
                    <Row>
                        {items}
                    </Row>
                    <h4>{'Count: ' + this.props.totalCount}</h4>
                </div>
            );
        }
    }
}

ItemManager.propTypes = {
    items: PropTypes.array,
    fetching: PropTypes.bool.isRequired,
    totalCount: PropTypes.number,
    filterString: PropTypes.string.isRequired,
    getItemDescriptions: PropTypes.func.isRequired,
    handleSearch: PropTypes.func.isRequired,
    handleDeleteItem: PropTypes.func.isRequired,
    handleEditItem: PropTypes.func.isRequired,
};

ItemManager.defaultProps = {
    items: []
};

export default ItemManager;