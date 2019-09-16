import React from 'react';
import MateriaUiCore from '@material-ui/core'
import Icon from '@material-ui/core/Icon';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import MaterialTable from 'material-table';
import fetchData  from '../api/fetchData';
// import  history  from ''
import { Redirect ,Route, Link, BrowserRouter as Router } from 'react-router-dom'
class ReportByCity extends React.Component { 
    constructor(...props) {
        super(...props);
        this.state = {
            countryId:0,
            stateId:0,
            cityId:0,
            states:[],
            countries:[],
            cities:[],
            columns: [
              { title: 'Id', field: 'visitId' },
              {title:'Client',field:'client.fullName'},
              { title: 'Date', field: 'date' },
              { title: 'Net', field: 'net' },
              { title: 'Visit Total', field: 'visitTotal' },
              { title: 'Description', field: 'description' }
              ],
              data: [],
        };
      this.handleSelectCity=this.handleSelectCity.bind(this);
      this.handleSelectState=this.handleSelectState.bind(this);
      this.handleSelectCountry=this.handleSelectCountry.bind(this);   
    }
    handleSelectCity(event){
      this.setState({cityId: event.target.value});
      fetchData.getData('visits/','GetByCity/',event.target.value).then((response)=>{
        this.setState({data:response});
       });
    }
    handleSelectState(event){
      var value=event.target.value;
      fetchData.getData('cities/','GetCityByState/',value).then((data) => {
          if(data){
            this.setState({cityId:null,stateId:value,
              cities: data.map(function(item){        
                return {label:item.name,value:item.id}
              }),
            })
          }        
      })
      
    }
    handleSelectCountry(event){
      var value=event.target.value;
      fetchData.getData('states/','GetStateByCountry/',value).then((data) => {
        if(data){
          this.setState({stateId:null,countryId:value,
            states: data.map(function(item){        
              return {label:item.name,value:item.stateId}
            }),
          })
        }      
      });  
    }

    loadCountries(){
      fetchData.getData('countries','','').then((data) => {
        this.setState({
          countries: data.map(function(item){        
            return {label:item.name,value:item.countryId}
          }),
        })
      })
    }
    async componentDidMount() {
          this.loadCountries(); 
    }

  render(){
      return <div className="container">
            <div className="row">
            <div className="col-md-4 form-group">
              <label>Country</label>
              <select value={this.state.countryId} className="form-control" defaultValue="" required onChange={this.handleSelectCountry}>
                  <option value="0" disabled>Select..</option>
                  {
                    this.state.countries.map(function(country) {
                      return <option key={country.value} value={country.value}>{country.label}</option>;
                    })
                  }
                </select>
                </div>
                <div className="col-md-4 form-group">
                <label>State</label>
                <select value={this.state.stateId} className="form-control" defaultValue="" required onChange={this.handleSelectState}>
                  <option value="0" disabled>Select..</option>
                  {
                    this.state.states.map(function(state) {
                      return <option key={state.value} value={state.value}>{state.label}</option>;
                    })
                  }
                </select>
                </div>
                <div className="col-md-4 form-group">
                <label>City</label>
                <select value={this.state.cityId} className="form-control" defaultValue="" required onChange={this.handleSelectCity}>
                  <option value="0" disabled>Select..</option>
                  {
                    this.state.cities.map(function(city) {
                      return <option key={city.value} value={city.value}>{city.label}</option>;
                    })
                  }
                </select>
                </div>
            </div>
            <div className="row">
              <div className="col-md-12">
                <MaterialTable
                  title="Visits by city"
                  columns={this.state.columns}
                  data={this.state.data}      
                />
              </div>           
            </div>
          </div>
  } 
}

export default ReportByCity