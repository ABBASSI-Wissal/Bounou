namespace BridgeLibrary.Entities
{
    ///<summary>
    ///The class <c>BillFold</c>
    ///represents the user wallet , used to call restfull requests.
    ///</summary>
    ///<remarks>
    ///this class has three different constructors
    ///</remarks>
    public class BillFold
    {
        ///<value> A billfold identifier </value>
        public string Id { get; set; }

        ///<value> The currency of the money stored in the billfold .</value>
        public string Currency { get; set; }

        ///<value> The type of money .
        ///cash,points,etc... .</value>
        public string Type { get; set; }

        ///<value> The amount of money that a user has in his billfold .</value>
        public float Amount { get; set; }

        ///<value> The owner of the billfold .</value>
        public string Owner { get; set; }

         ///<value> In case the request returned an error .</value>
        public string Error { get; set; }

        ///<summary> 
        /// A constructor that set the initial value for the field Error .
        ///</summary>
        public BillFold()
        {
            Error="";
        }

        ///<summary>
        /// A constructor that set a value for the field Error .
        ///</summary>
        ///<param name="Error"> A string </param>
        public BillFold(string Error)
        {
            this.Error=Error;
        }

        ///<summary>
        /// A constructor with multiple parameters .
        ///</summary>
        ///<param name="Id"> A string </param>
        ///<param name="Currency"> A string </param>
        ///<param name="Type"> A string </param>
        ///<param name="Amount"> A float </param>
        ///<param name="Owner"> A string </param>
        public BillFold(string Id,string Currency,string Type,float Amount,string Owner)
        {
            this.Id=Id;
            this.Currency=Currency;
            this.Type=Type;
            this.Amount=Amount;
            this.Owner=Owner;
        }
    }
}