import React, { Component } from 'react';
import { ListGroup, ListGroupItem } from 'reactstrap';
import PropTypes from 'prop-types';
class QuestionPicker extends Component {
    generateId = () => new Date().getTime();

    render() {
        const questions = this.props.questions;
        const questionItems = questions.map((question) => (
            <ListGroupItem key={question.type}
                tag='button'
                className='bg-faded'
                onClick={() => this.props.addQuestion(
                    {
                        id: this.generateId(),
                        type: question.type,
                        options: ["default"],
                        title: question.defaultTitle
                    })
                }>
                <i className={question.icon + ' mr-2'} aria-hidden='true'></i>
                {question.label}
            </ListGroupItem>));

        return (
            <div>
                <ListGroup>
                    <ListGroupItem >
                        <h3 >Questions </h3>
                    </ListGroupItem>
                    {questionItems}
                </ListGroup>
            </div>
        );
    }
}
QuestionPicker.propTypes = {
    addQuestion: PropTypes.func.isRequired
}

QuestionPicker.defaultProps = {
    questions: [
        {
            icon: 'fa fa-list',
            label: 'Menu question(one)',
            defaultTitle: 'new question',
            type: 'radio',
        },
        {
            icon: 'fa fa-list-ol',
            label: 'Menu question(many)',
            defaultTitle: 'new question',
            type: 'checkbox',
        },
        {
            icon: 'fa fa-font',
            label: 'Text question',
            defaultTitle: 'new question',
            type: 'textarea',
        },
    ]
}

export default QuestionPicker;