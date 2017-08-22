import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { FormGroup, Label, Input } from 'reactstrap';

class TextQuestion extends Component {
    render() {
        return (
            <FormGroup>
                <Label for="exampleText">Reply</Label>
                <Input type="textarea" disabled name="text" id="exampleText" />
            </FormGroup>
        );
    }
}
export default TextQuestion;