import React from 'react'
import fetchData  from '../api/fetchData';
import Select from 'react-select';


class Client extends React.Component {
  constructor(...props) {
      super(...props);
      this.state = {
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
          clientId:this.props.location.state?this.props.location.state.clientId:0
      };
      this.clientSubmit = this.clientSubmit.bind(this);
      this.handleNit = this.handleNit.bind(this);
      this.handleFullName = this.handleFullName.bind(this);
      this.handleAddress = this.handleAddress.bind(this);
      this.handlePhone = this.handlePhone.bind(this);
      this.handleCity = this.clientSubmit.bind(this);
      this.handleCreditLimit = this.handleCreditLimit.bind(this);
      this.handleSelectCity=this.handleSelectCity.bind(this);
      this.handleSelectState=this.handleSelectState.bind(this);
      this.handleSelectCountry=this.handleSelectCountry.bind(this);
  }

  componentDidUpdate(prevProps) {
    // let data=prevProps.location.state
    // this.setState({data});    
  }

   componentDidMount() {     
    fetchData.getData('countries','','').then((data) => {
        this.setState({
          countries: data.map(function(item){        
            return {label:item.name,value:item.countryId}
          }),
      })
    })
    if(this.state.clientId>0){
      this.loadClientData(this.state.clientId)
    }      
  }

  loadClientData(clientId){
    fetchData.getData('clients/','',clientId).then((data)=>{
      debugger;
      if(data){
        this.setState({nit:data.nit,
          fullName:data.fullName,
          address:data.address,
          phone:data.phone,
          creditLimit:data.creditLimit
        })
      }      
    }
      
      // this.state.countryId=data.countryId,
      // this.state.stateId=data.stateId,
      // this.state.cityId=data.cityId,
      // ,
      // this.state.nit=data.nit,
      // this.state.nit=data.nit,
    )
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
  handleSelectCity(event){
    this.setState({city: event.value});
  }
  handleSelectState(event){
    fetchData.getData('cities/','GetCityByState/',event.value).then((data) => {
        if(data){
          this.setState({cityId:null,stateId:event.value,
            cities: data.map(function(item){        
              return {label:item.name,value:item.cityId}
            }),
          })
        }        
    })
    
  }
  handleSelectCountry(event){
    fetchData.getData('states/','GetStateByCountry/',event.value).then((data) => {
      if(data){
        this.setState({stateId:null,countryId:event.value,
          states: data.map(function(item){        
            return {label:item.name,value:item.stateId}
          }),
        })
      }      
    });  
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
      "VisitPercentage": 0
    });
    fetchData.postItem(data,'clients').then(response =>console.log(response));  
  }

  render() {
    return <div className="container"><h1>New Client</h1>
      <div className="row">
        <div className="col-md-6 form-group">
          <label>NIT</label>
          <div><input defaultValue={this.state.nit} required onChange={this.handleNit} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
          <label>Full Name</label>
          <div><input defaultValue={this.state.fullName} required onChange={this.handleFullName} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
        <label>Address</label>
          <div><input defaultValue={this.state.address} required onChange={this.handleAddress} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
          <label>Phone</label>
          <div><input defaultValue={this.state.phone} required onChange={this.handlePhone} className="form-control" type="text"/></div>
          </div>
          <div className="col-md-4 form-group">
          <label>Country</label>
              <Select options={this.state.countries }
                  value={this.state.countryId} onChange={this.handleSelectCountry} />
            </div>
            <div className="col-md-4 form-group">
            <label>State</label>
              <Select label='name' isDisabled={this.state.states.length==0&this.state.clientId==0} value='id' options={ this.state.states}
              value={this.state.stateId} onChange={this.handleSelectState} />
            </div>
            <div className="col-md-4 form-group">
            <label>City</label>
              <Select isDisabled={this.state.cities.length==0&this.state.clientId==0} options={ this.state.cities}
              value={this.state.cityId} onChange={this.handleSelectCity} />
            </div>
        <div className="col-md-6 form-group">
          <label>Credit Limit</label>
          <div><input defaultValue={this.state.creditLimit} onChange={this.handleCreditLimit} className="form-control" type="text"/></div>
        </div>
        <div className="col-md-6 form-group">
          <label>Press the button to save</label>
        <button type="submit" onClick={this.clientSubmit} className="btn btn-primary form-control">submit</button>
        </div>
      </div>
    </div>
  }
}
export default Client