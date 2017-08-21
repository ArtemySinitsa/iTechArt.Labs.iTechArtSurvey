import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { Nav, NavItem, NavLink } from 'reactstrap';

const mapStateToProps = (state) => ({
    isManageMode: state.surveys.manageMode
});

class Navigation extends Component {
    render() {
        return (
            <Nav vertical>
                <NavItem>
                    <NavLink disabled={this.props.isManageMode} className='btn bg-faded m-2' tag={Link} to='/newsurvey'>New survey</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink className='btn bg-faded m-2' tag={Link} to='/mysurvey'>My surveys</NavLink>
                </NavItem>
            </Nav>
        );
    }
}

export default connect(mapStateToProps)(Navigation);