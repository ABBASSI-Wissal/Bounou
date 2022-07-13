using System;
using BridgeLibrary;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json.Linq;
using BridgeLibrary.Entities;
using BridgeLibrary.Entities.Repositories;

namespace test
{
  class Program
  {
        static void Main(string[] args)
        {
          IUserRepository<User> userRepository=new UserRepository();
          IBillfoldRepository<BillFold> billfoldRepository=new BillfoldRepository();
          IIssuerRepository<Issuer> issuerRepository=new IssuerRepository();
         
         
        //Console.WriteLine("---------------------------------------");
        //Console.Write("\n");
        //Console.WriteLine("******** update user : user_002 :esra : ismail ********");
        //string up=userRepository.UpdateUser(new User("user_007","oula","hassine","customer"));
        // if(up=="error"){
        //  Console.WriteLine(up);
        //}else{
        //  Console.WriteLine("transaction submitted");
        //}
     Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add issuer ********");
       Console.WriteLine("\"issuer_001\",\"TND\",\"cash\"");
       string result2=issuerRepository.AddIssuer(new Issuer("issuer_001","cash","TND",0));
        if(result2!=""){
          Console.WriteLine(result2);
        }else{
          Console.WriteLine("transaction submitted");
        }

        Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add issuer ********");
       Console.WriteLine("\"issuer_002\",\"EU\",\"card\"");
        string result4=issuerRepository.AddIssuer(new Issuer("issuer_002","cash","EU",0));
        if(result4!=""){
          Console.WriteLine(result4);
        }else{
          Console.WriteLine("transaction submitted");
        }

        Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add issuer ********");
       Console.WriteLine("\"issuer_003\",\"YEN\",\"cash\"");
        string result5=issuerRepository.AddIssuer(new Issuer("issuer_003","cash","YEN",0));
        if(result5!=""){
          Console.WriteLine(result5);
        }else{
          Console.WriteLine("transaction submitted");
        }
         Console.WriteLine("---------------------------------------");

         Console.WriteLine("******** add user ********");
        Console.WriteLine("\"user_001\",\"khaoula\",\"ismail\",\"merchand\"");
        string result=userRepository.AddUser(new User("user_001","khaoula","ismail","merchand"));
        if(result!=""){
          Console.WriteLine(result);
        }else{
          Console.WriteLine("transaction submitted");
        }
       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get user ID : user_001********");
        User user=userRepository.GetUserById("user_001");
        if(user.Error==""){
          Console.Write(user.UserId +" | ");
          Console.Write(user.FirstName +" | ");
          Console.Write(user.LastName +" | ");
          Console.WriteLine(user.Type);
        }
        else {Console.WriteLine(user.Error);}
        Console.WriteLine("---------------------------------------");
        Console.Write("\n");
        Console.WriteLine("******** add user ********");
        Console.WriteLine("\"user_002\",\"esra\",\"ismail\",\"customer\"");
        string result1=userRepository.AddUser(new User("user_002","esra","ismail","customer"));
        if(result1!=""){
          Console.WriteLine(result1);
        }else{
          Console.WriteLine("transaction submitted");
        }
       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       //test mel awl fi base mongodb si identity mawjouda ou nn sinn bch ye3ml error
       Console.WriteLine("******** get user ID : user_007 ********");
       User user1=userRepository.GetUserById("user_007");
       if(user1.Error==""){
         
        }
      else {Console.WriteLine(user1.Error);}

      Console.WriteLine("---------------------------------------");
        Console.Write("\n");
        Console.WriteLine("******** add user ********");
        Console.WriteLine("\"user_003\",\"wissal\",\"abbassi\",\"customer\"");
        string result3=userRepository.AddUser(new User("user_003","wissal","abbassi","customer"));
        if(result3!=""){
          Console.WriteLine(result3);
        }else{
          Console.WriteLine("transaction submitted");
        }

       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add billfold ********");
       Console.WriteLine("\"bill_002\",\"TND\",\"cash\",0,\"user_002\"");
       string bill=billfoldRepository.AddBillfold(new BillFold("bill_002","TND","cash",0,"user_002"));
       if(bill!=""){
          Console.WriteLine(bill);
        }else{
          Console.WriteLine("transaction submitted");
        }
        Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get billfold ID : bill_002 ********");
        BillFold billfold=billfoldRepository.GetBillfoldById("bill_002","user_002");
        if(billfold.Error==""){
          Console.Write(billfold.Id+" | ");
          Console.Write(billfold.Currency+" | ");
          
          Console.WriteLine(billfold.Amount+" | ");
         
        }
        else Console.WriteLine(billfold.Error);

       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add billfold ********");
       Console.WriteLine("\"bill_003\",\"TND\",\"cash\",0,\"user_003\"");
      string bill1=billfoldRepository.AddBillfold(new BillFold("bill_003","TND","cash",0,"user_003"));
         if(bill1!=""){
          Console.WriteLine(bill1);
        }else{
          Console.WriteLine("transaction submitted");
        }
        Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add billfold ********");
       Console.WriteLine("\"bill_004\",\"TND\",\"card\",0,\"user_002\"");
      string bill2=billfoldRepository.AddBillfold(new BillFold("bill_004","EU","card",0,"user_002"));
         if(bill2!=""){
          Console.WriteLine(bill2);
        }else{
          Console.WriteLine("transaction submitted");
        }
        Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** add billfold ********");
       Console.WriteLine("\"bill_005\",\"EU\",\"card\",0,\"user_003\"");
      string bill3=billfoldRepository.AddBillfold(new BillFold("bill_005","EU","card",0,"user_003"));
         if(bill3!=""){
          Console.WriteLine(bill3);
        }else{
          Console.WriteLine("transaction submitted");
        }

        Console.WriteLine("---------------------------------------");
        Console.Write("\n");
        Console.WriteLine("******** update user : user_002 :esra : ismail ********");
        string up=userRepository.UpdateUser(new User("user_002","oula","hassine","customer"));
         if(up!=""){
          Console.WriteLine(up);
        }else{
          Console.WriteLine("transaction submitted");
        }
        
       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get user after update ********");
       User user3=userRepository.GetUserById("user_002");
        if(user.Error==""){
          Console.Write(user.UserId +" | ");
          Console.Write(user.FirstName +" | ");
          Console.Write(user.LastName +" | ");
          Console.WriteLine(user.Type);
        }
        else {Console.WriteLine(user.Error);}
        Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** load 200 TND to user_002 from issuer issuer_001 ********");
       string load1=issuerRepository.LoadBalance("admin","user_002","issuer_001",200);
        if(load1!=""){
          Console.WriteLine(load1);
        }else{
          Console.WriteLine("transaction submitted");
        }

      Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get balance ********"); 
      Issuer first_issueing=issuerRepository.GetIssuerById("issuer_001","admin");
              if(first_issueing.Error==""){
                Console.Write(first_issueing.Id+" | ");
                Console.Write(first_issueing.Currency+" | ");
                Console.WriteLine(first_issueing.Balance+" | ");

              }
              else Console.WriteLine(first_issueing.Error);
      Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** load 400 TND to user_003 from issuer issuer_001********");
       string load2=issuerRepository.LoadBalance("admin","user_003","issuer_001",400);
        if(load1!=""){
          Console.WriteLine(load2);
        }else{
          Console.WriteLine("transaction submitted");
        }
       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get balance ********");
           Issuer issuer=issuerRepository.GetIssuerById("issuer_001","admin");
              if(issuer.Error==""){
                Console.Write(issuer.Id+" | ");
                Console.Write(issuer.Currency+" | ");
                Console.WriteLine(issuer.Balance+" | ");

              }
              else Console.WriteLine(issuer.Error);

       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get all issuers********");
      List<Issuer> bal = issuerRepository.GetListOfAllIssuers("admin");
      if(bal[0].Error==""){
          foreach (var item in bal)
          {
              Console.Write(item.Id+" | ");
              Console.Write(item.Currency+" | ");
              Console.WriteLine(item.Balance+" | ");             
          }}
      else{
           Console.WriteLine(bal[0].Error);
      }
      Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get all users ********");
      List<User> json = userRepository.GetListOfAllUsers("admin");
      if(json[0].Error==""){
           foreach (var item in json)
           {
              Console.Write(item.UserId+" | ");
              Console.Write(item.FirstName+" | ");
              Console.Write(item.LastName+" | ");
              Console.WriteLine(item.Type+" | ");        
           }
      }
      else{
        Console.WriteLine(json[0].Error);
      }
       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get billfolds by owner ********");
      List<BillFold> bill4 = billfoldRepository.GetListOfBillfoldsByOwner("user_002");
      if(bill4[0].Error==""){
          foreach (var item in bill4)
          {
              Console.Write(item.Id+" | ");
              Console.Write(item.Currency+" | ");
              Console.WriteLine(item.Amount+" | ");            
          }
        }
       else{
         Console.WriteLine(bill4[0].Error);
       }
       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** PAY :send 100 from user_002 to user_003 ********");
        string pay=billfoldRepository.TransferMoney("bill_002","user_003",100,"user_002");
        if(pay!=""){
          Console.WriteLine(pay);
        }else{
          Console.WriteLine("transaction submitted");
        }

       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get billfold ID : bill_002 ********");
        BillFold billfold2=billfoldRepository.GetBillfoldById("bill_002","user_002");
        if(billfold2.Error==""){
          Console.Write(billfold2.Id+" | ");
          Console.Write(billfold2.Currency+" | ");
          Console.WriteLine(billfold2.Amount+" | "); 
        }
        else Console.WriteLine(billfold2.Error);

       Console.WriteLine("---------------------------------------");
       Console.Write("\n");
       Console.WriteLine("******** get billfold ID : bill_003 ********");
        BillFold billfold1=billfoldRepository.GetBillfoldById("bill_003","user_003");
        if(billfold1.Error==""){
          Console.Write(billfold1.Id+" | ");
          Console.Write(billfold1.Currency+" | ");
          Console.WriteLine(billfold1.Amount+" | "); 
        }
        else Console.WriteLine(billfold1.Error);
        
        /*   RestSharp.RestResponse response = new RestSharp.RestResponse();

           response.Content = json;

           JsonDeserializer deserial = new JsonDeserializer();

           var x = deserial.Deserialize<Dictionary<string,string>>(response);
           Console.WriteLine(x["FirstName"]);
            var client = new RestClient("http://localhost:3000/");
            var request=new RestRequest("user/query/{index}",Method.GET);
            request.AddUrlSegment("index","user_001");
            var response = client.Execute(request).Content;
            
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
           // Console.WriteLine(values.Count);
            // 2

            Console.WriteLine(values["FirstName"]);
            // value1*/

            
          //   User user=new User("user_001","khaoula","ismail");
            //Class1.AddUser(user.Id,user.FirstName,user.LastName);
            //Class1.AddBillfold("bill_002","TND","cash",1000,"user_001");
           // Class1.Refund("bill_002",100,"user_001");
          //  Console.WriteLine("Hello World!");
            //type te3 user y7eded anahi org yentamilha customer wela merchant**
            //ne3ml fct tgeti el user w te3tini type el compte mte3a bch ne3rf b anahai org ne5dem **
            //policies :only user can modify his info ,user exist or not ,find user n7awl ne3mlhom fi bridge 
            
            //push the code in github
           
         
           //disconnect fi identity
        }
    }
}
