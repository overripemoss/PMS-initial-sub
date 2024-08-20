using Amazon.DynamoDBv2.DataModel;

namespace Database
{
    //creates user object for pushing to database
     [DynamoDBTable("Users")]

         public class Users
         {
         [DynamoDBHashKey]
         public int UserID { get; set;
         }

          [DynamoDBRangeKey]
          public string UserName { get; set;
          }
        
         [DynamoDBProperty]
          public string Password { get; set;
          }

    }
}