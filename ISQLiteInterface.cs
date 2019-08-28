using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;


namespace assignment2.Interfaces
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
