using Sitecore.Pipelines.LoggedIn;
using Sitecore.Security.Accounts;
using System;
using System.Linq;

namespace DeploymentMode.Processors
{
	public class LoggedInProcessor
	{
		public void Process(LoggedInArgs args)
		{
			var settingsItem = Constants.SettingsItem;

			//Get excluded roles array
			var excludedRoles = settingsItem[Templates.DeploymentMode.Fields.LockOutUsers.ExcludedRoles].Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

			//Check if current user is part of excluded list
			var isInExcludedRole = excludedRoles.Any(a => ((User)User.FromName(args.Username, AccountType.User)).IsInRole(a));

			//Check if current user is Administrator
			var isAdmin = (User.FromName(args.Username, AccountType.User) as User).IsAdministrator;

			if (settingsItem[Templates.DeploymentMode.Fields.DeploymentModeOn].ToString().Equals("1")
				&& settingsItem[Templates.DeploymentMode.Fields.LockOutUsers.LockOutUsersOn].ToString().Equals("1")
				&& isAdmin == false
				&& isInExcludedRole == false)
				throw new ApplicationException("Not allowed. Your Admin has prevented logging in during deployment");
		}
	}
}
