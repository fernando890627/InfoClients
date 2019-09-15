import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { Route, Link, BrowserRouter as Router } from 'react-router-dom'
import './index.css';
import App from './components/app/App';
import Client from './components/client/newclient';
import Reports from './components/reports/reports';
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
  clientId:0
}

const routing = (
    <Router>
      <div>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
          <Link to={{ pathname: '/client', state: tempState }}>New Client</Link>
            {/* <Link to={{pathname:"/client",satet:{clientId:0}}}>New Client</Link> */}
          </li>
          <li>
            <Link to="/reports">Reports</Link>
          </li>
          <li>
            <Link to="/clientactions">Edit Client</Link>
          </li>
        </ul>
        <Route exact path="/" component={App} />
        <Route path="/client" component={Client} />
        <Route path="/reports" component={Reports} />
        <Route path="/clientactions" component={ClientActions} />
      </div>
    </Router>
  )

ReactDOM.render(routing, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
