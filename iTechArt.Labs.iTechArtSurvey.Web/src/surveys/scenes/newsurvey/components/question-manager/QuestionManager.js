import React, { Component } from 'react';
import PropTypes from 'prop-types';
import QuestionEditor from './../question-editor/QuestionEditor';

class QuestionManager extends Component {
    render() {
        const questions = this.props.questions.map((q, index) => (
            <QuestionEditor key={q.id}
                question={q}
                index={index + 1} />
        ));
        return (
            <div className='mt-3'>
                {questions}
            </div>
        );
    }
}

QuestionManager.propTypes = {
    questions: PropTypes.array
};

export default QuestionManager;