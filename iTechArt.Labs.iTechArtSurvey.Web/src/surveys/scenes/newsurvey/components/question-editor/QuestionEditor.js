import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Card, FormGroup, Label, Input, Form } from 'reactstrap';
import DeleteEditToolbar from './../delete-edit-toolbar/DeleteEditToolbar';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { deleteQuestion, saveQuestion } from './../../../../actions/actionCreators';
import { MultiQuestion, TextQuestion } from './../questions';


const mapStateToProps = (state) => ({
    state
});

const mapDispatchToProps = (dispatch) => ({
    deleteQuestion: bindActionCreators(deleteQuestion, dispatch),
    saveQuestion: bindActionCreators(saveQuestion, dispatch),
});

class QuestionEditor extends Component {
    constructor(props) {
        super(props);
        this.state = {
            editMode: false,
            question: props.question
        };
    }

    changeQuestionOption = (index, option) => {
        this.setState((prevState, props) => {
            return {
                question: {
                    ...prevState.question,
                    options: [
                        ...prevState.question.options.slice(0, index),
                        option,
                        ...prevState.question.options.slice(index + 1)
                    ]
                }
            };
        });
    }

    deleteQuestionOption = (index) => {
        this.setState((prevState, props) => {
            return {
                question: {
                    ...prevState.question,
                    options: [
                        ...prevState.question.options.slice(0, index),
                        ...prevState.question.options.slice(index + 1)
                    ]
                }
            };
        });
    }

    addQuestionOption = () => {
        this.setState((prevState, props) => {
            return {
                question: {
                    ...prevState.question,
                    options: [...prevState.question.options, '']
                }
            };
        });
    }

    getQuestionComponent(type) {
        switch (type) {
            case 'textarea':
                return <TextQuestion editMode={this.state.editMode} question={this.state.question} />;
            case 'checkbox':
            case 'radio':
                return <MultiQuestion type={type}
                    deleteOption={this.deleteQuestionOption}
                    changeOption={this.changeQuestionOption}
                    addOption={this.addQuestionOption}
                    editMode={this.state.editMode}
                    question={this.state.question} />
            default:
                break;

        }
    }

    setEditMode = (value) => {
        this.setState({
            editMode: value
        });
    }

    changeTitle = (e) => {
        const newTitle = e.target.value;
        this.setState((prevState, props) => {
            return {
                question: { ...prevState.question, title: newTitle }
            };
        });
    }

    saveQuestion = () => {
        this.props.saveQuestion(this.state.question);
    }
    
    render() {
        return (
            <div className='pt-3'>
                <Card block>
                    <div className='d-flex justify-content-end'>
                        <DeleteEditToolbar
                            id={this.props.question.id}
                            onSave={this.saveQuestion}
                            onDelete={this.props.deleteQuestion}
                            setEditMode={this.setEditMode}
                            editMode={this.state.editMode} />
                    </div>
                    <Form >
                        <FormGroup className='d-flex' >
                            <Label for='title' className='text-nowrap pr-2' >{this.props.index}{'.'}</Label>
                            <Input type='text'
                                disabled={!this.state.editMode}
                                value={this.state.question.title}
                                onChange={(e) => this.changeTitle(e)}
                                name='title' />
                        </FormGroup>
                        {this.getQuestionComponent(this.state.question.type)}
                    </Form>

                </Card>
            </div>
        );
    }
}

QuestionEditor.propTypes = {
    question: PropTypes.object.isRequired,
    index: PropTypes.number.isRequired
};

export default connect(mapStateToProps, mapDispatchToProps)(QuestionEditor);