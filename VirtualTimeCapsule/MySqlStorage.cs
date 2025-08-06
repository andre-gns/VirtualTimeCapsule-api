internal class MySqlStorage
{
    private string? hangfireConnectionString;
    private MySqlStorageOptions mySqlStorageOptions;

    public MySqlStorage(string? hangfireConnectionString, MySqlStorageOptions mySqlStorageOptions)
    {
        this.hangfireConnectionString = hangfireConnectionString;
        this.mySqlStorageOptions = mySqlStorageOptions;
    }
}