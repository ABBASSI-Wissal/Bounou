namespace BridgeLibrary.Entities
{
    ///<summary>
    ///The class <c>User</c>
    ///represents a registred user in the network , used to call restfull requests.
    ///</summary>
    ///<remarks>
    ///this class has three different constructors
    ///</remarks>
    public class User
    {
        ///<value> The same user identifier for the X509 Identity .</value>
        public string UserId { get; set; }

        ///<value> The first name of the user .</value>
        public string FirstName { get; set; }

        ///<value> The family name of the user .</value>
        public string LastName { get; set; }

        ///<value> The type of user either merchand or customer .
        ///Identify what oganization he blongs to .
        ///</value>
        public string Type { get; set; }

        ///<value> In case the request returned an error .</value>
        public string Error { get; set; }
        
        ///<summary> 
        /// A constructor that set the initial value for the field Error .
        ///</summary>
        public User()
        {
            this.Error="";
        }

        ///<summary>
        /// A constructor that set a value for the field Error .
        ///</summary>
        ///<param name="Error"> A string </param>
        public User(string Error)
        {
            this.Error=Error;
        }

        ///<summary>
        /// A constructor with multiple parameters .
        ///</summary>
        ///<param name="UserId"> A string </param>
        ///<param name="FirstName"> A string </param>
        ///<param name="LastName"> A string </param>
        ///<param name="Type"> A string </param>
        public User(string UserId,string FirstName,string LastName,string Type)
        {
            this.UserId=UserId;
            this.FirstName=FirstName;
            this.LastName=LastName;
            this.Type=Type;
        }
    }
}