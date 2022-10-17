namespace AutoDialUp.Data
{
    public class SoftwareConfig
    {
        public SoftwareConfig() { }
        public SoftwareConfig(int autoStart,int autoConnect,int autoReConnect,int reConnectCount)
        {
            AutoStart = autoStart;
            AutoConnect = autoConnect;
            AutoReConnect = autoReConnect;
            ReConnectCount = reConnectCount;
        }
        /// <summary>
        /// 
        /// </summary>
        public int AutoStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AutoConnect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AutoReConnect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ReConnectCount { get; set; }
    }
}
