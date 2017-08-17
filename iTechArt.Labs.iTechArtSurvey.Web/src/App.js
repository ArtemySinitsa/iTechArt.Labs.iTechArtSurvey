import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';

import Navigation from './components/navigation/Navigation';
import SurveyConstructor from './components/surveyconstructor/SurveyConstructor';
import SurveyManager from './components/surveymanager/SurveyManager';
import TemplateManager from './components/templatemanager/TemplateManager';

class App extends Component {
  render() {
    return (
      <div className='row'>
        <Navigation />
        <main className='col-8'>
          <Switch>
            <Route path='/newsurvey' component={SurveyConstructor} />
            <Route path='/mysurvey' component={SurveyManager} />
            <Route path='/templates' component={TemplateManager} />
          </Switch>
        </main>
      </div>
    );
  }
}

export default App;
