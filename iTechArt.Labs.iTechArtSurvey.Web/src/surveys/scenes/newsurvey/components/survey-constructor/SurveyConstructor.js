import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { ButtonGroup, ButtonToolbar, Col, Button, FormGroup, Label, Input, FormText } from 'reactstrap';
import QuestionPicker from './../question-picker/QuestionPicker';
import QuestionManager from './../question-manager/QuestionManager';
import * as api from './../../../../api/apiCalls';
import Loading from './../../../../components/loading/Loading';

class SurveyConstructor extends Component {
    leaveWithoutSaving = () => {
        this.props.cancelCreation();
    }

    setTitle = (e) => {
        this.props.saveTitle(e.target.value);
    }

    saveItem = () => {
        this.props.saveItem({
            ...this.props.info,
            questions: [...this.props.questions]
        });
    }

    render() {
        if (this.props.manageMode && this.props.fetching) {
            return <Loading loading={this.props.fetching} />;
        } else {
            return (
                <div className='row mt-2'>
                    <Col>
                        <FormGroup row>
                            <Label for='title' className='text-nowrap' sm={2}>Title</Label>
                            <Col sm={10}>
                                <Input type='text'
                                    defaultValue={this.props.info.title}
                                    onBlur={this.setTitle}
                                    name='title' />
                            </Col>
                        </FormGroup>
                        <FormText color='muted'>
                            Questions: {this.props.questions.length},<i className='pl-2'>Author</i> : {this.props.author}
                        </FormText>
                        <ButtonToolbar className='d-flex justify-content-end mt-4'>
                            <ButtonGroup>
                                <Button onClick={this.saveItem}>Save</Button>
                                <Button onClick={this.leaveWithoutSaving}>Cancel</Button>
                            </ButtonGroup>
                        </ButtonToolbar>
                        <QuestionManager
                            questions={this.props.questions}
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
}
SurveyConstructor.propTypes = {
    info: PropTypes.object,
    questions: PropTypes.array.isRequired,
    manageMode: PropTypes.bool,
    fetching: PropTypes.bool,
    addQuestion: PropTypes.func.isRequired,
    saveItem: PropTypes.func.isRequired,
    saveTitle: PropTypes.func.isRequired,
    cancelCreation: PropTypes.func.isRequired,
};

SurveyConstructor.defaultProps = {
    title: 'Default survey',
    id: "0000000-0000-0000-0000-000000000000",
    author: "new",
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
};


export default SurveyConstructor;