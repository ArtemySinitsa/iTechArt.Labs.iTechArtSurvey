import React, { Component } from 'react';
import { Button, Card, CardText, CardTitle, FormGroup } from 'reactstrap';
import ItemDescriptionSummary from './components/ItemDescriptionSummary';

class ItemDescription extends Component {
    deleteItem = () => {
        this.props.handleDeleteItem(this.props.item.id);
    };

    editItem = () => {
        this.props.handleEditItem(this.props.item.id);
    };

    render() {
        const { title, description, author, questionsCount } = this.props.item;
        return (
            <div className='col-md-6 col-lg-4 p-3'>
                <Card block >
                    <CardTitle className='text-truncate'>{title}</CardTitle>
                    <CardText className='text-justify'>
                        {description}
                    </CardText>
                    <ItemDescriptionSummary author={author} count={questionsCount} />
                    <FormGroup className='mt-3 d-flex justify-content-end'>
                        <Button onClick={this.editItem}>Edit</Button>
                        <Button onClick={this.deleteItem}>Delete</Button>
                    </FormGroup>
                </Card>
            </div>
        );
    }
}

export default ItemDescription;