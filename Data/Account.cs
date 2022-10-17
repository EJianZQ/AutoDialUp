namespace AutoDialUp.Data
{
    //由于JSON废弃使用枚举类型，保留日后使用
    enum DialUpType
    {
        PPPoE,
        ADSL
    }
    public class DialUpAccount
    {

        public DialUpAccount(int dialUpType,string name, string account, string password)
        {
            DialUpType = dialUpType;
            Name = name;
            Account = account;
            Password = password;
        }

        public DialUpAccount() { }

        /// <summary>
        /// 
        /// </summary>
        public int DialUpType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }
}
