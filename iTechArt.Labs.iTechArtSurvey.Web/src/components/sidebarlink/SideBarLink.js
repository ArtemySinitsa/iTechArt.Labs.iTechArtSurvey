import React from 'react';
import { Link } from 'react-router-dom';

const SideBarLink = ({ link, title }) => (
    <li className='nav-item'>
        <Link to={link} className='nav-link  m-2 text-danger rounded bg-faded'>{title}</Link>
    </li>
);

export default SideBarLink;