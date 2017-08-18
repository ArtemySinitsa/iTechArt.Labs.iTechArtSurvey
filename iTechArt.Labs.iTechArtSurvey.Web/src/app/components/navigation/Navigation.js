import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import { Nav, NavItem, NavLink } from 'reactstrap';

class Navigation extends Component {
    render() {
        return (
            <Nav vertical>
                <NavItem>
                    <NavLink className='btn bg-faded m-2' tag={Link} to='/newsurvey'>New survey</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink className='btn bg-faded m-2' tag={Link} to='/mysurvey'>My surveys</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink className='btn bg-faded m-2' tag={Link} to='/templates'>Survey templates</NavLink>
                </NavItem>
            </Nav>
        );
    }
}

export default Navigation;