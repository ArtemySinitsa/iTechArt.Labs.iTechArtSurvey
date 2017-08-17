import React, { Component } from 'react';
import SideBarLink from './../sidebarlink/SideBarLink.js';
class Navigation extends Component {
    render() {
        return (
            <nav className='sidebar left-sidebar col-4'>
                <ul className='nav nav-pills  justify-content-center flex-column'>
                    <SideBarLink link='/newsurvey' title='New survey' />
                    <SideBarLink link='/mysurvey' title='My survey' />
                    <SideBarLink link='/templates' title='Survey templates' />
                </ul>
            </nav>
        );
    }
}

export default Navigation;