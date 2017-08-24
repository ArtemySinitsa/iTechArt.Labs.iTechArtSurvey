import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { ButtonGroup, ButtonToolbar, Col, Button, FormGroup, Label, Input, FormText } from 'reactstrap';
import QuestionPicker from './../question-picker/QuestionPicker';
import QuestionManager from './../question-manager/QuestionManager';
import * as api from './../../../../apiCalls';

class SurveyConstructor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            item: this.props.item
        };
    }

    leaveWithoutSaving = () => {
        this.props.cancelCreation();
    }

    setTitle = (e) => {
        const newTitle = e.target.value;
        this.setState((prevState, props) => {
            return {
                item: { ...prevState.item, title: newTitle }
            };
        });
    }

    saveItem = () => {
        api.saveItem({ ...this.state.item, questions: this.props.item.questions }).then((response) => {
            console.log(response);
        });
    }

    render() {
        if(this.props.item.questions){
        return (
            <div className='row mt-2'>
                <Col>
                    <FormGroup row>
                        <Label for='title' className='text-nowrap' sm={2}>New</Label>
                        <Col sm={10}>
                            <Input type='text'
                                value={this.state.item.title}
                                onChange={this.setTitle}
                                name='title' />
                        </Col>
                    </FormGroup>
                    <FormText color='muted'>
                        Questions: {this.props.item.questions.length},<i className='pl-2'>Author</i> : {this.props.item.author}
                    </FormText>
                    <ButtonToolbar className='d-flex justify-content-end mt-4'>
                        <ButtonGroup>
                            <Button onClick={this.saveItem}>Save</Button>
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
        } else{
            return <i className='fa fa-spinner fa-spin fa-3x'></i>;
    }
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