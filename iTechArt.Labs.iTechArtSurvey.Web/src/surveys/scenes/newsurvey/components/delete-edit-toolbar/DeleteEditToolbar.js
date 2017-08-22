import React, { Component } from 'react';
import PropTypes from 'prop-types';
import classNames from 'classnames';

class DeleteEditToolbar extends Component {

    onSave = ()=>{
        if(this.props.editMode){
            this.props.onSave();
        }
        this.props.setEditMode(!this.props.editMode)
    }
    
    render() {
        return (
            <div className={classNames({
                'invisible': this.props.hidden
            })}>
                <a role='button'
                    onClick={()=>this.onSave()}
                    className={classNames({
                        'fa p-1': true,
                        'fa-pencil': !this.props.editMode,
                        'fa-save': this.props.editMode,
                        'invisible': this.props.deleteOnly
                    })}></a>

                <a role='button'
                    className='fa fa-trash ml-3'
                    onClick={() => this.props.onDelete(this.props.id) } />
            </div>
        );
    }
}

DeleteEditToolbar.propTypes = {
    onDelete: PropTypes.func.isRequired,
    hidden: PropTypes.bool,
    editMode: PropTypes.bool
};

DeleteEditToolbar.defaultProps = {
    editMode: false
}
export default DeleteEditToolbar;