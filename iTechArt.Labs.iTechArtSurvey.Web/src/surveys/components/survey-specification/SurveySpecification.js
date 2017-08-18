import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { ListGroup, ListGroupItem } from 'reactstrap';

import Checkbox from './../../../app/components/checkbox/Checkbox';

class SurveySpecification extends Component {
    render() {
        const optionItems = this.props.options.map((option) => {
            return <ListGroupItem key={option} className='bg-faded' color='muted'>
                <Checkbox>{option}</Checkbox>
            </ListGroupItem>;
        })
        return (
            <ListGroup className='mt-2'>
                <ListGroupItem>
                    <h3>Options </h3>
                </ListGroupItem>
                {optionItems}
            </ListGroup>
        );
    }
}
SurveySpecification.propTypes = {
    options: PropTypes.array.isRequired
};

SurveySpecification.defaultProps = {
    options: [
        'Anonymous',
        'Question numbers',
        'Page numbers',
        'Random order',
        'Stars of required fields',
        'Progress indicator'
    ]
};
export default SurveySpecification;