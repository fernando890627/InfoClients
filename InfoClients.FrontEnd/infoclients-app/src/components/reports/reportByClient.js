import React from 'react';
import MateriaUiCore from '@material-ui/core'
import Icon from '@material-ui/core/Icon';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import MaterialTable from 'material-table';
import fetchData  from '../api/fetchData';
import Loader from 'react-loader-spinner';
// import  history  from ''
import { Redirect ,Route, Link, BrowserRouter as Router } from 'react-router-dom'
class ReportByClient extends React.Component { 
    constructor(...props) {
        super(...props);
        this.state = {
          loading:true,
            nit:'',
            creditLimit:0,
            availableCredit:0,
            clientId:0,
            clients:[],
            columns: [
                { title: 'Id', field: 'visitId' },
                {title:'Sale Person',field:'salePerson.name'},
                { title: 'Date', field: 'date' },
                { title: 'Net', field: 'net' },
                { title: 'Visit Total', field: 'visitTotal' },
                { title: 'Description', field: 'description' }
              ],
              data: [],
        };
      this.handleSelectClients=this.handleSelectClients.bind(this);
      this.loadClients=this.loadClients.bind(this); 
      this.loadClientData=this.loadClientData.bind(this);
    }
    handleSelectClients(event){
      this.setState({clientId: event.target.value});
      this.loadClientData(event.target.value);
    }    

    loadClientData(clientId){
        const compState=this;
        compState.setState({loading:true})
      fetchData.getData('clients/','',clientId).then((data)=>{
        if(data){
          compState.setState({nit:data.nit,
            fullName:data.fullName,       
            creditLimit:data.creditLimit,
            availableCredit:data.availableCredit          
          })
          fetchData.getData('visits/','GetByClient/',compState.state.clientId).then((response)=>{
            compState.setState({data:response,loading:false});
           }).catch(function(){
            compState.setState({loading:false});
           })           
        }
      }).catch(function(){
        compState.setState({loading:false});
      });
      
    }      
    
    

    loadClients(){
      const compState=this;
      fetchData.getData('clients','','').then((data) => {
        compState.setState({
          clients: data.map(function(item){        
            return {label:item.fullName,value:item.clientId}
          }),loading:false
        })
      }).catch(function(){
        compState.setState({loading:false});
      })
    }
    
    async componentDidMount() {
          this.loadClients();
    }

  render(){
      return <div className="container">
        <Loader className="spinner" visible={this.state.loading} type="ThreeDots" color="#00BFFF"  height={100}  width={100}  />
            <div className="row">
            <div className="col-md-6 form-group">
              <label>Clients</label>
              <select value={this.state.clientId} className="form-control" defaultValue=""  onChange={this.handleSelectClients}>
                  <option value="0" disabled>Select..</option>
                  {
                    this.state.clients.map(function(client) {
                      return <option key={client.value} value={client.value}>{client.label}</option>;
                    })
                  }
                </select>
                </div>
                <div className="col-md-6 form-group">
                  <label>NIT</label>
                  <div>
                    <input disabled={true} value={this.state.nit} className="form-control" type="text"/></div>
                </div>
                <div className="col-md-6 form-group">
                  <label>Credit Limit</label>
                  <div>
                    <input disabled={true} value={this.state.creditLimit} className="form-control" type="text"/></div>
                </div> 
                <div className="col-md-6 form-group">
                  <label>Available Credit</label>
                  <div>
                    <input disabled={true} value={this.state.availableCredit} className="form-control" type="text"/></div>
                </div>     
            </div>
            <div className="row">
              <div className="col-md-12">
                <MaterialTable
                  title="History by client"
                  columns={this.state.columns}
                  data={this.state.data}      
                />
              </div>           
            </div>
          </div>
  } 
}

export default ReportByClient