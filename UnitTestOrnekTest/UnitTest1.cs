using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest;

namespace UnitTestOrnekTest
{
    [TestClass]
    public class UnitTest1
    {
        private  CartManager _cartManager;
        private  CartItem _cartItem;


        [TestInitialize]
        public void testInitialize()
        {
            //test methodlarından önce yaptığımız aynı işleri buraya attık.
            _cartManager=new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 100
                },
                Quantity = 1
            };
            _cartManager.Add(_cartItem);
        }

        [TestMethod]
        public void sepete_ürün_ekleyebilmeliyiz()
        {
            //Arrange
            const int beklenen = 1;
                     //initialize
            //Act

            var toplamElemanSayisi = _cartManager.TotalItems;

            //Assert
            Assert.AreEqual(beklenen,toplamElemanSayisi);

        }

        [TestMethod]
        public void sepetten_ürün_çıkarabilmeliyiz()
        {
            //Arrange
                    //initialize
            //ürünü ekledik
            //sepetteki ürünleri saydık
            var sepettekiElemanSayisi = _cartManager.TotalItems;

            //Act
            //ürünü sildik
            //sepetteki ürünleri saydık
            _cartManager.Delete(1);
            var sepetteKalanElemanSayisi = _cartManager.TotalItems;

            //Assert
            Assert.AreEqual(sepettekiElemanSayisi-1, sepetteKalanElemanSayisi);

        }

        [TestMethod]
        public void sepet_temizlenebilmeli()
        {
            //Arrange
                    //initialize   

            //Act
            _cartManager.Clear();

            //Assert
            //kalan 0 a eşit olmalı
            Assert.AreEqual(0,_cartManager.TotalQuantity);
        }

        [TestMethod]
        public void sepette_farkli_urunden_iki_tane_ekleme()
        {
            //Arrange
            int toplamElemanSayisi = _cartManager.TotalItems;
            int toplamAdet = _cartManager.TotalQuantity;

            //2. kez ürünleri ekledik
            _cartManager.Add(new CartItem
            {
                Product = new Product
                {
                    ProductId = 2,
                    ProductName = "Laptop",
                    UnitPrice = 100
                },
                Quantity = 1
            });

            //Act

            //Assert
            Assert.AreEqual(toplamAdet+1,_cartManager.TotalQuantity);
            Assert.AreEqual(toplamElemanSayisi + 1, _cartManager.TotalItems);
        }

        [TestMethod]
        public void sepette_ayni_urunden_iki_tane_ekleme()
        {
            //Arrange
            int toplamElemanSayisi = _cartManager.TotalItems;
            int toplamAdet = _cartManager.TotalQuantity;

            //2. kez ürünleri ekledik
            _cartManager.Add(_cartItem);

            //Act

            //Assert
            Assert.AreEqual(toplamAdet + 1, _cartManager.TotalQuantity);
            Assert.AreEqual(toplamElemanSayisi, _cartManager.TotalItems);
        }
    }
}
