import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { ButtonGroup, ButtonToolbar, Col, Button, FormGroup, Label, Input, FormText } from 'reactstrap';
import QuestionPicker from './../question-picker/QuestionPicker';
import QuestionManager from './../question-manager/QuestionManager';

class SurveyConstructor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            title: props.item.title
        };
    }
    leaveWithoutSaving = () => {
        this.props.cancelCreation();
        // this.props.setManageMode(false);
    }

    setTitle = (e)=>{
        this.setState({title:e.target.value});
    }
    
    render() {
        return (
            <div className='row mt-2'>
                <Col>
                    <FormGroup row>
                        <Label for='title' className='text-nowrap' sm={2}>New</Label>
                        <Col sm={10}>
                            <Input type='text' 
                            value={this.state.title} 
                            onChange={this.setTitle}
                            name='title' />
                        </Col>
                    </FormGroup>
                    <FormText color='muted'>
                        Questions: {this.props.item.questions.length}
                    </FormText>
                    <ButtonToolbar className='d-flex justify-content-between mt-4'>
                        <ButtonGroup>
                            <Button>Save</Button>
                            <Button>Save as template</Button>
                            <Button onClick={this.leaveWithoutSaving}>Cancel</Button>
                        </ButtonGroup>
                    </ButtonToolbar>
                    <QuestionManager
                        questions={this.props.item.questions}
                    />
                </Col>
                <div>
                    <QuestionPicker
                        addQuestion={this.props.addQuestion} />
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
            {
                "id": 2,
                "title": "Вопрос с выбором одного варианта ответа",
                "type": "radio",
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