using BaseModel;
using System;
using System.Configuration;

namespace AndersonNotificationModel
{
    public class EmailNotification : Base
    {
        private bool? _enableSsl { get; set; }
        private bool? _isBodyHtml { get; set; }

        private int? _port { get; set; }
        
        private string _bcc { get; set; }
        private string _cC { get; set; }
        private string _host { get; set; }
        private string _from { get; set; }
        private string _password { get; set; }
        private string _subject { get; set; }
        private string _to { get; set; }
        private string _username { get; set; }

        public bool EnableSsl
        {
            get
            {
                return _enableSsl ?? Convert.ToBoolean(ConfigurationManager.AppSettings["EmailNotificationEnableSsl"]);
            }
            set
            {
                _enableSsl = value;
            }
        }
        public bool IsBodyHtml
        {
            get
            {
                return _isBodyHtml ?? Convert.ToBoolean(ConfigurationManager.AppSettings["EmailNotificationIsBodyHtml"]);
            }
            set
            {
                _isBodyHtml = value;
            }
        }

        public int EmailNotificationId { get; set; }
        public int Port
        {
            get
            {
                return _port ?? Convert.ToInt32(ConfigurationManager.AppSettings["EmailNotificationPort"]);
            }
            set
            {
                _port = value;
            }
        }

        public string Bcc
        {
            get
            {
                if (!string.IsNullOrEmpty(_bcc))
                    return _bcc;
                return ConfigurationManager.AppSettings["EmailNotificationBcc"];
            }
            set
            {
                _bcc = value;
            }
        }
        public string Body { get; set; }
        public string CC
        {
            get
            {
                return _cC ?? ConfigurationManager.AppSettings["EmailNotificationCC"];
            }
            set
            {
                _cC = value;
            }
        }
        public string Host
        {
            get
            {
                if (!string.IsNullOrEmpty(_host))
                    return _host;
                return ConfigurationManager.AppSettings["EmailNotificationHost"];
            }
            set
            {
                _host = value;
            }
        }
        public string From
        {
            get
            {
                if (!string.IsNullOrEmpty(_from))
                    return _from;
                return ConfigurationManager.AppSettings["EmailNotificationFrom"];
            }
            set
            {
                _from = value;
            }
        }
        public string Password
        {
            get
            {
                if (!string.IsNullOrEmpty(_password))
                    return _password;
                return ConfigurationManager.AppSettings["EmailNotificationPassword"];
            }
            set
            {
                _password = value;
            }
        }
        public string Subject
        {
            get
            {
                if (!string.IsNullOrEmpty(_subject))
                    return _subject;
                return ConfigurationManager.AppSettings["EmailNotificationSubject"];
            }
            set
            {
                _subject = value;
            }
        }
        public string To
        {
            get
            {
                if (!string.IsNullOrEmpty(_to))
                    return _to;
                return ConfigurationManager.AppSettings["EmailNotificationTo"];
            }
            set
            {
                _to = value;
            }
        }
        public string Username
        {
            get
            {
                if (!string.IsNullOrEmpty(_username))
                    return _username;
                return ConfigurationManager.AppSettings["EmailNotificationUsername"];
            }
            set
            {
                _username = value;
            }
        }
    }
}
    