import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import classnames from 'classnames';

import Page from './../page/Page';

class PageHolder extends Component {
    constructor(props) {
        super(props);
        this.state = {
            activeTab: '1'
        };
    }

    toggle = (tab) => {
        if (this.state.activeTab !== tab) {
            this.setState({
                activeTab: tab
            });
        }
    }

    convertToTabs = (pages) => {
        return {
            tabs: pages.map((page, index) => {
                return (
                    <NavItem key={index}>
                        <NavLink
                            role='button'
                            className={classnames({ active: this.state.activeTab === { index } })}
                            onClick={() => this.toggle(index)}
                        > Page {index + 1}
                        </NavLink>
                    </NavItem>
                );
            }),
            content: pages.map((page, index) => {
                return (
                    <TabPane tabId={index} key={index}>
                        <Page key={'page' + index} page={page}>
                        </Page>
                    </TabPane>
                );
            })
        };
    }

    render() {
        const pages = this.props.pages;
        const { tabs, content } = this.convertToTabs(pages);

        return (
            <div className='mt-2'>
                <Nav tabs>
                    {tabs}
                </Nav>
                <TabContent activeTab={this.state.activeTab}>
                    {content}
                </TabContent>
            </div>
        );
    }
}
PageHolder.propTypes = {
    pages: PropTypes.array.isRequired
};

PageHolder.defaultProps = {
    pages: [
        { title: '1' },
        { title: '2' },
        { title: '3' },
    ]
};

export default PageHolder;