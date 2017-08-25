import React, { Component } from 'react';
import ItemDescription from './../item-description/ItemDescription';
import { Link } from 'react-router-dom';
import { Input, Button, Row } from 'reactstrap';
import PropTypes from 'prop-types';

class ItemManager extends Component {
    componentDidMount() {
        if (!this.props.items.length) {
            this.props.getItemDescriptions();
        }
    }

    handleChange(e) {
        this.props.handleSearch(e.target.value);
    }

    render() {
        const items = this.props.items.map((item) => (
            <ItemDescription
                handleEditItem={this.props.handleEditItem}
                item={item}
                type={this.props.type}
                handleDeleteItem={this.props.handleDeleteItem}
                key={item.id} />
        ));

        return (
            <div>
                <div className='d-flex justify-content-between'>
                    <div className='d-flex'>
                        <h3>Surveys</h3>
                        <Link to='/newsurvey'>
                            <Button color='secondary' className='ml-4'>New</Button>
                        </Link>
                    </div>
                    <Input className='w-25' type='search' value={this.props.filterString} placeholder='search...' name='search' onChange={(e) => this.handleChange(e)} />
                </div>
                <Row>
                    {items}
                </Row>
            </div>
        );
    }
}

ItemManager.propTypes = {
    type: PropTypes.string.isRequired,
    items: PropTypes.array,
    getItemDescriptions: PropTypes.func.isRequired,
    handleSearch: PropTypes.func.isRequired,
    handleDeleteItem: PropTypes.func.isRequired,
    handleEditItem: PropTypes.func.isRequired,
};

ItemManager.defaultProps = {
    items: [],
    type: ''
};

export default ItemManager;