import React, { Component } from 'react';
import { Container, Input, FormGroup } from 'reactstrap';
class Page extends Component {
    render() {
        return (
            <Container>
                <FormGroup>
                    <Input type='text'/>
                </FormGroup>
                Content  {this.props.page.title}
            </Container>
        );
    }
}

export default Page;