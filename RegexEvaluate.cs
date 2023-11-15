using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

 
namespace My
{
    class RegexEvaluate {

        public static void TestUrlTransformation() {
            Log($"** Test URL Transformation **");

            Uri uri = new Uri("https://some.domain.com/rest/api/v2/rest/dataset/724");
            Log($"Request URI: {uri}");
            Log($"Local Path: {uri.LocalPath}");
            Log($"Absolute Path: {uri.AbsolutePath}");

            string brsUrl = "https://some.otherdomain.com";

            string newUrl = uri.LocalPath.Replace("/rest/api/v2", "");

            newUrl = brsUrl + newUrl;
            Log($"newUrl: {newUrl}");

            Uri transformed = new Uri(newUrl);

            Log($"Transformed URL: {transformed}");
        }

        
        public static void TestRequestPatternMatching() {
            Log($"** Test Request Pattern Matching **");

            // version URL
            URLMatch("https://some.domain.com/rest/api/v2/rest/system/analysis/version", "rest/api/v2/rest/system/analysis/version$");

            // dataset URL
            URLMatch("https://some.domain.com/rest/api/v2/rest/dataset/724", "rest/api/v2/rest/dataset/[0-9]+$");

            // enable dataset URL
            URLMatch("https://some.domain.com/rest/api/v2/rest/dataset/724/enabled", "rest/api/v2/rest/dataset/[0-9]+/enabled");

            // cluster path URL
            URLMatch("https://some.domain.com/rest/api/v2/rest/dataset/724/cluster/path?clusterIds=34051_34052_34053_34057_34058_5_9_10_47177", "rest/api/v2/rest/dataset/[0-9]+/cluster/path");

            // brain URL
            URLMatch("https://some.domain.com/rest/api/v2/rest/dataset/724/brain", "rest/api/v2/rest/dataset/[0-9]+/brain");
        }

        static void URLMatch(string url, string pattern) {
            Uri uri = new Uri(url);
            Evaluate(uri, pattern);
        }

        static void Evaluate(Uri uri, String pattern) {
            Log($"URI: {uri}");
        
            string path = uri.AbsolutePath;
            
            string matchString = " __ NO MATCH __";
            if (Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase)) {
                matchString = " ** MATCH ** ";
            }
            Log($"Evaluating URI path: '{path}' against pattern: '{pattern}' -> {matchString}");   
        }
        
        public static void Log(string msg) {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt + " - " + msg);
        }
    }
}