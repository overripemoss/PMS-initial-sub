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
        public readonly DynamoDBContext dbContext;
        public List<Product> store = new List<Product>();
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
        public void SaveItem<T>(T model)
        {
            dbContext.SaveAsync(model);
        }
        public void GetItem()
        {
            List<ScanCondition> scanConditions = new List<ScanCondition>() { };
            store = dbContext.ScanAsync<Product>(scanConditions).GetRemainingAsync().Result;
            
        }
        public void DeleteItem()
        {
            
        }
        public void GetUser()
        {
            List<ScanCondition> scanConditions = new List<ScanCondition>() { };
            List<Users> user = dbContext.ScanAsync<Users>(scanConditions).GetRemainingAsync().Result;
        }
    }
}

