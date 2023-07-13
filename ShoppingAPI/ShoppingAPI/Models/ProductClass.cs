namespace ShoppingAPI.Models
{
    public class ProductClass
    {

        #region Properties
        public int ProductId { get; set; }

        public string ProductName { get; set; } 

        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }

        public double ProductPrice { get; set; }

        public bool isInStock { get; set; }

        #endregion


        #region Data

        private static List<ProductClass> Products = new List<ProductClass>()
        {
            new ProductClass() { ProductId = 1,ProductPrice =556,ProductName="Bat",ProductDescription="use to play cricket",ProductCategory="sports",isInStock=true},
            new ProductClass() { ProductId = 2,ProductPrice =634200,ProductName="Cadillac",ProductDescription="Automobile used to travel",ProductCategory="Automobile",isInStock=false},
            new ProductClass() { ProductId = 3,ProductPrice =100000,ProductName="Mercedes-Benz",ProductDescription="Automobile used to travel",ProductCategory="Automobile",isInStock=true},
            new ProductClass() { ProductId = 4,ProductPrice =652,ProductName="Gucci shirt",ProductDescription="Big designer cloths brand",ProductCategory="Clothes",isInStock=true},
            new ProductClass() { ProductId = 5,ProductPrice =979,ProductName="Nike shoes",ProductDescription="provoide all types of sports good",ProductCategory="Clothes",isInStock=false},
            new ProductClass() { ProductId = 6,ProductPrice =925,ProductName="DKNy Tshirt",ProductDescription="Prodvide all kind of designer cloths",ProductCategory="Clothes",isInStock=true},
            new ProductClass() { ProductId = 7,ProductPrice =7896,ProductName="One plus 15",ProductDescription="Best mobile in range brand",ProductCategory="Mobile",isInStock=false},
            new ProductClass() { ProductId = 8,ProductPrice =343,ProductName="Realme 5 Pro",ProductDescription="Mobile brand",ProductCategory="Mobile",isInStock=true},
            new ProductClass() { ProductId = 9,ProductPrice =778,ProductName="5AM club",ProductDescription="Book to improve life",ProductCategory="Book",isInStock=true},
            new ProductClass() { ProductId = 10,ProductPrice =9999,ProductName="Rich Dad poor dad",ProductDescription="How rich play life",ProductCategory="Book",isInStock=true},
        };

        private static List<ProductClass> CartProducts = new List<ProductClass>();
        #endregion

        #region AllMethods

        #region GetMethods
        public List<ProductClass> GetAllProductList()
        {
            return Products;
        }

        public List<ProductClass> GetProductByName (string name)
        {
            var prodList = Products.FindAll(x => x.ProductName.ToUpper() == name.ToUpper());
            if(prodList != null)
            {
                return prodList;
            }
            throw new Exception("Product with this name not found");
        }


        public List<ProductClass> GetProductByCategory(string cato)
        {
            var prodList = Products.FindAll(x => x.ProductCategory.ToUpper() == cato.ToUpper());
            if (prodList != null)
            {
                return prodList;
            }
            throw new Exception("Product with this Category not found");
        }

        public List<ProductClass> GetProductInStock(bool instock)
        {
            var prodList = Products.FindAll(x => x.isInStock == instock);
            if (prodList != null)
            {
                return prodList;
            }
            throw new Exception("Product with this Category not found");
        }

        #endregion
        #region add,update & delete method

        public string AddProduct(ProductClass newProduct)
        {
            Products.Add(newProduct);
            return "The new Product is added successfully";
        }

        public string UppdateProduct(ProductClass newProduct)
        {
            var oldProduct = Products.Find(x => x.ProductId == newProduct.ProductId);
            if (oldProduct != null)
            {
                oldProduct.ProductName = newProduct.ProductName;
                oldProduct.ProductCategory = newProduct.ProductCategory;
                oldProduct.isInStock = newProduct.isInStock;
                oldProduct.ProductPrice = newProduct.ProductPrice;
                oldProduct.ProductDescription = newProduct.ProductDescription;

                return "The Product is updated in the list";
            }
            throw new Exception("Please check the product id once");
        }

        public string DeleteProduct(int prodid)
        {
           var oldProd = Products.Find(x => x.ProductId == prodid);
            if (oldProd != null)
            {
                Products.Remove(oldProd);
                return "The Product was removed successfully";
            }
            throw new Exception("The Product with this ID does not exsit ");
            
        }

        #endregion

        #region CartMethods

        public string AddProductInCart(int prodId)
        {
            var newProduct = Products.Find(x => x.ProductId == prodId);
            if (newProduct != null)
            {
                CartProducts.Add(newProduct);
                return "The Product is added to the cart";
            }

            throw new Exception("The new Product is added successfully");
        }

        public List<ProductClass> GetAllCartProducts()
        {
            return CartProducts;
        }
        #endregion

        #endregion

    }
}
