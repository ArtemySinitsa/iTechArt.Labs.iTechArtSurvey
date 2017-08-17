import React, { Component } from 'react';
import About from './../About';
import { Switch, Route } from 'react-router-dom';

class Main extends Component {
    render() {
        return (
            <main>
                <Switch>
                    <Route exact path='/about' component={About} />
                </Switch>
            </main>
        );
    }
}

export default Main;