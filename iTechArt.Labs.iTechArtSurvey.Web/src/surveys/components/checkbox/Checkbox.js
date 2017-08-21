import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { FormGroup, Label, Input } from 'reactstrap';

class Checkbox extends Component {
    render() {
        const children = this.props.children;
        return (
            <FormGroup check>
                <Label check>
                    <Input type='checkbox' />{' '}
                    {children}
                </Label>
            </FormGroup>
        );
    }
}
Checkbox.propTypes = {
    children: PropTypes.string.isRequired
};

Checkbox.defaultProps = {
    
};
export default Checkbox;