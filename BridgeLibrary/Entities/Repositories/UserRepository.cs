using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BridgeLibrary.Identity;
namespace BridgeLibrary.Entities.Repositories
{
    ///<summary>
    ///The class <c>UserRepository</c>
    ///Implements the interface <c>IBounouBridge</c>
    ///this class can list,get, add, update, delete a user.
    ///</summary>
    public class UserRepository : IUserRepository<User>
    {
        ///<value> A RestClient instance that sets the Base Url for all requests.</value>
        RestClient client = new RestClient("http://localhost:3000/");

        ///<summary> Get all the users of the network . </summary>
        ///<return> List of type User </return>
        ///<param name="ConnectedUserId">A string that represents the current user ID</param>
        public List<User> GetListOfAllUsers(string ConnectedUserId)
        {
           var request=new RestRequest("user/get-all-users/{currentUserId}",Method.GET);
           List<User> values=new List<User>() ;
           request.AddUrlSegment("currentUserId",ConnectedUserId);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
                values = JsonConvert.DeserializeObject<List<User>>(response.Content);
            }
            else{
                values.Add(new User(response.Content));    
            }
            return values;   
        }

        ///<summary>Get a user by ID .</summary>
        ///<return>An object of type User .</return>
        ///<param name="UserId"> A string that represents the identifier of the user .</param>
        public User GetUserById(string UserId)
        {
           var request=new RestRequest("user/get-user/{userId}",Method.GET);
           request.AddUrlSegment("userId",UserId);
           var response = client.Execute(request);
           if(response.ContentType.Contains("application/json") && response.StatusCode==HttpStatusCode.OK){
                var values = JsonConvert.DeserializeObject<User>(response.Content);
                return values;
            }
            else{
               return new User(response.Content);
            }       
        }
        ///<summary> Add a new user to the database .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="user">An Object of type User </param>
        public string AddUser(User user)
        {
            IdentityModel identity=new IdentityModel();
            if(identity.GetIdentity(user.UserId)==null){
                JObject jObjectbody = new JObject();
                jObjectbody.Add("userId", user.UserId);
                jObjectbody.Add("first_name", user.FirstName);
                jObjectbody.Add("last_name", user.LastName);
                jObjectbody.Add("userType", user.Type);
                RestRequest restRequest = new RestRequest("user/add-user", Method.POST);
                restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
                IRestResponse restResponse = client.Execute(restRequest); 
                if(restResponse.StatusCode==HttpStatusCode.Created){
                    var values = JsonConvert.DeserializeObject<IdentityModel>(restResponse.Content);
                    try
                    { 
                        identity.AddIdentity(user.UserId,values.mspId,values.Type,values.Credentials.certificate,values.Credentials.privateKey);
                    }
                    catch (System.Exception ex)
                    {
                        return "Error:" + ex.Message;
                    }
                    return "Transaction submitted";
                }    
                else return restResponse.Content;  
            }
            else{
                return "This identity is alreday exists";
            }
        }

        ///<summary> Update a user that already exists in the database.</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="user">An object of type User </param>
        public string UpdateUser(User user)
        {
           JObject jObjectbody = new JObject();
           jObjectbody.Add("userId", user.UserId);
           jObjectbody.Add("first_name", user.FirstName);
           jObjectbody.Add("last_name", user.LastName);
           jObjectbody.Add("userType", user.Type);
           RestRequest restRequest = new RestRequest("user/update-user", Method.PUT);
           restRequest.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
           IRestResponse restResponse ;
           try
           {
                restResponse = client.Execute(restRequest); 
                return "";
           }
           catch (Entities.CustomError)
           { 
             Console.WriteLine("errrooorrr");
             return "error"; 
           }
         //  IRestResponse restResponse = client.Execute(restRequest); 
        /*   if(restResponse.StatusCode==HttpStatusCode.NoContent){
                return "";
            }    
            else return restResponse.Content;  */ 
        }

        ///<summary> Delete a user that already exists in the database.</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="UserId"> A string that represent the user ID.</param>
        ///<param name="ConnectedUserId"> A string that represents the current user ID. </param>
        public string DeleteUser(string UserId, string ConnectedUserId)
        {
            RestRequest request = new RestRequest("user/delete-user",Method.DELETE);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Id", UserId);
            jObjectbody.Add("connectedUser",ConnectedUserId);
            request.AddParameter("application/json",jObjectbody,ParameterType.RequestBody); 
            IRestResponse response=client.Execute(request);
            if(response.StatusCode==HttpStatusCode.NoContent){
                IdentityModel identity=new IdentityModel();
                identity.DeleteIdentity(UserId);
                return "";
            }    
            else return response.Content;
        }
    }
}