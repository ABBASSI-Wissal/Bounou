using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace BridgeLibrary.Entities.Repositories
{
    ///<summary>
    ///The class <c>IssuerRepository</c>
    ///Implements the interface <c>IBounouBridge</c>
    ///this class can list,get, add, update, delete an issuer.
    ///</summary>
    public class IssuerRepository : IIssuerRepository<Issuer>
    {
        ///<value> A RestClient instance that sets the Base Url for all requests.</value>
        RestClient client = new RestClient("http://localhost:3000/");
       
        ///<summary> Get all the issuers of a network . </summary>
        ///<return> List of type Issuer </return>
        ///<param name="ConnectedUserId">A string </param>
        public List<Issuer> GetListOfAllIssuers(string ConnectedUserId)
        {
           List<Issuer> values=new List<Issuer>();
           var request=new RestRequest("/issue/get-all-issuers/{currentUserId}",Method.GET);
           request.AddUrlSegment("currentUserId",ConnectedUserId);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
                values = JsonConvert.DeserializeObject<List<Issuer>>(response.Content);   
            }
            else{
                values.Add(new Issuer(response.Content));
            } 
           return values;    
        }

        ///<summary>Get an issuer by ID .</summary>
        ///<return>An object of type Issuer .</return>
        ///<param name="IssuerId"> A string that represents the identifier of the requested Issuer .</param>
        ///<param name="ConnectedUserId">A string </param>
        public Issuer GetIssuerById(string IssuerId, string ConnectedUserId)
        {
           var request=new RestRequest("/issue/get-issuer/{currentUserId}/{issuerId}",Method.GET);
           request.AddUrlSegment("currentUserId",ConnectedUserId);
           request.AddParameter("issuerId",IssuerId,ParameterType.UrlSegment);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
            var values = JsonConvert.DeserializeObject<Issuer>(response.Content);
            return values;
            }
            else{
                return new Issuer(response.Content);
            }      
        }

        ///<summary> Add a new issuer to the network .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="issuer">An instance of class Issuer </param>
        public string AddIssuer(Issuer issuer)
        {
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Id", issuer.Id);
            jObjectbody.Add("currency", issuer.Currency);
            jObjectbody.Add("type", issuer.Type);
            jObjectbody.Add("currentUserId", "admin");
            RestRequest restRequest = new RestRequest("issue/add-issuer", Method.POST);
            restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
            IRestResponse restResponse = client.Execute(restRequest);
            if(restResponse.StatusCode==HttpStatusCode.Created){
                return "";
            }    
            else return restResponse.Content;   
        }

        ///<summary>
        /// Transfer money from the issuer to a simple user of a network
        ///</summary>
        ///<returns>
        /// A message of success or error description
        ///</returns>
        ///<param name="RootOwnerId">A string .</param>
        ///<param name="RecieverId"> A string .</param>
        ///<param name="IssuerBillfoldId"> A string .</param>
        ///<param name="Amount"> A float .</param>
        public string LoadBalance(string RootOwnerId, string RecieverId, string IssuerBillfoldId, float Amount)
        {
            JObject jObjectbody = new JObject();
            jObjectbody.Add("issuer",RootOwnerId);
            jObjectbody.Add("userId", RecieverId);
            jObjectbody.Add("billfoldIssuer", IssuerBillfoldId);
            jObjectbody.Add("amount", Amount);
            RestRequest restRequest = new RestRequest("issue/load-balance", Method.PUT);
            restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
            IRestResponse restResponse = client.Execute(restRequest); 
            if(restResponse.StatusCode==HttpStatusCode.NoContent){
                return "";
            }    
            else return restResponse.Content;    
        }
    }
}