import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import { Input, Button } from 'reactstrap';

class SearchToolbar extends Component {
    handleSearch(e) {
        this.props.handleSearch(e.target.value);
    }

    render() {
        return (
            <div className='d-flex justify-content-between'>
                <div className='d-flex'>
                    <h3>{this.props.header}</h3>
                    <Link to={this.props.linkValue}>
                        <Button color='secondary' className='ml-4'>{this.props.link}</Button>
                    </Link>
                </div>
                <Input className='w-25'
                    type='search'
                    value={this.props.filterString}
                    placeholder='search...'
                    onChange={(e)=>this.handleSearch(e)} />
            </div>
        );
    }
}
SearchToolbar.propTypes = {
    header: PropTypes.string,
    link: PropTypes.string.isRequired,
    linkValue: PropTypes.string.isRequired,
    handleSearch: PropTypes.func.isRequired,
    filterString: PropTypes.string
};

SearchToolbar.defaultProps = {
    filterString: ""
};
export default SearchToolbar;