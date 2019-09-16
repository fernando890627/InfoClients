import React from 'react';
import MateriaUiCore from '@material-ui/core'
import Icon from '@material-ui/core/Icon';
import IconButton from '@material-ui/core/IconButton';
import Tooltip from '@material-ui/core/Tooltip';
import MaterialTable from 'material-table';
import fetchData  from '../api/fetchData';
import Client from './newclient';
// import  history  from ''
import { Redirect ,Route, Link, BrowserRouter as Router } from 'react-router-dom'
class ClientList extends React.Component { 
    constructor(...props) {
        super(...props);
        this.state = {
            columns: [
                { title: 'Id', field: 'clientId' },
                { title: 'Nit', field: 'nit' },
                { title: 'Full Name', field: 'fullName' },
                { title: 'Credit Limit', field: 'creditLimit' },
                { title: 'Available Credit', field: 'availableCredit' },
                { title: 'Visits Percentage', field: 'visitsPercentage' }
              ],
              data: [],
        };        
    }

    getClients(){
        fetchData.getData('clients','','').then(response =>this.setState({ data:response }) );
    }
    async componentDidMount() {
            this.getClients();
      }

  render(){
      return <div className="container">
          <div className="row">
              <div className="col-md-12">
              <MaterialTable
                    title="Clients List"
                    columns={this.state.columns}
                    data={this.state.data}
                    actions={[
                        {
                            icon: 'save',
                            tooltip: 'Log Visit',
                            onClick: (event, rowData) =>  {
                                this.props.history.push({
                                    pathname: '/client',
                                    state: { clientId: rowData.clientId,logVisit:1,isDelete:0 }
                                })
                            }
                            
                        },
                        {
                        icon: 'edit',
                        tooltip: 'Edit CLient',
                        onClick: (event, rowData) => {
                            this.props.history.push({
                                pathname: '/client',
                                state: { clientId: rowData.clientId,logVisit:0,isDelete:0 }
                            })
                            }
                        },        
                        {
                            icon: 'delete',
                            tooltip: 'Delete CLient',
                            onClick: (event, rowData) => {
                                this.props.history.push({
                                    pathname: '/client',
                                    state: { clientId: rowData.clientId,logVisit:0,isDelete:1 }
                                })
                            }                                
                        }
                    ]}
                    />
              </div>          
          </div>
        </div>
  } 
}

export default ClientList