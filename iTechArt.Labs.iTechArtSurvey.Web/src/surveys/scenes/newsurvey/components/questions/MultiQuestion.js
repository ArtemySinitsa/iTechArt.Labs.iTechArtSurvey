import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { FormGroup, Label, Input } from 'reactstrap';

import DeleteEditToolbar from './../delete-edit-toolbar/DeleteEditToolbar';
import classNames from 'classnames';

import { Button } from 'reactstrap';

class MultiQuestion extends Component {
    render() {
        const options = this.props.question.options.map((option, index) => (
            <div className='d-flex justify-content-between' key={index}>
                <FormGroup check>
                    <Label check>
                        <Input
                            type={this.props.type}
                            name={'index' + this.props.question.id} />{' '}
                        <Input type='text' disabled={!this.props.editMode} value={option}
                            onChange={(e) => this.props.changeOption(index, e.target.value)} />
                    </Label>
                </FormGroup>
                <DeleteEditToolbar
                    deleteOnly={true}
                    hidden={!this.props.editMode}
                    onDelete={() => this.props.deleteOption(index)} />
            </div>
        ));
        return (
            <div>
                {options}
                <div className='text-center'>
                    <Button
                        role='button'
                        className={classNames({
                            'fa fa-plus': true,
                            'invisible': !this.props.editMode
                        })}
                        onClick={() => this.props.addOption()} />
                </div>
            </div>
        );
    }
}
MultiQuestion.propTypes = {
    addOption: PropTypes.func.isRequired,
    deleteOption: PropTypes.func.isRequired,
    question: PropTypes.object
};

export default MultiQuestion;