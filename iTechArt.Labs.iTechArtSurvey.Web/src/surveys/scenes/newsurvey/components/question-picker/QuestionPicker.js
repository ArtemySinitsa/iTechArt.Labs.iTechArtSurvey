import React, { Component } from 'react';
import { ListGroup, ListGroupItem } from 'reactstrap';
class QuestionPicker extends Component {
    render() {
        const questions = this.props.questions;

        const questionItems = questions.map((question) => {
            return (<ListGroupItem key={question.type} tag='button' className='bg-faded' action>
                <i className={question.icon + ' mr-2'} aria-hidden='true'></i>
                {question.type}
            </ListGroupItem>);
        });
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

QuestionPicker.defaultProps = {
    questions: [
        {
            icon: 'fa fa-list',
            type: 'Menu question(one)'
        },
        {
            icon: 'fa fa-list-ol',
            type: 'Menu question(many)'
        },
        {
            icon: 'fa fa-font',
            type: 'Text question'
        },
        {
            icon: 'fa fa-star-o',
            type: 'Rate question'
        },
        {
            icon: 'fa fa-battery-3',
            type: 'Range question'
        },
        {
            icon: 'fa fa-file',
            type: 'File question'
        },
    ]
}

export default QuestionPicker;