using System;
using System.IO;
using System.Text;
using System.Xml;
using TMDbLib.Client;
using TMDbLib.Objects.General;

namespace Web.Code
{
	public class TmdbClientFactory
	{
		public static TMDbClient GetInstance()
		{
			var client = new TMDbClient(ConfigurationHelper.TmdbToken);

			FetchConfig(client);

			return client;
		}

		private static void FetchConfig(TMDbClient client)
		{
			var configXml = new FileInfo(string.Format("{0}{1}", ConfigurationHelper.ConfigPath, "config.xml"));
			
			if (configXml.Exists && configXml.LastWriteTimeUtc >= DateTime.UtcNow.AddHours(-1))
			{
				string xml = File.ReadAllText(configXml.FullName, Encoding.Unicode);

				var xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(xml);

				client.SetConfig(Serializer.Deserialize<TMDbConfig>(xmlDoc));
			}
			else
			{
				client.GetConfig();

				var xmlDoc = Serializer.Serialize(client.Config);
				File.WriteAllText(configXml.FullName, xmlDoc.OuterXml, Encoding.Unicode);
			}
		}
	}
}