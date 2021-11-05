namespace WendiPanic.SQLiteDB
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
