﻿using ReservationSystem2022.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem2022.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ReservationContext _context;

        public ItemRepository(ReservationContext context)
        {
            _context = context;
        }
        public async Task<Item?> AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return null;
            }
            return item;
        }

        public async Task<bool> ClearImages(Item item)
        {
            if (item.Images != null)
            {
                foreach (Image i in item.Images)
                {
                    _context.Images.Remove(i);
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            try
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<Item> GetItemAsync(long id)  
        {
            return await _context.Items.Include(i => i.Images).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _context.Items.Include(i => i.Images).ToListAsync();
        }

        public async Task<IEnumerable<Item>> QueryItems(string query)
        {
            return await _context.Items.Where(x => x.Name.Contains(query)).Include(i => i.Images).ToListAsync();
        }

        public async Task<Item> UpdateItemAsync(Item item) 
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return item;
        }
    }
}