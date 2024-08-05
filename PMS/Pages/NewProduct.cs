using Amazon.DynamoDBv2.DataModel;

namespace NewProduct
{
    [DynamoDBTable("Store")]
        public class Product
        {
            [DynamoDBHashKey]
            public int ProductID { get; set;}
            [DynamoDBRangeKey]
            public string Name { get; set;}


        }
}
