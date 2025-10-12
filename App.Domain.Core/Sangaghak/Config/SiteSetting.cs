namespace App.Domain.Core.Sangaghak.Config
{
    public class Rootobject
    {
        public Sitesettings SiteSettings { get; set; }
    }

    public class Sitesettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Sqlconfigurations SqlConfigurations { get; set; }
        public Seqconfigurations SeqConfigurations { get; set; }
        public string ApiKey { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Sqlconfigurations
    {
        public string ConnectionString { get; set; }
    }

    public class Seqconfigurations
    {
        public string UrlAddress { get; set; }
        public string ApiToken { get; set; }
        public string MinimumLevel { get; set; }
    }

    public class Seq
    {
        public string ServerUrl { get; set; }
        public string ApiKey { get; set; }
        public string MinimumLevel { get; set; }
        public Leveloverride LevelOverride { get; set; }
    }

    public class Leveloverride
    {
        public string Microsoft { get; set; }
    }


}
