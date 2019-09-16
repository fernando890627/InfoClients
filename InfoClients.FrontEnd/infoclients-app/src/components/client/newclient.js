import React from 'react'
import fetchData  from '../api/fetchData';
import Select from 'react-select';

const tempState={
          nit:'',
          fullName:'',
          address:'',
          phone:'',
          countryId:0,
          stateId:0,
          cityId:0,
          creditLimit:'',
          availableCredit:0,
          visitsPercentage:0,
          states:[],
          countries:[],
          cities:[],
          salePersonId:0,
          salePersons:[],
          clientId:0,
          logVisit:0,
          isDelete:0,
          visitDescription:''
}
class Client extends React.Component {
  constructor(...props) {
      super(...props);
      this.state = {
          nit:'',
          fullName:'',
          address:'',
          phone:'',
          countryId:0,
          stateId:0,
          cityId:0,
          creditLimit:'',
          availableCredit:0,
          visitsPercentage:0,
          states:[],
          countries:[],
          cities:[],
          salePersonId:0,
          salePersons:[],
          clientId:this.props.location.state?this.props.location.state.clientId:0,
          logVisit:this.props.location.state?this.props.location.state.logVisit:0,
          isDelete:this.props.location.state?this.props.location.state.isDelete:0,
          visitDescription:''
      };
      this.clientSubmit = this.clientSubmit.bind(this);
      this.clientModify=this.clientModify.bind(this);
      this.clientDelete=this.clientDelete.bind(this);
      this.logVisit=this.logVisit.bind(this);
      this.handleNit = this.handleNit.bind(this);
      this.handleFullName = this.handleFullName.bind(this);
      this.handleAddress = this.handleAddress.bind(this);
      this.handlePhone = this.handlePhone.bind(this);
      this.handleCity = this.clientSubmit.bind(this);
      this.handleCreditLimit = this.handleCreditLimit.bind(this);
      this.handleSelectCity=this.handleSelectCity.bind(this);
      this.handleSelectState=this.handleSelectState.bind(this);
      this.handleSelectCountry=this.handleSelectCountry.bind(this);
      this.handleSelectSalePeron=this.handleSelectSalePeron.bind(this);
      this.handleDescription=this.handleDescription.bind(this);
  }
  componentWillReceiveProps(prevProps) {
    let data=prevProps.location.state    
    this.loadCountries();
    this.setState(data);
  } 

  loadSalePeople(){
      fetchData.getData('salesperson','','').then((data) => {
        this.setState({
          salePersons: data.map(function(item){        
            return {label:item.name,value:item.salePersonId}
          }),
      })
    })
  }

   componentDidMount() {    
    if(this.state.clientId>0){
      this.loadClientData(this.state.clientId)
    }
    if(this.state.logVisit>0){
      this.loadSalePeople();
    }
    this.loadCountries();
  } 

  loadClientData(clientId){
    fetchData.getData('clients/','',clientId).then((data)=>{
      debugger;
      if(data){
        this.setState({nit:data.nit,
          fullName:data.fullName,
          address:data.address,
          phone:data.phone,          
          creditLimit:data.creditLimit,
          availableCredit:data.availableCredit,
          visitsPercentage:data.visitsPercentage,cityId:data.cityId,
          stateId:data.stateId,
          countryId:data.countryId          
        })
        this.loadStates(this.state.countryId);
        this.loadCities(this.state.stateId);
      }      
    }
    )
  }
  handleDescription(event){
    this.setState({visitDescription: event.target.value});
  }

  handleNit(event){
    this.setState({nit: event.target.value});
  }
  handleFullName(event){
    this.setState({fullName: event.target.value});
  }
  handleAddress(event){
    this.setState({address: event.target.value});
  }
  handlePhone(event){
    this.setState({phone: event.target.value});
  }
  handleCity(event){
    this.setState({city: event.target.value});
  }
  handleCreditLimit(event){
    this.setState({creditLimit: event.target.value});
  }
  handleSelectSalePeron(event){
    this.setState({salePersonId: event.target.value});
  }
  handleSelectCity(event){
    this.setState({cityId: event.target.value});
  }
  handleSelectState(event){
    var value=event.target.value;
    this.setState({stateId: value});
    this.loadCities(value);
  }
  handleSelectCountry(event){
    var value=event.target.value;
    this.setState({country: value});
    this.loadStates(value);
  }
  loadStates(value){
    fetchData.getData('states/','GetStateByCountry/',value).then((data) => {
      if(data){
        this.setState({countryId:value,
          states: data.map(function(item){        
            return {label:item.name,value:item.stateId}
          }),
        })
      }      
    });
  }

