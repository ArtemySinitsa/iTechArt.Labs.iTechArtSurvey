import React, { Component } from 'react';
import { Button, Card, CardText, CardTitle, FormGroup } from 'reactstrap';
import ItemDescriptionSummary from './components/ItemDescriptionSummary';

class ItemDescription extends Component {
    deleteItem = () => {
        this.props.handleDeleteItem({ type: this.props.type.toLowerCase(), id: this.props.item.id });
    };

    editItem = () => {
        this.props.handleEditItem(this.props.item.id);
    };

    render() {
        const item = this.props.item;
        return (
            <div className='col-md-6 col-lg-4 p-3'>
                <Card block >
                    <CardTitle>{item.title}</CardTitle>
                    <CardText className='text-justify'>
                        {item.description}
                    </CardText>
                    <ItemDescriptionSummary author={item.author} questions={item.questionsCount} />
                    <FormGroup className='mt-3 d-flex justify-content-end'>
                        <Button onClick={() => this.editItem()}>Edit</Button>
                        <Button onClick={() => this.deleteItem()}>Delete</Button>
                    </FormGroup>
                </Card>
            </div>
        );
    }
}

export default ItemDescription;