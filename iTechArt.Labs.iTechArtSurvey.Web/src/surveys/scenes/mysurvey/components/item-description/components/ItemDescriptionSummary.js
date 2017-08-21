import React from 'react';
import PropTypes from 'prop-types';

const ItemDescriptionSummary = (props) => (
    <p className='card-text'>
        <span className='font-italic'>{props.author}</span>
        {', '}
        <span><b>{props.questions} </b>
            {' questions.'}
        </span>
    </p>
);

ItemDescriptionSummary.propTypes = {
    questions: PropTypes.number,
    author: PropTypes.string
};

ItemDescriptionSummary.defaultProps = {
    questions: 0,
    author: 'none'
};

export default ItemDescriptionSummary;

