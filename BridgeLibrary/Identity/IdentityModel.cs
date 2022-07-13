
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
namespace BridgeLibrary.Identity
{
    ///<summary>
    ///The class <c>IdentityModel</c>
    ///Represents The identity document stored in a mongodb collection .
    ///contains all the methods that performs interactions with the database.
    ///</summary>
    ///<remarks>
    ///this class can get, add an identity to the database
    ///</remarks>
    public class IdentityModel
    {
        ///<value>  the participant Id
        ///Is required for mapping the Common Language Runtime (CLR) object to the MongoDB collection.
        ///</value>
        public string Id { get; set; }
        ///<value> An instance of the Class Credentials .</value>
        public Credentials Credentials { get; set; }
        
        ///<value> The MSP ID of the organization that a participant belongs to. </value>
        public string mspId { get; set; }
        ///<value> The Type of the Identity Certificate .</value>
        public string Type { get; set; }
        ///<value> The connection string to connect to the mongo database.</value>
        string connString = "mongodb://127.0.0.1:27017";
       
        ///<summary>
        /// Create an identity 
        ///</summary>
        ///<returns>
        /// An object of type IdentityModel
        ///</returns>
        ///<param name="Id">A string .</param>
        ///<param name="msp">A string .</param>
        ///<param name="type">A string .</param>
        ///<param name="certificate">A string .</param>
        ///<param name="private_key">A string .</param>
        public IdentityModel CreateIdentity(string Id,string msp,string type,string certificate,string private_key){
            IdentityModel identity=new IdentityModel(){
                Id = Id,
                mspId = msp,
                Type = type,
                Credentials = new Credentials(certificate,private_key)
            };
            return identity;
        }
        ///<summary>
        /// Add an identity to the database.
        ///</summary>
        ///<param name="id">A string .</param>
        ///<param name="mspId">A string .</param>
        ///<param name="Type">A string .</param>
        ///<param name="Certificate">A string .</param>
        ///<param name="PrivateKey">A string .</param>

        public void AddIdentity(string id,string mspId,string Type,string Certificate,string PrivateKey){
             try
                {
                    IMongoClient _client = new MongoClient(connString);
                    IMongoDatabase _database = _client.GetDatabase("Identity");
                    var _collections=_database.GetCollection<IdentityModel>("Certificate");
                    IdentityModel identity=new IdentityModel();
                    _collections.InsertOne(identity.CreateIdentity(id,mspId,Type,Certificate,PrivateKey));

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
        }
        ///<summary>
        /// Delete an identity from the database.
        ///</summary>
        ///<param name="id">A string .</param>
       public void DeleteIdentity(string id){
            try
            {
                IMongoClient _client = new MongoClient(connString);
                IMongoDatabase _database = _client.GetDatabase("Identity");
                var _collections=_database.GetCollection<IdentityModel>("Certificate");   
                var filter =Builders<IdentityModel>.Filter.Eq(user => user.Id, id);
                _collections.DeleteOne(filter);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
           
        }
        ///<summary>
        /// Get an identity from the database.
        ///</summary>
        ///<return> An object of type IdentityModel .</return>
        ///<param name="id">A string .</param>
        public IdentityModel GetIdentity(string id){
            IMongoClient _client = new MongoClient(connString);
            IMongoDatabase _database = _client.GetDatabase("Identity");
            var _collections=_database.GetCollection<IdentityModel>("Certificate");
            var filter =Builders<IdentityModel>.Filter.Eq(user => user.Id, id);

            var identity=_collections.Find(filter).FirstOrDefault();
            return identity;

        }
        // ,decrypt
 }
}