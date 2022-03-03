using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{


    public class Cart
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public virtual void AddItem(Book book, int qty)
        {
            ShoppingCartItem Line = Items.Where(p => p.Book.BookId == book.BookId).FirstOrDefault();



            if (Line == null)
            {
                Items.Add(new ShoppingCartItem{
                    Book = book,
                    Quantity = qty,
                    Cost = book.Price
                });
            }

            else
            {
                Line.Quantity += qty;
                Line.Cost += book.Price;
            }
        }
        public virtual void RemoveItem (Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }
        public double CalculateSubTotal()
        {
            double sum = Items.Sum(x => x.Cost);

            return sum;
        }

        public int CalculateAmountBooks()
        {
            int sum = Items.Sum(x => x.Quantity);

            return sum;
        }
    }
    public class ShoppingCartItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }


}
