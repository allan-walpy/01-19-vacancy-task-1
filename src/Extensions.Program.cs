using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration;

namespace App.Server
{
    public static partial class Extensions
    {
        public static void AddAsConfiguraionTo(
            this CommandLineConfigurationSource argsContext,
            IConfigurationBuilder configBuilder)
        {
            var configArgs = GetConfigArgs(argsContext.Args);
            var configKeyValuePair = configArgs.ToKeyValuePair(Program.CommandLineArgsConfigValueSeparator);

            configBuilder.AddInMemoryCollection(configKeyValuePair);
        }

        private static List<string> GetConfigArgs(IEnumerable<string> args)
        {
            List<string> configArgs = new List<string>();

            foreach (var arg in args)
            {
                var isPrefixed = IsArgPrefixed(arg);
                if (isPrefixed)
                {
                    configArgs.Add(UnprefixeArg(arg));
                }
            }
            return configArgs;
        }

        private static List<KeyValuePair<string, string>> ToKeyValuePair(
            this List<string> keyValueList,
            char separator)
            => keyValueList.ConvertAll((keyValue) => {
                var splited = SplitKeyValue(keyValue, separator);
                return new KeyValuePair<string, string>(
                    key: splited[0],
                    value: splited.Length < 2 ? String.Empty : splited[1]);
            });

        private static string[] SplitKeyValue(this string keyValue, char separator)
        {
            if (keyValue == null)
            {
                return new[] { String.Empty, String.Empty };
            }

            var splitedKeyValue = keyValue.Split(separator, 2);
            if (splitedKeyValue.Length < 2)
            {
                return new[] { keyValue, String.Empty };
            }

            return splitedKeyValue;
        }

        private static bool IsArgPrefixed(string arg)
            => arg.StartsWith(Program.CommandLineArgsConfigPrefix, StringComparison.OrdinalIgnoreCase);

        private static string UnprefixeArg(string arg)
            => arg.Substring(Program.CommandLineArgsConfigPrefix.Length);
    }
}