import React from 'react';
import PropTypes from 'prop-types';

const ItemDescriptionSummary = (props) => (
    <p className='card-text'>
        <span className='font-italic'>{props.author}</span>
        {', '}
        <span><b>{props.count} </b>
            {' questions.'}
        </span>
    </p>
);

ItemDescriptionSummary.propTypes = {
    count: PropTypes.number,
    author: PropTypes.string
};

ItemDescriptionSummary.defaultProps = {
    count: 0,
    author: 'none'
};

export default ItemDescriptionSummary;

