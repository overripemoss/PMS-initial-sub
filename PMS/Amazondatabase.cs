using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualBasic;
using PMS.Pages;
using System.Collections.Generic;
using System.Configuration;

namespace Database
{
    public class dataBase
	{
        //instantiates and calls database in amazon cloud
        public readonly DynamoDBContext dbContext;
        public List<Product> store = new List<Product>();
        public List<Users> user = new List<Users>();
         public dataBase() {
         AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                   //define database keys
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials("AKIAZI2LFC6O3QHYMC4Q", "xIaixheupYlbExYzcN3JkVxoXDAmOSiqTwkbbHxC");
        // This client will access a cloud database
        AmazonDynamoDBClient client = new AmazonDynamoDBClient(awsCredentials, RegionEndpoint.APSoutheast2); 
        dbContext = new DynamoDBContext(client, new DynamoDBContextConfig{
            ConsistentRead = true,
            SkipVersionCheck = true
        });
        }
        //save function for products and user to database
        public void SaveItem<T>(T model)
        {
            dbContext.SaveAsync(model);
        }
        //pulls product list from database
        public void GetItem()
        {
            List<ScanCondition> scanConditions = new List<ScanCondition>() { };
            store = dbContext.ScanAsync<Product>(scanConditions).GetRemainingAsync().Result;
            
        }
        //deltes item from database
        public void DeleteItem<T>(T model)
        {
            dbContext.DeleteAsync(model);
        }
        //pull user list from database
        public void GetUser()
        {
            List<ScanCondition> scanConditions = new List<ScanCondition>() { };
            user = dbContext.ScanAsync<Users>(scanConditions).GetRemainingAsync().Result;
        }
    }
}

