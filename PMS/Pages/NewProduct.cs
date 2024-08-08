using Amazon.DynamoDBv2.DataModel;

namespace Database
{
    [DynamoDBTable("Store")]
        public class Product
        {
            [DynamoDBHashKey]
            public int ProductID { get; set;}
            [DynamoDBRangeKey]
            public string Name { get; set;}
            [DynamoDBProperty]
            public int Stock { get; set;}
            [DynamoDBProperty]
            public int Shelf { get; set;}
            [DynamoDBProperty]
            public int Delivery { get; set;}
            [DynamoDBProperty]
            public int Price {get; set;}

            [DynamoDBProperty]
            public int Cost {get; set;}



        }
}
