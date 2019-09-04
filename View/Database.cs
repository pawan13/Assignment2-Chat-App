using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_ChatApp.View
{
    public class Database
    {
        //readonly SQLiteAsyncConnection _database;
        private SQLiteAsyncConnection _database;

        public Database(string path)
        {
            //when line 14 executed, the connection with database is created; if database already existed connection is return.
            _database = new SQLiteAsyncConnection(path);
            //line 16 creates the table if it is not exist, else it does nothing.
            _database.CreateTableAsync<Model.UserAccount>().Wait();

            _database.InsertAsync(new Model.UserAccount { ID = "1", Username = " test11", Password = "123" });
            //_database.InsertAsync(new Model.UserAccount { Username = " test11", Password = "123" });
        }

        public Task<List<Model.UserAccount>> GetAllInfo()
        {
            return _database.Table<Model.UserAccount>().ToListAsync();
        }

        //when this method invoked, it pass useraccount object and write info object data to database
        public async Task SaveInfo(Model.UserAccount info)
        {
            await _database.InsertAsync(info);
        }

        async public Task<string> AddUser(Model.UserAccount user)
        {
            //var data = _database.Table<Model.UserAccount>();
            //var d1 = data.Where(x => x.Username == user.Username).FirstOrDefaultAsync();
            Model.UserAccount d1 = await _database.Table<Model.UserAccount>().Where(x => x.Username == user.Username).FirstOrDefaultAsync();
            if (d1 == null)
            {
                await _database.InsertAsync(user);
                return "Successfully Added";
            }
            else
            {
                return "The username already exist";
  
            }
        }
    }
}
