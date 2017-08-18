import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Navigation from './components/navigation/Navigation';
import SurveyConstructor from './../surveys/components/surveyconstructor/SurveyConstructor';
import TemplateManager from './../surveys/components/templatemanager/TemplateManager';
import SurveyManagerContainer from './../surveys/SurveyManagerContainer';

class App extends Component {
  render() {
    return (
      <div className='row'>
        <Navigation />
        <main className='col-9'>
          <Switch>
            <Route path='/newsurvey' component={SurveyConstructor} />
            <Route path='/mysurvey' component={SurveyManagerContainer} />
            <Route path='/templates' component={TemplateManager} />
          </Switch>
        </main>
      </div>
    );
  }
}

export default App;
