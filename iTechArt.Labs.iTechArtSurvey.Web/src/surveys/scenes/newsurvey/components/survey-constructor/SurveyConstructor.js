import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { ButtonGroup, ButtonToolbar, Col, Button, FormGroup, Label, Input, FormText } from 'reactstrap';

import QuestionPicker from './../question-picker/QuestionPicker';

class SurveyConstructor extends Component {

    componentWillUnmount() {
        this.props.setManageMode(false);
    }

    componentDidMount() {
        if (!this.props.manageMode) {
            this.props.setDefault();
        }
    }

    render() {
        const item = this.props.item;
        return (
            <div className='row mt-2'>
                <Col>
                    <FormGroup row>
                        <Label for='title' className='text-nowrap' sm={2}>New</Label>
                        <Col sm={10}>
                            <Input type='text' value={this.props.item.title}  name='title' />
                        </Col>
                    </FormGroup>
                    <FormText color='muted'>
                        Questions: {item.questions.length}
                    </FormText>
                    <ButtonToolbar className='d-flex justify-content-between mt-4'>
                        <ButtonGroup>
                            <Button>Save</Button>
                            <Button>Save as template</Button>
                            <Button onClick={() =>this.props.cancelCreation() }>Cancel</Button>
                        </ButtonGroup>
                    </ButtonToolbar>

                </Col>
                <div>
                    <QuestionPicker />
                </div>
            </div>
        );
    }
}
SurveyConstructor.propTypes = {
    item: PropTypes.object
};

SurveyConstructor.defaultProps = {
    item: {
        title: 'Default survey',
        questions: [
            {
                "id": 0,
                "title": "Вопрос с текстовым вариантом ответа",
                "type": "textarea",
                "required": true
            },
            {
                "id": 1,
                "title": "Вопрос с множеством вариантов ответа",
                "type": "checkbox",
                "required": true,
                "options": [
                    "Первый вариант",
                    "Второй вариант",
                    "Третий вариант",
                    "Четвертый вариант"
                ]
            },
        ]
    }
};
export default SurveyConstructor;