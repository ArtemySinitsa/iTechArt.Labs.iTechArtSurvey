import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Navigation from './components/navigation/Navigation';
import SurveyConstructorContainer from './scenes/newsurvey/SurveyConstructorContainer';
import SurveyManagerContainer from './scenes/mysurvey/SurveyManagerContainer';

class App extends Component {
  render() {
    return (
      <div className='row mt-5'>
        <Navigation />
        <main className='col-9'>
          <Switch>
            <Route path='/newsurvey' component={SurveyConstructorContainer} />
            <Route path='/mysurvey' component={SurveyManagerContainer} />
          </Switch>
        </main>
      </div>
    );
  }
}

export default App;
