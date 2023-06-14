using Cart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartContext _db;

        public CartController(CartContext db)
        {
            _db = db;
        }

        // GET: api/cart
        [HttpGet]
        public ActionResult<IEnumerable<userCart>> GetAllCarts()
        {
            List<userCart> carts = _db.userCarts.Include(c => c.Items).ToList();
            return Ok(carts);
        }

        // GET: api/cart/{userId}
        [HttpGet("{userId}")]
        public ActionResult<userCart> GetCartByUserId(int userId)
        {
            userCart cart = _db.userCarts.Include(c => c.Items).FirstOrDefault(c => c.userID == userId);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // POST: api/cart
        [HttpPost]
        public ActionResult<userCart> AddCart(userCart cart)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.userCarts.Add(cart);
                    _db.SaveChanges();
                    return CreatedAtAction(nameof(GetCartByUserId), new { userId = cart.userID }, cart);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest();
        }

        // PUT: api/cart/{userId}
        [HttpPut("{userId}")]
        public ActionResult UpdateCart(int userId, [FromBody] userCart updatedCart)
        {
            userCart cart = _db.userCarts.FirstOrDefault(c => c.userID == userId);
            if (cart == null)
            {
                return NotFound();
            }

            // Update the properties of the existing cart with the values from the updatedCart object
            cart.Items = updatedCart.Items;

            _db.SaveChanges();

            return Ok(cart);
        }


        [HttpDelete("{userId}")]
        public ActionResult DeleteCart(int userId)
        {
            userCart cart = _db.userCarts.Include(c => c.Items).FirstOrDefault(c => c.userID == userId);
            if (cart == null)
            {
                return NotFound();
            }

            _db.items.RemoveRange(cart.Items);
            _db.userCarts.Remove(cart);
            _db.SaveChanges();
            return Ok(cart);
        }
    }
    }
