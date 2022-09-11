using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using PC_support.Models;

namespace PC_support.Data
{
    public class HistoryData
    {
        readonly SQLiteAsyncConnection db;
        public HistoryData(string connectionString)
        {
            db = new SQLiteAsyncConnection(connectionString);
            db.CreateTableAsync<HistoryPC>().Wait();
        }
        public Task<List<HistoryPC>> GetUsersAsync()
        {
            return db.Table<HistoryPC>().ToListAsync();
        }
        public Task<HistoryPC> GetUserAsync(int id)
        {
            return db.Table<HistoryPC>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveUserAsync(HistoryPC history)
        {
            if (history.ID != 0)
            {
                return db.UpdateAsync(history);
            }
            else
            {
                return db.InsertAsync(history);

            }
        }
        public Task<int> DeleteUserAsync(HistoryPC history)
        {
            return db.DeleteAsync(history);
        }
    }
}
