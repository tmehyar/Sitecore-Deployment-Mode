using Sitecore.Publishing.Pipelines.PublishItem;
using Sitecore.Security.Accounts;
using System;

namespace DeploymentMode.Processors
{
	public class PublishProcessor : PublishItemProcessor
	{
		public override void Process(PublishItemContext context)
		{
			var settingsItem = Constants.SettingsItem;

			if (settingsItem[Templates.DeploymentMode.Fields.DeploymentModeOn].ToString().Equals("1") && settingsItem[Templates.DeploymentMode.Fields.PreventPublishing.PreventPublishingOn].ToString().Equals("1"))
			{
				var allowAdmin = settingsItem[Templates.DeploymentMode.Fields.PreventPublishing.AllowAdminToPublish].ToString().Equals("1");
				var isAdmin = User.Current.IsAdministrator;

				if (allowAdmin == false || (allowAdmin && isAdmin == false))
				{
					throw new Exception("Not Allowed. Your Admin has prevented publishing during deployment");
				}
			}
		}
	}
}
