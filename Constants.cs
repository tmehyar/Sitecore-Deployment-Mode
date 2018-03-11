﻿using Sitecore.Data;
using Sitecore.Data.Items;

namespace DeploymentMode
{
	internal static class Constants
	{
		internal static string MasterDb => "master";
		internal static ID DeploymentModeSettingsItemId => ID.Parse("{B89C9EA8-EC8C-4792-A472-E748AAD5A9F0}");

		private static Item _settingsItem;
		internal static Item SettingsItem
		{
			get
			{
				return _settingsItem = Sitecore.Data.Database.GetDatabase(MasterDb).GetItem(DeploymentModeSettingsItemId);
			}
		}
	}
}