  loadCities(value){
    fetchData.getData('cities/','GetCityByState/',value).then((data) => {
      if(data){
        this.setState({stateId:value,
          cities: data.map(function(item){        
            return {label:item.name,value:item.id}
            }),
          })
        }        
    })
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
  clientSubmit(event) {
    var data = JSON.stringify({
      "Nit": this.state.nit,
      "FullName": this.state.fullName,
      "Address": this.state.address,
      "Phone": this.state.phone,
      "CityId": this.state.cityId,
      "CreditLimit": this.state.creditLimit,
      "AvailableCredit": this.state.creditLimit,
      "VisitsPercentage": 0,
      "StateId":this.state.stateId,
      "CountryId":this.state.countryId
    });
    fetchData.postItem(data,'clients').then(response =>console.log(response));
    this.setState(tempState);  
  }

  clientModify(event) {
    var data = JSON.stringify({
      "Nit": this.state.nit,
      "FullName": this.state.fullName,
      "Address": this.state.address,
      "Phone": this.state.phone,
      "CityId": this.state.cityId,
      "CreditLimit": this.state.creditLimit,
      "AvailableCredit": this.state.availableCredit,
      "VisitPercentage": this.state.visitsPercentage?this.state.visitsPercentage:0,
      "StateId":this.state.stateId,
      "CountryId":this.state.countryId
    });
    fetchData.putItem(data,'clients/',this.state.clientId).then(response =>console.log(response));
  }
  clientDelete(){
    fetchData.deletItem('clients/',this.state.clientId);
    this.setState(tempState);
    this.loadCountries();                
  }
  logVisit(){
    var data = JSON.stringify({      
      "Description": this.state.visitDescription,
      "SalePersonId": this.state.salePersonId,
      "ClientId": this.state.clientId
    });
    fetchData.postItem(data,'visits').then(response =>console.log(response));
    this.setState(tempState);
    this.loadCountries();
  }
  render() {
    return <div className="container"><h1>Client</h1>
      { this.state.logVisit ? 
        <div className="row">
          <div className="col-md-6 form-group">
          <label>Sale Person</label>
          <select value={this.state.salePersonId} className="form-control" defaultValue="" required onChange={this.handleSelectSalePeron}>
            <option value="0" disabled>Select..</option>
            {
              this.state.salePersons.map(function(person) {
                return <option key={person.value} value={person.value}>{person.label}</option>;
              })
            }
          </select>
          </div>
          <div className="col-md-6 form-group">
            <label>Press the button to log visit</label>
            <button type="submit" onClick={this.logVisit} className="btn btn-primary form-control">Log Visit</button>
          </div>
          <div className="col-md-12 form-group">
            <label>Description</label>
          <textarea className="form-control" value={this.state.visitDescription} onChange={this.handleDescription} />
          </div>
        </div>: null }  
      <div className="row">      
        <div className="col-md-6 form-group">
          <label>NIT</label>
          <div><input disabled={this.state.logVisit||this.state.isDelete} value={this.state.nit} required onChange={this.handleNit} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
          <label>Full Name</label>
          <div><input disabled={this.state.logVisit||this.state.isDelete} value={this.state.fullName} required onChange={this.handleFullName} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
        <label>Address</label>
          <div><input disabled={this.state.logVisit||this.state.isDelete} value={this.state.address} required onChange={this.handleAddress} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
          <label>Phone</label>
          <div><input disabled={this.state.logVisit||this.state.isDelete} value={this.state.phone} required onChange={this.handlePhone} className="form-control" type="text"/></div>
          </div>
          <div className="col-md-4 form-group">
          <label>Country</label>
          <select disabled={this.state.logVisit||this.state.isDelete} value={this.state.countryId} defaultValue="Select.." className="form-control" required onChange={this.handleSelectCountry}>
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
            <select disabled={this.state.logVisit||this.state.isDelete} value={this.state.stateId} className="form-control" defaultValue="Select.." required onChange={this.handleSelectState}>
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
            <select disabled={this.state.logVisit>0||this.state.isDelete>0} value={this.state.cityId} className="form-control" defaultValue="Select.." required onChange={this.handleSelectCity}>
              <option value="0" disabled>Select..</option>
              {
                this.state.cities.map(function(city) {
                  return <option key={city.value} value={city.value}>{city.label}</option>;
                })
              }
            </select>
            </div>
        <div className="col-md-6 form-group">
          <label>Credit Limit</label>
          <div><input disabled={this.state.logVisit||this.state.isDelete} value={this.state.creditLimit} onChange={this.handleCreditLimit} className="form-control" type="text"/></div>
        </div>{
                this.state.clientId==0?
                <div className="col-md-6 form-group">
                  <label>Press the button to save information</label>
                  <button type="submit" onClick={this.clientSubmit} className="btn btn-primary form-control">Save Client</button>
                </div>
                :this.state.clientId>0&this.state.logVisit==0&this.state.isDelete==0?
                <div className="col-md-6 form-group">
                  <label>Press the button to modify information</label>
                  <button type="submit" onClick={this.clientModify} className="btn btn-primary form-control">Modify Client</button>
                </div>
                :this.state.isDelete>0&this.state.clientId>0?
                <div className="col-md-6 form-group">
                  <label>Press the button to delete information</label>
                  <button type="submit" onClick={this.clientDelete} className="btn btn-primary form-control">Delete Client</button>
                </div>:null
              }          
      </div>
    </div>
  }
}
export default Client