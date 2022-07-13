using System.Collections.Generic;

namespace BridgeLibrary.Entities.Repositories{

    ///<summary>
    /// The inetrface <c>IIssuerRepository</c> should be implemented by all ressources.
    /// Implementing this inertface is necessary for promoting Dependecy Injection Pattern (DIP).
    ///</summary>
    public interface IIssuerRepository<Issuer>
    {
        ///<summary> Get a list of issuers . </summary>
        ///<return> List </return>
        ///<param name="ConnectedUserId">A string </param>
        List<Issuer> GetListOfAllIssuers(string ConnectedUserId);
         
        ///<summary>Get an issuer by ID .</summary>
        ///<return>An object of type Issuer .</return>
        ///<param name="IssuerId"> A string that represents the identifier of the requested Issuer .</param>
        ///<param name="ConnectedUserId">A string </param>
        Issuer GetIssuerById(string IssuerId,string ConnectedUserId);

        ///<summary> Add a new issuer to the network .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="issuer">An instance of class Issuer </param>
        string AddIssuer(Issuer issuer);

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
        string LoadBalance(string RootOwnerId,string RecieverId,string IssuerBillfoldId, float Amount);
    }
}