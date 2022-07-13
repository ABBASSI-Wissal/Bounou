namespace BridgeLibrary.Entities
{
    ///<summary>
    ///The class <c>Issuer</c>
    ///represents a registred issuer in the network , used to call restfull requests.
    ///</summary>
    ///<remarks>
    ///this class has three different constructors.
    ///</remarks>
    public class Issuer{
  
        ///<value> An issuer identifier .</value>
        public string Id { get; set; }

        ///<value> The type of money .
        ///cash,points,etc... .</value>
        public string Type { get; set; }

        ///<value> The currency of the money .</value>
        public string Currency { get; set; }

        ///<value> The amount of money that exists in an network .</value>
        public float Balance { get; set; }

        ///<value> In case the request returned an error .</value>
        public string Error { get; set; }

        ///<summary> 
        /// A constructor that set the initial value for the field Error .
        ///</summary>
        public Issuer()
        {
            this.Error="";
        }
        
        ///<summary>
        /// A constructor that set a value for the field Error .
        ///</summary>
        ///<param name="Error"> A string </param>
        public Issuer(string Error)
        {
            this.Error=Error;
        }
        
        ///<summary>
        /// A constructor with multiple parameters .
        ///</summary>
        ///<param name="Id"> A string </param>
        ///<param name="Currency"> A string </param>
        ///<param name="Type"> A string </param>
        ///<param name="Balance"> A float </param>
        public Issuer(string Id, string Type,string Currency,float Balance)
        {
            this.Id=Id;
            this.Type=Type;
            this.Currency=Currency;
            this.Balance=Balance;
        }
    }
}