using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Slf4Net;
using Slf4Net.Helpers;
using Slf4Net.Interfaces;
using Slf4Net.Log4Net;

namespace AspNetProjectStructure.Service.Logging
{
    public class SimpleLoggingServiceProvider : ISlf4NetServiceProvider
    {
        public void Initialize()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            this.LoggerFactory = new Log4NetLoggerFactory();
            this.MarkerFactory = new BasicMarkerFactory();
            this.MdcAdapter = new BasicMdcAdapter();
        }

        public ILoggerFactory LoggerFactory { get; private set; }
        public IMarkerFactory MarkerFactory { get; private set; }
        public IMdcAdapter MdcAdapter { get; private set; }
        public string RequestedApiVersion  => throw new InvalidOperationException();
    }
}