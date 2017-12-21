using System;
using System.Web.Http;
using Amido.Net.Http.Formatting.YamlMediaTypeFormatter;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(API.App_Start.YamlMediaTypeFormatterConfig), "PreStart")]

namespace API.App_Start {
    public static class YamlMediaTypeFormatterConfig {
        public static void PreStart() {
            GlobalConfiguration.Configuration.Formatters.Add(new YamlMediaTypeFormatter());
        }
    }
}