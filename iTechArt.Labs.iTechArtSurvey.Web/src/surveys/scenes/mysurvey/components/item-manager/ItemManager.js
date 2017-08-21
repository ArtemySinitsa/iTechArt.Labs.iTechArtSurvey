import React, { Component } from 'react';
import surveys from './../../../../fakedata/surveysInfo';
import ItemDescription from './../item-description/ItemDescription';
import { Link } from 'react-router-dom';
import { Input, Button, Row } from 'reactstrap';
import PropTypes from 'prop-types';

class ItemManager extends Component {
    componentDidMount() {
        this.handleChange({ target: { value: '' } });
        if (!this.props.items.length) {
            this.props.getItemsDescription({ type: this.props.type.toLowerCase(), items: surveys });
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
                        <h3>{this.props.type}</h3>
                        <Link to='/newsurvey'>
                            <Button color='secondary' className='ml-4'>New</Button>
                        </Link>
                    </div>
                    <Input className='w-25' type='search' placeholder='search...' name='search' onChange={(e) => this.handleChange(e)} />
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
    getItemsDescription: PropTypes.func.isRequired,
    handleSearch: PropTypes.func.isRequired,
    handleDeleteItem: PropTypes.func.isRequired,
    handleEditItem: PropTypes.func.isRequired,
};

ItemManager.defaultProps = {
    items: [],
    type: ''
};

export default ItemManager;