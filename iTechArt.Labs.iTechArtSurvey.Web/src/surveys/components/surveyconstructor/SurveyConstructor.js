import React, { Component } from 'react';
import { ButtonGroup, ButtonToolbar, Col, Button, FormGroup, Label, Input, FormText } from 'reactstrap';

import QuestionPicker from './../question-picker/QuestionPicker';
import SurveySpecification from './../survey-specification/SurveySpecification';
import PageHolder from './../page-holder/PageHolder';
class SurveyConstructor extends Component {
    render() {
        return (
            <div className='row mt-2'>
                <Col>
                    <FormGroup row>
                        <Label for='title' className='text-nowrap' sm={2}>New survey: </Label>
                        <Col sm={10}>
                            <Input type='text' value={this.props.survey && this.state.survey.title} name='title' />
                        </Col>
                    </FormGroup>
                    <FormText color='muted'>
                        Questions: {12}, pages: {3}
                    </FormText>
                    <ButtonToolbar className='d-flex justify-content-between mt-4'>
                        <ButtonGroup>
                            <Button>
                                Save
                        </Button>
                            <Button>
                                Save as template
                        </Button>
                            <Button>
                                Cancel
                        </Button>
                        </ButtonGroup>
                        <ButtonGroup>
                            <Button>New page</Button>
                        </ButtonGroup>
                    </ButtonToolbar>
                    <PageHolder/>

                </Col>
                <div>
                    <QuestionPicker />
                    <SurveySpecification />
                </div>
            </div>
        );
    }
}

export default SurveyConstructor;