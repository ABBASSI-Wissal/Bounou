using System.Collections.Generic;

namespace BridgeLibrary.Entities.Repositories{
    
    ///<summary>
    /// The inetrface <c>IBillfoldRepository</c> should be implemented by all ressources.
    /// Implementing this inertface is necessary for promoting Dependecy Injection Pattern (DIP).
    ///</summary>
    public interface IBillfoldRepository<BillFold>
    {
        
        ///<summary> Get a list of billfolds by owner . </summary>
        ///<return> List of billfolds</return>
        ///<param name="OwnerId">A string </param>
        List<BillFold> GetListOfBillfoldsByOwner(string OwnerId);
        
        ///<summary> Get a list of billfolds by currency . </summary>
        ///<return> List of billfolds</return>
        ///<param name="ConnectedUserId">A string </param>
        ///<param name="Currency">A string </param>
        List<BillFold> GetListOfBillfoldsByCurrency(string ConnectedUserId,string Currency);

        ///<summary> Get a list of billfolds by currency . </summary>
        ///<return> List of billfolds</return>
        ///<param name="ConnectedUserId">A string </param>
        ///<param name="Type">A string </param>
        List<BillFold> GetListOfBillfoldsByType(string ConnectedUserId,string Type);

        ///<summary>Get a billfold by ID .</summary>
        ///<return>An object of type BillFold .</return>
        ///<param name="BillfoldId"> A string that represents the identifier of the billfold .</param>
        ///<param name="ConnectedUserId"> A string that represents the identity of the current user .</param>
        BillFold GetBillfoldById(string BillfoldId,string ConnectedUserId);

        ///<summary> Add an element to the database .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="billfold">An instance of class BillFold</param>
        string AddBillfold(BillFold billfold);

        ///<summary> Transfer money from user to another user .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="SenderBillfoldId">A string .</param>
        ///<param name="RecieverId">A string .</param>
        ///<param name="Amount">A float .</param>
        ///<param name="ConnectedUserId">A string .</param>
        string TransferMoney(string SenderBillfoldId ,string RecieverId,float Amount,string ConnectedUserId);

        ///<summary> Delete an element that already exists in the database.</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="BillfoldId"> A string that represent the object ID.</param>
        ///<param name="ConnectedUserId"> A string that represents the current user ID. </param>
        string DeleteBillfold(string BillfoldId,string ConnectedUserId);
    }
}