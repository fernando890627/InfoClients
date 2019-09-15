const FetchData = {
  baseUrl:'http://localhost:50282/api/',
  getData: function(type,action,id){
      return fetch(this.baseUrl+type+action+id)
      .then(res => res.json())
      .catch(console.log)
  },
  postItem:function(item,type){    
    return fetch(this.baseUrl+type, {
              method: 'post',
              headers:{
                'Content-Type': 'application/json'
              },
              body: item
          });
  },
  deletItem:function(type,id){    
    return fetch(this.baseUrl+type+id, {
              method: 'delete',
              headers:{
                'Content-Type': 'application/json'
              }
          });
  }
  
}
export default FetchData;