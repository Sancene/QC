using NUnit.Framework;
using ApiLab;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace ApiTests
{
    public class Tests
    {
        public ApiRequest api = new ApiRequest();
        public DataDump dump = new DataDump();
        public List<int> addedID = new List<int>();

        [Test, Order(1)]
        public void GetAllProductsTest()
        {
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            bool answer = dump.CheckEqualsLists(ref products);

            Assert.AreEqual(answer, true);
            Assert.AreEqual(response.StatusCode.GetHashCode(), 200);
        }

        [Order(2)]
        [TestCase(new string[] { "1", "testTitle1", "10,25", "8,5", "0", "0" }, 200)]
        [TestCase(new string[] { "0", "testTitle2", "1000", "850", "0", "0" }, 412)]
        [TestCase(new string[] { "1", "testTitle3", "1000", "850", "0", "0" }, 200)]
        [TestCase(new string[] { "15", "testTitle4", "1000", "850", "0", "0" }, 200)]
        [TestCase(new string[] { "16", "testTitle5", "1000", "850", "0", "0" }, 412)]
        [TestCase(new string[] { "7", "testTitle6", "-120", "850", "0", "0" }, 412)]
        [TestCase(new string[] { "7", "testTitle7", "1200", "850", "0", "0" }, 200)]
        [TestCase(new string[] { "7", "testTitle8", "1000", "850", "0", "1" }, 200)]
        [TestCase(new string[] { "7", "testTitle9", "1020", "850", "0", "2" }, 412)]
        [TestCase(new string[] { "7", "testTitle10", "1200", "850", "1", "0" }, 200)]
        [TestCase(new string[] { "7", "testTitle11", "1200", "850", "2", "0" }, 412)]
        [TestCase(new string[] { "7", "Casio MRP-700-1AVEF", "1200", "850", "1", "0" }, 200)]

        public void AddProductTest(string[] productParams, int statusCode)
        {
            //Arrange
            JsonProduct product = new JsonProduct();
            product.category_id = Convert.ToInt32(productParams[0]);
            product.title = productParams[1];
            product.price = Convert.ToDouble(productParams[2]);
            product.old_price = Convert.ToDouble(productParams[3]);
            product.status = Convert.ToInt32(productParams[4]);
            product.hit = Convert.ToInt32(productParams[5]);

            //Act
            var createResponse = api.CreateProduct(ref product);

            //Assert
            Assert.AreEqual(createResponse.statusCode, statusCode);
            api.DeleteProduct(createResponse.id);
        }

        [Order(3)]
        [TestCase(0, false)]
        [TestCase(14, true)]
        [TestCase(1, true)]
        [TestCase(16, false)]
        public void EditCategoryProductTest(int newCategory, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.category_id = newCategory;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);

            api.DeleteProduct(createResponse.id);
        }

        [Order(4)]
        [TestCase(2, false)]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        [TestCase(1, true)]
        public void EditStatusTest(int newStatus, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.status = newStatus;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);
            api.DeleteProduct(createResponse.id);
        }

        [Order(5)]
        [TestCase(2, false)]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        [TestCase(1, true)]
        public void EditHitTest(int newStatus, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.status = newStatus;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            api.DeleteProduct(createResponse.id);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);
        }

        [Order(6)]
        [TestCase("", true)]
        [TestCase(null, false)]
        [TestCase("Title", true)]
        [TestCase("Title123", true)]
        [TestCase("Новый заголовок", true)]
        public void EditTitleTest(string newTitle, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.title = newTitle;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            api.DeleteProduct(createResponse.id);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);
        }

        [Order(7)]
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase("Description", true)]
        [TestCase("Some New Product's Description 1 2 3", true)]
        [TestCase("Это описание на другом языке", true)]
        public void EditDescriptionTest(string newDesctiption, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.description = newDesctiption;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            api.DeleteProduct(createResponse.id);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);
        }

        [Order(8)]
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase("Keyword", true)]
        [TestCase("Casio 3", true)]
        [TestCase("Часы", true)]
        public void EditKeywordsTest(string newKeywords, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.keywords = newKeywords;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            api.DeleteProduct(createResponse.id);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);            
        }

        [Order(9)]
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase("<p>Test Content\n In This String</p>", true)]
        [TestCase("<p>Какой то контент на русском языке</p>", true)]
        public void EditContentTest(string newContent, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.content = newContent;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            api.DeleteProduct(createResponse.id);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);
        }

        [Order(10)]
        [TestCase(20, true)]
        [TestCase(0, true)]
        [TestCase(-1, false)]
        [TestCase(1000, true)]
        public void EditPriceTest(int newPrice, bool answer)
        {
            JsonProduct product = new JsonProduct();
            var createResponse = api.CreateProduct(ref product);
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);
            JsonProduct editedProduct = products[FindProductById(ref products, createResponse.id)];

            editedProduct.old_price = editedProduct.price;
            editedProduct.price = newPrice;

            api.EditProduct(ref editedProduct);

            response = api.GetAllProducts();
            products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            api.DeleteProduct(createResponse.id);

            Assert.AreEqual(products[FindProductById(ref products, createResponse.id)].CheckEqualProducts(ref editedProduct), answer);
        }


        [Test, Order(11)]
        public void DeleteProduct()
        {
            JsonProduct product = new JsonProduct();

            var createResponse = api.CreateProduct(ref product);

            Assert.AreEqual(api.DeleteProduct(createResponse.id), 200);
        }

        [Test, Order(12)]
        public void DeleteAllProducts()
        {
            var response = api.GetAllProducts();
            var products = JsonConvert.DeserializeObject<JsonProduct[]>(response.Content.ReadAsStringAsync().Result);

            for (int i = dump.productCount; i < products.Length; ++i)
            {
                addedID.Add(products[i].id);
            }

            for (int j = 0; j < addedID.Count; ++j)
            {
                int code = api.DeleteProduct(addedID[j]);
                Assert.AreEqual(code, 200);
            }

            addedID.Clear();
        }

        public int FindProductById(ref JsonProduct[] products, int id)
        {
            for (int i = 0; i < products.Length; ++i)
            {
                if (products[i].id == id)
                    return i;
            }
            return 10000;
        }
    }
}