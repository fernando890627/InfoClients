import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Route, Link, BrowserRouter as Router } from 'react-router-dom'
import './index.css';
import App from './components/app/App';
import Client from './components/client/newclient';
import ReportByCity from './components/reports/reportByCity';
import ReportByClient from './components/reports/reportByClient';
import ClientActions from './components/client/clientactions';
import * as serviceWorker from './serviceWorker';

const tempState={
  nit:'',
  fullName:'',
  address:'',
  phone:'',
  countryId:null,
  stateId:null,
  cityId:null,
  creditLimit:'',
  states:[],
  countries:[],
  cities:[],
  clientId:0,
  logVisit:0
}

const routing = (
    <Router>
        <div className="container">
                    <nav class="navbar navbar-expand-lg navbar-light bg-primary">
                        <div class="container">
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo03" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>
                            <a class="navbar-brand" href="#">Banshee S.A.</a>

                            <div class="collapse navbar-collapse" id="navbarTogglerDemo03">
                                <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                                    <li class="nav-item">
                                    <Link to="/" className="nav-link">Home</Link>                                   
                                    </li>
                                    <li class="nav-item">
                                    <Link className="nav-link" to={{ pathname: '/client', state: tempState }}>New Client</Link>
                                    </li>
                                    <li class="nav-item">
                                    <Link className="nav-link" to="/clientactions">Client List</Link>
                                    </li>
                                    <li class="nav-item">
                                    <Link className="nav-link" to="/reportbyclient">Report by client</Link>
                                    </li>
                                    <li class="nav-item">
                                    <Link className="nav-link" to="/reportbycity">Report by city</Link>                                    
                                    </li>
                                </ul>                                
                            </div>
                        </div>
                    </nav>
                </div>
                <Route exact path="/" component={App} />
                                <Route path="/client" component={Client} />
                                <Route path="/reportbyclient" component={ReportByClient} />
                                <Route path="/reportbycity" component={ReportByCity} />
                                <Route path="/clientactions" component={ClientActions} />

      {/* <div>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
          <Link to={{ pathname: '/client', state: tempState }}>New Client</Link>
          </li>
          <li>
            <Link to="/clientactions">Client List</Link>
          </li>
          <li>
            <Link to="/reportbyclient">Report by client</Link>
          </li>
          <li>
            <Link to="/reportbycity">Report by city</Link>
          </li>      
        </ul>
        <Route exact path="/" component={App} />
        <Route path="/client" component={Client} />
        <Route path="/reportbyclient" component={ReportByClient} />
        <Route path="/reportbycity" component={ReportByCity} />
        <Route path="/clientactions" component={ClientActions} />
      </div> */}
    </Router>
  )

ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
