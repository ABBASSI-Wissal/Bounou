namespace BridgeLibrary.Identity
{
    ///<summary>
    ///The class <c>Credentials</c>
    ///represents  the credentilas of X509 CA Identity
    ///</summary>
   
    public class Credentials
    {
        ///<value>A signed certificate related to a participant . </value>
        public string certificate { get; set; }
        ///<value> A private key used to produce a digital signature </value>
        public string privateKey { get; set; }
        
        ///<summary>
        /// A constructor 
        ///</summary>
        public Credentials(string Certificate,string PrivateKey)
         {
             this.certificate = Certificate;
             this.privateKey = PrivateKey;
         }

    }
}