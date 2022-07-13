using System.Collections.Generic;

namespace BridgeLibrary.Entities.Repositories{

    ///<summary>
    /// The inetrface <c>IUserRepository</c> should be implemented by all ressources.
    /// Implementing this inertface is necessary for promoting Dependecy Injection Pattern (DIP).
    ///</summary>
    public interface IUserRepository<User>{
        
        ///<summary> Get a list of users . </summary>
        ///<return> List </return>
        ///<param name="ConnectedUserId">A string </param>
        List<User> GetListOfAllUsers(string ConnectedUserId);
        
        ///<summary>Get a user by ID .</summary>
        ///<return>An object of type User .</return>
        ///<param name="UserId"> A string that represents the identifier of the requested user .</param>
        User GetUserById(string UserId);

        ///<summary> Add a new user to the network .</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="user">An instance of class User </param>
        string AddUser(User user);

        ///<summary> Update a user that already exists in the database.</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="user">An instance of class User </param>
        string UpdateUser(User user);

        ///<summary> Delete a user that already exists in the database.</summary>
        ///<return> A string that represents a message of success or error .</return>
        ///<param name="UserId"> A string that represent the object ID.</param>
        ///<param name="ConnectedUserId"> A string that represents the current user ID. </param>
        string DeleteUser(string UserId,string ConnectedUserId);
    }
}