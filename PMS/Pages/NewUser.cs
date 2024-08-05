using Amazon.DynamoDBv2.DataModel;

namespace NewUser
{
     [DynamoDBTable("Users")]

         public class Users
         {
         [DynamoDBHashKey]
         public int UserID { get; set;}

          [DynamoDBRangeKey]
          public string UserName { get; set;}
        
         [DynamoDBProperty]
          public string Password {get; set;}

    }
}