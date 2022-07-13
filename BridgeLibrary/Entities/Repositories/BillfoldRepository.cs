
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BridgeLibrary.Entities.Repositories
{
    ///<summary>
    ///The class <c>BillfoldRepository</c>
    ///Implements the interface <c>IBounouBridge</c>
    ///this class can list,get, add, update, delete a billfold.
    ///</summary>
    public class BillfoldRepository : IBillfoldRepository<BillFold>
    {
        ///<value> A RestClient instance that sets the Base Url for all requests.</value>
        RestClient client = new RestClient("http://localhost:3000/");
   
        ///<summary> Get a list of billfolds by owner . </summary>
        ///<return> List of billfolds</return>
        ///<param name="OwnerId">A string </param>
        public List<BillFold> GetListOfBillfoldsByOwner(string OwnerId)
        {
           List<BillFold> values=new List<BillFold>();
           var request=new RestRequest("/billfold/query-billfolds-by-owner/{ownerId}",Method.GET);
           request.AddUrlSegment("ownerId",OwnerId);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
                values = JsonConvert.DeserializeObject<List<BillFold>>(response.Content);
            }
            else{
                values.Add(new BillFold(response.Content));
            } 
            return values; 
        }

        ///<summary> Get a list of billfolds by currency . </summary>
        ///<return> List of billfolds</return>
        ///<param name="ConnectedUserId">A string </param>
        ///<param name="Currency">A string </param>
        public List<BillFold> GetListOfBillfoldsByCurrency(string ConnectedUserId, string Currency)
        {
           List<BillFold> values=new List<BillFold>();
           var request=new RestRequest("/billfold/query-billfolds-by-currency/{currency}/{currentUserId}",Method.GET);
           request.AddUrlSegment("currency",Currency);
           request.AddParameter("currentUserId",ConnectedUserId,ParameterType.UrlSegment);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
                values = JsonConvert.DeserializeObject<List<BillFold>>(response.Content);
            }
            else{
                 values.Add(new BillFold(response.Content));
            }  
            return values;        
        }

        ///<summary> Get a list of billfolds by currency . </summary>
        ///<return> List of billfolds</return>
        ///<param name="ConnectedUserId">A string </param>
        ///<param name="Type">A string </param>
        public List<BillFold> GetListOfBillfoldsByType(string ConnectedUserId, string Type)
        {
           List<BillFold> values=new List<BillFold>();
           var request=new RestRequest("/billfold/query-billfolds-by-type/{type}/{currentUserId}",Method.GET);
           request.AddUrlSegment("type",Type);
           request.AddParameter("currentUserId",ConnectedUserId,ParameterType.UrlSegment);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
                values = JsonConvert.DeserializeObject<List<BillFold>>(response.Content);
            }
           else{
                values.Add(new BillFold(response.Content));
            }  
            return values;
        }

        ///<summary>Get a billfold by ID .</summary>
        ///<return>An object of type BillFold .</return>
        ///<param name="BillfoldId"> A string that represents the identifier of the billfold .</param>
        ///<param name="ConnectedUserId"> A string that represents the identity of the current user .</param>
        public BillFold GetBillfoldById(string BillfoldId, string ConnectedUserId)
        {
           var request=new RestRequest("billfold/get-billfold/{billfoldId}/{currentUserId}",Method.GET);
           request.AddUrlSegment("billfoldId",BillfoldId);
           request.AddParameter("currentUserId",ConnectedUserId,ParameterType.UrlSegment);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){  
                var values = JsonConvert.DeserializeObject<BillFold>(response.Content);
                return values;
            }
            else{
                return new BillFold(response.Content);
            }
        }
        ///<summary> Add a billfold to the database .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="billfold">A BillFold instance </param>
        public string AddBillfold(BillFold billfold)
        {
            JObject jObjectbody = new JObject();
            jObjectbody.Add("BillfoldId", billfold.Id);
            jObjectbody.Add("currency", billfold.Currency);
            jObjectbody.Add("type", billfold.Type);
            jObjectbody.Add("amount", billfold.Amount);
            jObjectbody.Add("userId", billfold.Owner);
            RestRequest restRequest = new RestRequest("billfold/add-billfold", Method.POST);
            restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
            IRestResponse restResponse = client.Execute(restRequest);
            if(restResponse.StatusCode==HttpStatusCode.Created){
                return "";
            }    
            else return restResponse.Content;
        }

        ///<summary> Transfer money from user to another user .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="SenderBillfoldId">A string .</param>
        ///<param name="RecieverId">A string .</param>
        ///<param name="Amount">A float .</param>
        ///<param name="ConnectedUserId">A string .</param>
        public string TransferMoney(string SenderBillfoldId, string RecieverId, float Amount, string ConnectedUserId)
        {
            JObject jObjectbody = new JObject();
            jObjectbody.Add("owner",ConnectedUserId);
            jObjectbody.Add("billfoldId", SenderBillfoldId);
            jObjectbody.Add("newOwner", RecieverId);
            jObjectbody.Add("amountToTransfer", Amount);
            RestRequest restRequest = new RestRequest("billfold/pay", Method.PUT);
            restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
            IRestResponse restResponse = client.Execute(restRequest); 
            if(restResponse.StatusCode==HttpStatusCode.NoContent){
                return "";
            }    
            else return restResponse.Content;    
        }

        ///<summary> Delete a billfold that already exists in the database. </summary>
        ///<return> A string that represents a message of success or error. </return>
        ///<param name="BillfoldId"> A string that represent the billfold ID.</param>
        ///<param name="ConnectedUserId"> A string that represents the current user ID. </param>
        public string DeleteBillfold(string BillfoldId, string ConnectedUserId)
        {
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Id", BillfoldId);
            jObjectbody.Add("connectedUser",ConnectedUserId);
            RestRequest request = new RestRequest("billfold/delete-billfold",Method.DELETE);
            request.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
            IRestResponse response=client.Execute(request); 
            if(response.StatusCode==HttpStatusCode.NoContent){
                return "";
            }    
            else return response.Content;
        }
    }
}
/*public string Refund(string billfoldId, float amount,string currentUser){
                RestClient client = new RestClient("http://localhost:3000/");
                JObject jObjectbody = new JObject();
                jObjectbody.Add("owner",currentUser);
                jObjectbody.Add("id", billfoldId);
                jObjectbody.Add("fund", amount);
                RestRequest restRequest = new RestRequest("billfold/refund", Method.PUT);
                restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
                IRestResponse restResponse = client.Execute(restRequest); 
                if(restResponse.StatusCode==HttpStatusCode.NoContent){
                    return "";
                }    
                else return restResponse.Content; 
            }*/