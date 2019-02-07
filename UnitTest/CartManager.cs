using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    //İstediklerimiz 
    //sepete ürün ekleyebilmeliyiz
    //sepetten ürün çıkarabilmeliyiz
    //sepet temizlenebilmeli
    //sepette aynı üründen iki tane olmamalı


    public class CartManager
    {
        private readonly List<CartItem> _cartItems;

        public CartManager()
        {
            _cartItems = new List<CartItem>();
        }


        public void Add(CartItem cartItem)
        {
            var addedCartItem = _cartItems.SingleOrDefault(p => p.Product.ProductId == cartItem.Product.ProductId);
            if (addedCartItem == null)
            {
                //eklenen ürün yoksa ekle
                _cartItems.Add(cartItem); //listeye ekleme yapıyoruz.
            }
            else
            {
                //varsa sadece miktarı arttır.
                addedCartItem.Quantity += cartItem.Quantity;
            }

        }

        public void Delete(int productId)
        {
            var removeProduct = _cartItems.SingleOrDefault(p => p.Product.ProductId == productId);
            //göndereceğimiz değerle aynıysa sil
            _cartItems.Remove(removeProduct);
        }

        public List<CartItem> CartItems
        {
            //listeleme
            get { return _cartItems; }
        }

        public void Clear()
        {
            _cartItems.Clear();
        }

        public decimal TotalPrice
        {
            get
            {
                return _cartItems.Sum(p => p.Quantity * p.Product.UnitPrice);
            }
        }

        public int TotalQuantity
        {
            get { return _cartItems.Sum(p => p.Quantity); }
        }

        public int TotalItems
        {
            get { return _cartItems.Count; }
        }
    }
}
