using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualBasic;
using PMS.Pages;

namespace Database
{
    public class dataBase
	{
        public readonly DynamoDBContext dbContext;
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
            //IEnumerable<ScanCondition> scanConditions = dbContext.FromScanAsync(new ScanCondition("ProductID",ScanOperator.LessThan, 1000));
            //List<Products> Products = dbContext.ScanAsync<Products>(Products.All<Products>).GetRemainingAsync().Result;
        }
        public void DeleteItem()
        {
            
        }
    }
}

